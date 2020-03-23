# Create VS Test task in release definition
Navigate to New Release Defintion to edit
Add Power Shell script task to Release Definition
Change Type to: Inline Script
Add to Arguments: $(Arguments)
Inline Script: Warning: The inline script is limited to 500 characters including all white space and CR/LF. The snippet below is longer. If you eliminate all the extra CR/LF and convert spaces to tabs, it gets down below the limit.
```
[System.Collections.ArrayList] $A = @()

foreach ($g in $args)
{
  $A.Add($g)
}

$w = 'Tests.dll.config'
$doc = (Get-Content $w) -as [Xml]

for($i=0;  $i -lt $A.Count; $i += 2)
{
    $o = $doc.configuration.MagenicMaqs.add | where {$_.Key -eq $A[$i]}
        if($o)
    {
    $o.value = $A[$i+1]
    }
}

for($i=0;  $i -lt $A.Count; $i += 2)
{
    $o = $doc.configuration.RemoteSeleniumCapsMaqs.add | where {$_.Key -eq $A[$i]}
    if($o)
    {
    $o.value = $A[$i+1]
    }
}

$doc.Save($w)
``` 

Working Folder: $(System.DefaultWorkingDirectory)/Master CI Build/drop/Automation
Add new Visual Studio Test task
Test assemblies:
```
**\*test*.dll
!**\obj\**
```

Search folder: $(System.DefaultWorkingDirectory)/Master CI Build/drop/Automation
Test filter criteria: TestCategory=Smoke
Navigate to Variables
Add new variable Arguments with value:
Browser PhantomJS WebSiteBase http://$(SiteName).azurewebsites.net
 