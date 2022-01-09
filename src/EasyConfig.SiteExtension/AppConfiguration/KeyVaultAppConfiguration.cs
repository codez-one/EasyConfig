namespace EasyConfig.SiteExtension.AppConfiguration;

using Azure.Identity;

internal static class KeyVaultAppConfiguration
{
    internal static ConfigurationManager AddEasyConfigAzureKeyVault(this ConfigurationManager configurationManager)
    {
        var uriList = new List<string>();

        var uriString = configurationManager["KeyVault:Uri"];
        if (!string.IsNullOrWhiteSpace(uriString))
        {
            uriList.Add(uriString);
        }

        // This will happen when the config looks like:
        // {
        //     "KeyVault":{
        //         "Uri": [
        //             "sample1.vault.azure.net/",
        //             "sample2.vault.azure.net/"
        //         ]
        //     }
        // }
        else
        {
            uriList = configurationManager.GetSection("KeyVault:Uri").Get<List<string>>();
        }


        // Add KeyVault only if the uri is not empty
        if (uriList?.Count > 0)
        {
            foreach (var uri in uriList)
            {
                if (Uri.TryCreate(uri, UriKind.Absolute, out var keyvaultUri))
                {
                    // Add Key Vault to configuration pipeline
                    _ = configurationManager.AddAzureKeyVault(
                        keyvaultUri,
                        new DefaultAzureCredential(),
                        new PrefixKeyVaultSecretManager()
                    );
                }
                else
                {
                    // TODO: Write Log
                }

            }
        }
        return configurationManager;
    }
}
