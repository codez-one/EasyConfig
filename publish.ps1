$aspnetfolderPath = "extension\HealthCheck"
$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath 

$aspnetfolder = $dir + "\" + $aspnetfolderPath
$aspnetfolder

Set-Location -Path $aspnetfolder
dotnet publish --output ../../artifacts/ -f netcoreapp2.2 -c Release

Set-Location -Path $dir
./nuget pack -NoPackageAnalysis
$nupkgfilename = @(Get-Childitem -Include HealthCheck* -exclude *.nuspec)[0].Name
$nupkgfilename

# dotnet nuget push $nupkgfilename -k [Insert-your-NugetKey-Here] -s https://www.myget.org/F/mmercan/api/v3/index.json

Move-Item HealthCheck*.nupkg ./outputs -Force
Set-Location -Path $dir