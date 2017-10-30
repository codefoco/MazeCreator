param ([string] $PackageId, [string] $NuSpecFile)

. .\BuildFunctions.ps1

if (-Not (Test-Should-Deploy)) {
	return
}

$nextVersion = Get-Next-Version-String $PackageId

if (Test-Package-Already-Published $PackageId $nextVersion) {
	return
}

$versionToUnlist = ""

if (-Not (Test-Version-Stable-Release $nextVersion)) {
	$publishedVersion = Get-Published-PreRelase-Package $PackageId
	if (-Not (Test-Version-Stable-Release $publishedVersion)) {
		$versionToUnlist = $publishedVersion
	}
}

$hash = Get-Current-Commit-Hash
$releaseNotes = "Release: $($hash)"

Update-NuSpec-Release-Notes $NuSpecFile $releaseNotes

$nuget = " ${env:ProgramFiles(x86)}" + "\NuGet\nuget.exe"

& $nuget pack $NuSpecFile
& $nuget push *.nupkg -Source https://www.nuget.org/api/v2/package

# Unlist previous Pre-Release packages.
if ($versionToUnlist -ne "") {
	& $nuget delete $versionToUnlist -Source https://www.nuget.org/api/v2/package
}