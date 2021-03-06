Add-PSSnapin Microsoft.SharePoint.PowerShell -ea 0

<#
    $feature = Get-SPFeature fead7313-4b9e-4632-80a2-98a2a2d83297
    $feature.GetTitle([Threading.Thread]::CurrentThread.CurrentCulture).Replace("`"", "`\`"")

    Get-SPFeature | measure
    Get-SPFeature | sort-object -Property Id -Unique | measure
#>

function Write-Features() {
    Get-SPFeature | sort-object -Property Id -Unique | foreach { 
        $title = $_.GetTitle([Threading.Thread]::CurrentThread.CurrentCulture).Replace("`"", "`\`"")
        Write-Output "            _features.Add(new SPFeature() { Id = new Guid(`"$($_.Id)`"), DisplayName = `"$( $title )`", InternalName = `"$($_.DisplayName)`", Hidden = $($_.Hidden.ToString().ToLower()), IsCustomDefinition = false, Scope = Scope.$($_.Scope) });" 
    }
}

Write-Features > Features.cs