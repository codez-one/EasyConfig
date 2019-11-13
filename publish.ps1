$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath 
$extensionfolder = $dir + "/" + "src/EasyConfig.SiteExtension"
$nugetfolder = $dir + "/" + "src/EasyConfig.SiteExtension.NuGet"

dotnet publish "$extensionfolder/EasyConfig.SiteExtension.csproj" --output "$nugetfolder/content/" -f netcoreapp3.0 -c Release
Copy-Item "$nugetfolder/applicationHost.xdt" "$nugetfolder/content/"

./tools/nuget pack "$nugetfolder/EasyConfig.SiteExtension.nuspec" -NoPackageAnalysis -OutputDirectory ./output -properties Configuration=Release
# $nupkgfilename = @(Get-Childitem -path ./output/*.nupkg)[0].Name

#dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://api.nuget.org/v3/index.json
#dotnet nuget push $nupkgfilename -k $env:NugetKey -s https://www.myget.org/F/mmercan/api/v3/index.json
