# EasyConfig Azure Web App extension

> provided by [codez.one](https://codez.one)

## Introduction

An endpoint for SPA client apps hosted in an Azure Web App to get configuration values stored in environment variables or Azure KeyVault.

If a Single Page Application hosted in an Azure Web App needs configuration values that are only known in a deployed environment it can get a little tricky. A good example is the URI for an API endpoint used by the client app or details for a client-side authentication like MSAL. These values are known at deployment time and can be set as settings in the Web App. But the only way to access these values from the client is having server-side code that can read the values and provide them to the client.  

This extension will take care on that and after installation you will get an endpoint like that:

```
https://easyconfigsiteextension.azurewebsites.net/.config/environment.json
```

The response looks like:

```json
{
    "section":
    {
        "setting": "value"
    },
    "setting1": "value 1"
}
```

## For users

For detail user instruction look at our [user manual](/docs/users/Index.md).

## For contributors

You’re not interested in developing and just want to know more about how to use the software? [Right this way](/docs/contributors/Index.md)

## Nuget Package

The EasyConfig extension is provided as a nuget package and can be found on nuget.org. The extension will be automaticly indexed by the Azure Web App extension provider and added to the selection in the portal.

> **Info**: As a user you do not have to use this nuget package directly.

| Name | Status |
| --- | ---|
| [Internal Feed on AzDO](https://dev.azure.com/czon/EasyConfig.SiteExtension/_packaging?_a=package&feed=31290296-b55e-464b-b92e-d8b8c91cbdfe&package=e97dc02b-bdd8-4299-9f84-2b795b116572&preferRelease=true) | [![EasyConfig.SiteExtension package in EasyConfig.SiteExtension feed in Azure Artifacts](https://feeds.dev.azure.com/czon/d27b319b-5062-4fcb-8dbb-ee3a080e553e/_apis/public/Packaging/Feeds/31290296-b55e-464b-b92e-d8b8c91cbdfe/Packages/e97dc02b-bdd8-4299-9f84-2b795b116572/Badge)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_packaging?_a=package&feed=31290296-b55e-464b-b92e-d8b8c91cbdfe&package=e97dc02b-bdd8-4299-9f84-2b795b116572&preferRelease=true) |
| [nuget.org EasyConfig.SiteExtension](https://www.nuget.org/packages/EasyConfig.SiteExtension/) | [![Nuget Badge](https://img.shields.io/nuget/v/EasyConfig.SiteExtension.svg)](https://www.nuget.org/packages/EasyConfig.SiteExtension/) |

## Authors

-   **Kirsten Kluge** - _Initial work_ - [kirkone](https://github.com/kirkone)
-   **Paul Jeschke** - _Documentation_ - [paule96](https://github.com/paule96)

See also the list of [contributors](https://github.com/codez-one/EasyConfig/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

-   Inspired by this [GitHub](https://github.com/mmercan/Creating-Azure-WebSites-Site-Extensions) repo
