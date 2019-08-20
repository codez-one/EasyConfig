$aspnetfolderPath = "extension\HealthCheck"
$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath 

$aspnetfolder = $dir + "\" + $aspnetfolderPath
$aspnetfolder

Set-Location -Path $aspnetfolder
dotnet publish --output ../../artifacts/ -f netcoreapp2.2 -c Release
Copy-Item "$dir/applicationHost.xdt" ../../artifacts/

Set-Location -Path $dir
./nuget pack -NoPackageAnalysis
$nupkgfilename = @(Get-Childitem -path ./* -Include health* -exclude *.nuspec)[0].Name
"file found : $nupkgfilename"

dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://api.nuget.org/v3/index.json
#dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://www.myget.org/F/mmercan/api/v3/index.json

Move-Item health*.nupkg ./outputs -Force
Set-Location -Path $dir