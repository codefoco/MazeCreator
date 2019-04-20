param ([string] $PackageId)

. .\devops\BuildFunctions.ps1

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

& nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
# Unlist previous Pre-Release packages.
if ($versionToUnlist -ne "") {
	& $nuget delete $versionToUnlist -Source https://api.nuget.org/v3/index.json
}