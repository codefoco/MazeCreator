
param ([string] $PackageId, [string] $NuSpecFile)


function Get-Published-PreRelase-Package-Version ($PackageId) {
	$out = [string](nuget list -PreRelease id:$PackageId)
	$version = $out.Split(' ')[1]
	$version = $version.Split('-')[0]
	return $version
}

function Get-Published-Package-Version ($PackageId) {
	$out = [string](nuget list id:$PackageId)
	$version = $out.Split(' ')[1]
	$version = $version.Split('-')[0]
	return $version
}

function Get-Git-Package-Version () {
	return [string](gitversion /showvariable MajorMinorPatch)
}

function Get-Git-Build-MetaData () {
	return [string](gitversion /showvariable BuildMetaData)
}

function Update-NuSpec-Version($File, $Version) {

	$File = Resolve-Path $File

	[ xml ]$fileContents = Get-Content -Encoding UTF8 -Path $File

	$versionPath = "package.metadata.version"

	if ($Version -ne $null -and $Version -ne "") {
		Set-XmlElementsTextValue -XmlDocument $fileContents -ElementPath $versionPath -TextValue $Version
	}

	$fileContents.Save($File)
}

function Get-XmlNamespaceManager([xml]$XmlDocument, [string]$NamespaceURI = "")
{
    # If a Namespace URI was not given, use the Xml document's default namespace.
	if ([string]::IsNullOrEmpty($NamespaceURI)) { $NamespaceURI = $XmlDocument.DocumentElement.NamespaceURI }	
	
	# In order for SelectSingleNode() to actually work, we need to use the fully qualified node path along with an Xml Namespace Manager, so set them up.
	[System.Xml.XmlNamespaceManager]$xmlNsManager = New-Object System.Xml.XmlNamespaceManager($XmlDocument.NameTable)
	$xmlNsManager.AddNamespace("ns", $NamespaceURI)
    return ,$xmlNsManager		# Need to put the comma before the variable name so that PowerShell doesn't convert it into an Object[].
}

function Get-FullyQualifiedXmlNodePath([string]$NodePath, [string]$NodeSeparatorCharacter = '.')
{
    return "/ns:$($NodePath.Replace($($NodeSeparatorCharacter), '/ns:'))"
}

function Get-XmlNode([xml]$XmlDocument, [string]$NodePath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	$xmlNsManager = Get-XmlNamespaceManager -XmlDocument $XmlDocument -NamespaceURI $NamespaceURI
	[string]$fullyQualifiedNodePath = Get-FullyQualifiedXmlNodePath -NodePath $NodePath -NodeSeparatorCharacter $NodeSeparatorCharacter
	
	# Try and get the node, then return it. Returns $null if the node was not found.
	$node = $XmlDocument.SelectSingleNode($fullyQualifiedNodePath, $xmlNsManager)
	return $node
}

function Set-XmlElementsTextValue([xml]$XmlDocument, [string]$ElementPath, [string]$TextValue, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	# Try and get the node.	
	$node = Get-XmlNode -XmlDocument $XmlDocument -NodePath $ElementPath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter
	
	# If the node already exists, update its value.
	if ($node)
	{ 
		$node.InnerText = $TextValue
	}
	# Else the node doesn't exist yet, so create it with the given value.
	else
	{
		# Create the new element with the given value.
		$elementName = $ElementPath.Substring($ElementPath.LastIndexOf($NodeSeparatorCharacter) + 1)
 		$element = $XmlDocument.CreateElement($elementName, $XmlDocument.DocumentElement.NamespaceURI)		
		$textNode = $XmlDocument.CreateTextNode($TextValue)
		$element.AppendChild($textNode) > $null
		
		# Try and get the parent node.
		$parentNodePath = $ElementPath.Substring(0, $ElementPath.LastIndexOf($NodeSeparatorCharacter))
		$parentNode = Get-XmlNode -XmlDocument $XmlDocument -NodePath $parentNodePath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter
		
		if ($parentNode)
		{
			$parentNode.AppendChild($element) > $null
		}
		else
		{
			throw "$parentNodePath does not exist in the xml."
		}
	}
}

function Test-Stable-Release ($stableVersion, $preReleaseVersion, $nugetGitVersion)
{
	if ($stableVersion -ne $preReleaseVersion -and $preReleaseVersion -ne $nugetGitVersion) {
		return $true
	}
	return $false
}

function Set-Forced-Git-Version ($version)
{
	Write-Output "next-version: $version" > GitVersion.yml
}


$stableVersion      = Get-Published-Package-Version ($PackageId)
$preReleaseVersion  = Get-Published-PreRelase-Package-Version ($PackageId)

$nugetGitVersion   = Get-Git-Package-Version
$buildMetaData = Get-Git-Build-MetaData

$nextVersion = ""

if (Test-Stable-Release $stableVersion $preReleaseVersion $nugetGitVersion) {
	$nextVersion = $preReleaseVersion
	Set-Forced-Git-Version $nextVersion
} else {
	$nextVersion = "$($nugetGitVersion)-beta-build$($buildMetaData)" 
}

Update-NuSpec-Version  $NuSpecFile $nextVersion
gitversion /updateassemblyinfo
