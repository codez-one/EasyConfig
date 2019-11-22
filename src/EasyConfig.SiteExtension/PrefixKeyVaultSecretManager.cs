namespace EasyConfig.SiteExtension
{
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.AzureKeyVault;

    public class PrefixKeyVaultSecretManager : IKeyVaultSecretManager
    {
        private readonly string prefix;
        private readonly bool removePrefix;

        public PrefixKeyVaultSecretManager(
            string prefix = "EASYCONFIG",
            bool removePrefix = false
        )
        {
            this.prefix = $"{prefix}--";
            this.removePrefix = removePrefix;
        }

        public bool Load(SecretItem secret) => secret.Identifier.Name.StartsWith(this.prefix);

        public string GetKey(SecretBundle secret)
        {
            var secretIdentifier = secret.SecretIdentifier.Name;

            if (this.removePrefix)
            {
                secretIdentifier = secretIdentifier.Substring(this.prefix.Length);
            }
            return secretIdentifier.Replace("--", ConfigurationPath.KeyDelimiter);
        }
    }
}
