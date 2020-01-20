# EasyConfig Azure Web App extension

An endpoint for SPA client apps hosted in an Azure Web App to get configuration values stored in environment variables or Azure KeyVault.

If a Single Page Application hosted in an Azure Web App needs configuration values that are only known in a deployed environment it can get a little tricky. A good example is the Uri for an API endpoint used by the client app or details for a client-side authentication like MSAL. These values are known at deployment time and can be set as settings in the Web App. But the only way to access these values from the client is having server-side code that can read the values and provide them to the client.  

This extension will take on that and after insallation you will get an endpoint like that:

```
https://easyconfigsiteextension.azurewebsites.net/.config/environment.json
```

## Usage

### Requirements

- Extensions can only be installed in Windows basesd App Services at the moment.
- The extension is written in c# using dotnet core 3.1 as Self-Contained application, so there should be no dependency on installed frameworks

### Installation

The Extension can be installed on the Azure Portal or with an ARM Template

#### Azure Portal

In the Settings of the Azure Web App under the *Development Tools* section will be an *Extensions* button. On this page you can *Add* an new extension.  
In the *Choose extension* dialog have a look for **Easy Config** and select the extension.  
After that the *Accept legal terms* dialog has to be confirmed.

The Insatllation will take some moments and when finished you see the extension in the table below the *Add* button.

When an update to is available it will be shown in this table also.

#### ARM Template

coming soon &trade;

### Configuration

Which values will be included in the response json can be set up either using the *Application Settings*, an *Azure KeyVault* or both.

#### Application Settings

In the Azure Portal in the Wep App under *Settings* > *Configuration* the *Application settings* can be edited.

All EasyConfig settings must start with `EASYCONFIG__` followed by the name of the setting. For example:

```
EASYCONFIG__setting1
```

The *Value* field will be also the value of this setting.

All other *Application settings* which does not start with `EASYCONFIG__` will be ignored.

#### Azure KeyVault

An other way to store the Settings is using an Azure KeyVault.

coming soon &trade;

### Using the endpoint

The endpoint can be accessed by the following ways:

```
...azurewebsites.net/.config/
...azurewebsites.net/.config/environment
...azurewebsites.net/.config/environment.json
```

> **Info**: When using the `.config/` endpoint the trailing `/` is nessesary and not optional.

all these endpoints will return a json similar to this one:

```json
{
    "setting1": "value 1"
}
```

This json can be used in the client app to initialize the app with all nessesary values.

## Nuget

The EasyConfig extension is provided as a nuget package and can be found on nuget.org.

| Name | Status |
| --- | ---|
| [Internal Feed on AzDO](https://dev.azure.com/czon/EasyConfig.SiteExtension/_packaging?_a=package&feed=31290296-b55e-464b-b92e-d8b8c91cbdfe&package=e97dc02b-bdd8-4299-9f84-2b795b116572&preferRelease=true) | [![EasyConfig.SiteExtension package in EasyConfig.SiteExtension feed in Azure Artifacts](https://feeds.dev.azure.com/czon/d27b319b-5062-4fcb-8dbb-ee3a080e553e/_apis/public/Packaging/Feeds/31290296-b55e-464b-b92e-d8b8c91cbdfe/Packages/e97dc02b-bdd8-4299-9f84-2b795b116572/Badge)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_packaging?_a=package&feed=31290296-b55e-464b-b92e-d8b8c91cbdfe&package=e97dc02b-bdd8-4299-9f84-2b795b116572&preferRelease=true) |
| [nuget.org EasyConfig.SiteExtension](https://www.nuget.org/packages/EasyConfig.SiteExtension/) | [![Nuget Badge](https://img.shields.io/nuget/v/EasyConfig.SiteExtension.svg)](https://www.nuget.org/packages/EasyConfig.SiteExtension/) |


## Build

The build environment for this project is on Azure DevOps and can be found here [dev.azure.com/czon/EasyConfig.SiteExtension](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build)

### Nuget package build

| Name | Status |
| --- | --- |
| [EasyConfig.SiteExtension CI](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build?definitionId=4) | [![Build Status](https://dev.azure.com/czon/EasyConfig.SiteExtension/_apis/build/status/EasyConfig.SiteExtension%20CI?branchName=master)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build?definitionId=4) |
| [Internal Release Stage](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) | [![Internal Release Stage](https://vsrm.dev.azure.com/czon/_apis/public/Release/badge/d27b319b-5062-4fcb-8dbb-ee3a080e553e/1/1)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) |
| [NuGet Release Stage](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) | [![nuget.org release Stage](https://vsrm.dev.azure.com/czon/_apis/public/Release/badge/d27b319b-5062-4fcb-8dbb-ee3a080e553e/1/2)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) |

## Authors

-   **Kirsten Kluge** - _Initial work_ - [kirkone](https://github.com/kirkone)

See also the list of [contributors](https://github.com/codez-one/EasyConfig/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

-   Inspired by this [GitHub](https://github.com/mmercan/Creating-Azure-WebSites-Site-Extensions) repo
