# Contributors Guide

> This documenten is for developers that want to improve or extend the EasyConfig SiteExtension.

## Prequest

- VSCode or VisualStudio in a current version
- dotnet sdk as mentioned in [global.json](/global.json)
- NuGet CLI

## Project structure

The project is splitted in different parts for better clarity and maintenance.
This is the current project structure.
- EasyConfig (Root) 
   - docs: Documents for the whole project   
   - pipelines: The build-definition for Azure Pipelines
      - tools: additional tools for the build pipeline
   - src: All source code of the project.
      - EasyConfig.SiteExtension: The actual extension
      - EasyConfig.SiteExtension.NuGet: The specification for the NuGet package
   - tools: 

## Workflow to contribute

1. Write a comment on an issue that you start working on it
    - if no issue exsist create a new one
2. Fork the repo
3. Create a new branch in your fork for this issue
4. Start implementing your changes
5. Open a pull request to this repo (target branch master)
6. Wait for feedback and repeat step 4 and 6
7. Merge your pull request if all checks are green 

## Build

The build environment for this project is on Azure Pipelines and can be found here [dev.azure.com/czon/EasyConfig.SiteExtension](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build)

### Nuget package builds

| Name | Status |
| --- | --- |
| [EasyConfig.SiteExtension CI](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build?definitionId=4) | [![Build Status](https://dev.azure.com/czon/EasyConfig.SiteExtension/_apis/build/status/EasyConfig.SiteExtension%20CI?branchName=master)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_build?definitionId=4) |
| [Internal Release Stage](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) | [![Internal Release Stage](https://vsrm.dev.azure.com/czon/_apis/public/Release/badge/d27b319b-5062-4fcb-8dbb-ee3a080e553e/1/1)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) |
| [NuGet Release Stage](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) | [![nuget.org release Stage](https://vsrm.dev.azure.com/czon/_apis/public/Release/badge/d27b319b-5062-4fcb-8dbb-ee3a080e553e/1/2)](https://dev.azure.com/czon/EasyConfig.SiteExtension/_release?definitionId=1&_a=releases) |
