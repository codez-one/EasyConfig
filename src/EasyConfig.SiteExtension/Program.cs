namespace EasyConfig.SiteExtension
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.AzureKeyVault;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureAppConfiguration(
                    (ctx, builder) =>
                    {
                        //Build the config from sources we have
                        var config = builder.Build();

                        // Get the uri for the Vault from configuration
                        var keyVaultUri = config["KeyVault:Uri"];

                        // Add KeyVault only if the uri is not empty
                        if (!string.IsNullOrWhiteSpace(keyVaultUri))
                        {
                            //Create Managed Service Identity token provider
                            var azureServiceTokenProvider = new AzureServiceTokenProvider();

                            //Create the Key Vault client
                            var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                azureServiceTokenProvider.KeyVaultTokenCallback)
                            );

                            //Add Key Vault to configuration pipeline
                            _ = builder.AddAzureKeyVault(
                                keyVaultUri,
                                keyVaultClient,
                                new DefaultKeyVaultSecretManager()
                            );
                        }
                    }
                );
    }
}
