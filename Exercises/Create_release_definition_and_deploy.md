# Create release definition and deploy

* Branching policy for Check for comment resolution
* Build policy gated build
* Create develop branch
  * Protect this branch
* Create Release definition
  * Navigate to Build and Release -> Release
  * Select Set up Release or + Create Release Definition
  * Select Empty template (Empty Process) for Environment 1 ()
  * Click on 1 phase, 0 task under Environment 1
  * Select + on Agent phase and add Command Line task
    * Paste this into Tool:
'''
"C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe"
'''
    * Paste this into Arguments:
'''
-source:package='$(System.DefaultWorkingDirectory)/Master CI Build/drop/WebApp.zip' -dest:auto,ComputerName='https://$(SiteName).scm.azurewebsites.net/msdeploy.axd?site=$(SiteName)',UserName='$$(SiteName)',Password='$(Pass)',IncludeAcls='False',AuthType='Basic' -verb:sync -enablerule:AppOffline -enableRule:DoNotDeleteRule -retryAttempts:20 -AllowUntrusted -setParam:'IIS Web Application Name'='$(SiteName)' -verbose
'''
      * Add Variables
      * Add variable named SiteName and its value is the same as your Azure App Service Name
      * Add variable named Pass with the value from the publish profile of your Azure App Service
      * Lock the Pass variable to make it secret
    * Add artifact
      * Source Type: Build
      * Project: YourProjectName
      * Source: Master CI Build
      * Click on Add
      * Save definition
* Create a Release and deploy to Environment 1
  * Navigate to Releases
  * Select New Release Definition that you've just created
Select +Release
Create new release for New Release Definition
* Deploy release and passes
* Change files and CI and CD
  * Click on the lightning symbol
  * Enable Continuous deployment trigger for master branch
  * Commit another change to develop branch and submit and complete pull request
  * See new changes automated
  * Observe that Master CI Build has started after completing pull request
* Create Environment 2
  * Use ~higher
  * Update user and password
  * Add another SiteName and Pass variables to the release definition but now specify the scope of the variable to the appropriate environment
  * Change from Scope: Release->Environment 1 for SiteName(1)/Pass(1)
  * And Scope: Release->Environment 2 for SiteName(2)/Pass(2)
* Create another new release for 2 environments
  * Both environments should pass