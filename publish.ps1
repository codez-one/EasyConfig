$aspnetfolderPath = "src\EasyConfig"
$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath 

$aspnetfolder = $dir + "\" + $aspnetfolderPath
$aspnetfolder

Set-Location -Path $aspnetfolder
dotnet publish --output ../../artifacts/ -f netcoreapp3.0 -c Release
Copy-Item "$dir/applicationHost.xdt" ../../artifacts/

Set-Location -Path $dir
./tools/nuget pack -NoPackageAnalysis -OutputDirectory ./output
$nupkgfilename = @(Get-Childitem -path ./output/*.nupkg)[0].Name
"file found : $nupkgfilename"

#dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://api.nuget.org/v3/index.json
#dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://www.myget.org/F/mmercan/api/v3/index.json

Set-Location -Path $dir