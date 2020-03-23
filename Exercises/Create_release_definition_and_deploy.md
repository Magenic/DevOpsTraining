# Create release definition and deploy


* Branching policy for Check for comment resolution
* Build policy gated build
* Create develop branch
* Upload publish settings files
  * Navigate to Pipelines -> Library -> Secure files
  * Select + Secure file
  * Add your publishing profile
* Create Release definition
  * Navigate to Pipeline -> Release
  * Select + New -> New Release Pipeline
  * Select Empty template (Empty Process)
  * Rename the stage lower
  * Add artifact
    * Source Type: Build
    * Project: YourProjectName
    * Source: Master CI Build
    * Source alias: _Master-CI
    * Click on Add
* Add stage tasks
  * Click on 1 job, 0 task under the lower environment 
  * Select + on Agent job and add Download secure file
    * Have secure file point to the publishing profile for the lower environment 
  * Select + on Agent job and add PowerShell script task to Release Definition
    * Change Script Path to: 
    ``` $(System.DefaultWorkingDirectory)/_Master-CI/drop/DeploymentScripts/MSDep.ps1```  
    * Add Arguments:
    ```-zip '$(System.DefaultWorkingDirectory)\_Master-CI\drop\TestSite.zip' -publish '$(Agent.TempDirectory)\LOWER.PublishSettings'```
* Save and Create release to verify the release works
* Edit the Release pipeline
* Enable CD
  * Click on the lightning symbol attached to the master artifact
  * Enable Continuous deployment trigger for master branch
* Hover over the lower environment stage and click +
* Add stage tasks as you did for the lower environment but use the higher publish settings file instead. 
* Add approval gate
  * Click on the lighting bolt on your hire environment stage
  * Enable Pre-deployment approvals
  * Add yourself as an approver
* Save and Create release to verify the release works
  * Make sure changes automatically go to lower and you are prompted to approve changes to higher


