param([string]$zip,[string]$publish) 

function Get-MSWebDeployInstallPath(){
     return  (get-childitem "HKLM:\SOFTWARE\Microsoft\IIS Extensions\MSDeploy" | Select -last 1).GetValue("InstallPath") + "msdeploy.exe"
}

[xml]$xml = Get-Content $($publish)
$deploySetting = $xml.SelectNodes("/publishData/publishProfile[@publishMethod='MSDeploy']") | Select-Object

$webServerName = "https://$($deploySetting.publishUrl)/msdeploy.axd?site=$($deploySetting.msdeploySite)"
$dest = "-dest:auto,computerName='" + $webServerName + "',UserName='" + $($deploySetting.userName) + "',Password='" + $($deploySetting.userPWD) + "',IncludeAcls='False',AuthType='Basic'"
$sorce = '-source:package="' + $($zip) + '"'
$siteNameParam='-setParam:name="IIS Web Application Name",value="' + $($deploySetting.msdeploySite) + '"'

$msdeployArguments =  @($($sorce), '-verb:sync', $($dest), $($siteNameParam)
    "-retryAttempts:20",
    "-verbose",
    "-AllowUntrusted",
    "-enablerule:AppOffline")

# Deploy
 & "$(Get-MSWebDeployInstallPath)" $msdeployArguments

 # Wake-up IIS
$url =  $($deploySetting.destinationAppUrl)
Invoke-WebRequest $url -usebasicparsing
Start-Sleep -s 5
Invoke-WebRequest $url -usebasicparsing