$artifactsFolderName = "artifacts"
$extensionFolderName = "extension"
$outputsFolderName = "outputs"
$projectFolderName = "HealthCheck"
Write-Host "--------------------------------"
$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath

$appFolder = Join-Path -Path $dir -ChildPath .\$extensionFolderName\$projectFolderName
$testFolder = Join-Path -Path $dir -ChildPath .\$extensionFolderName\$projectFolderName".Tests"
$artifactsFolder = Join-Path -Path $dir -ChildPath .\$artifactsFolderName
$outputsFolder = Join-Path -Path $dir -ChildPath .\$outputsFolderName

#Create Folder Structure 
new-item -type directory -path $appFolder -Force
new-item -type directory -path $testFolder -Force
new-item -type directory -path $artifactsFolder -Force
new-item -type directory -path $outputsFolder -Force

set-location -Path $appFolder
dotnet new mvc

set-location -Path $testFolder
dotnet new xunit

set-location -Path $dir
dotnet new sln
dotnet sln add $appFolder
dotnet sln add $testFolder

