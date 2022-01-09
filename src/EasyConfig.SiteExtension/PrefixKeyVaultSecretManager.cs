namespace EasyConfig.SiteExtension;

using Microsoft.Extensions.Configuration;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;

public class PrefixKeyVaultSecretManager : KeyVaultSecretManager
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

    public override bool Load(SecretProperties secret) => secret.Name.StartsWith(this.prefix, StringComparison.InvariantCultureIgnoreCase);

    public override string GetKey(KeyVaultSecret secret)
    {
        var secretIdentifier = secret.Name;

        if (this.removePrefix)
        {
            secretIdentifier = secretIdentifier[this.prefix.Length..];
        }
        return secretIdentifier.Replace("--", ConfigurationPath.KeyDelimiter);
    }
}
