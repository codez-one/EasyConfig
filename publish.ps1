$scriptpath = $MyInvocation.MyCommand.Path 
$dir = Split-Path $scriptpath 
$extensionfolder = $dir + "/" + "src/EasyConfig.SiteExtension"
$nugetfolder = $dir + "/" + "src/EasyConfig.SiteExtension.NuGet"

dotnet publish "$extensionfolder/EasyConfig.SiteExtension.csproj" --output "$nugetfolder/content/" -f "net6.0" -c Release
Copy-Item "$nugetfolder/applicationHost.xdt" "$nugetfolder/content/"

dotnet pack "$extensionfolder/EasyConfig.SiteExtension.csproj" /p:PackageVersion=1.1.1 -o ./output -c Release --no-build
