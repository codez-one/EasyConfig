# Usage

> This documenten is for users of the EasyConfig project and describe how you can use it in your Azure Web Apps.

## Requirements

- Extensions can only be installed in Windows basesd App Services at the moment.
- The extension is written in c# using dotnet core 3.1 as self-contained application, so there should be **no** dependency to installed frameworks

## Installation

The Extension can be installed on the Azure Portal or with an ARM Template

### Azure Portal

In the Settings of the Azure Web App under the *Development Tools* section will be an *Extensions* button. On this page you can *Add* an new extension.  
In the *Choose extension* dialog have a look for **Easy Config** and select the extension.  
After that the *Accept legal terms* dialog has to be confirmed.

The Insatllation will take some moments and when finished you see the extension in the table below the *Add* button.

When an update to is available it will be shown in this table also.

### ARM Template

coming soon &trade;

## Configuration

Which values will be included in the response JSON can be set up either using the *Application Settings*, an *Azure KeyVault* or both.

### Application Settings

In the Azure Portal in the Wep App under *Settings* > *Configuration* the *Application settings* can be edited.

All EasyConfig settings must start with `EASYCONFIG__` followed by the name of the setting. For example:

```
EASYCONFIG__setting1
```

> **Important**: the devider is 2 times `_` (**underscore**)

The *Value* field will be also the value of this setting.

All other *Application settings* which does not start with `EASYCONFIG__` will be ignored by the extension.

### Azure KeyVault

An other way to store the Settings is using an Azure KeyVault.

coming soon &trade;

### Using the endpoint

The endpoint can be accessed by the following ways:

```
...azurewebsites.net/.config/
...azurewebsites.net/.config/environment
...azurewebsites.net/.config/environment.json
```

> **Info**: When using the `.config/` endpoint the trailing `/` (**slash**) is nessesary and not optional.

All these endpoints will return a JSON similar to this one:

```json
{
    "section":
    {
        "setting": "value"
    },
    "setting1": "value 1"
}
```

This JSON can be used in the client app to initialize the app with all nessesary values.
