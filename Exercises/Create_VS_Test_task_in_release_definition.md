# Create VS Test task in release definition

* Navigate to Release Definition to edit
* Setup Variables
    * Navigate to variables tab
    * Add variable named BaseUrl and its value is the same as your Azure Web App base url
    * Set scope to lower
    * Repeat for higher
* Return to pipeline tab    
* Select job/tasks from lower environment
* Add new Visual Studio Test task (lower)
    * Working Folder: ```$(System.DefaultWorkingDirectory)/Master CI Build/drop/Automation```
    * Test assemblies: ```**\*test*.dll
    !**\obj\**```
    * Search folder: ```$(System.DefaultWorkingDirectory)/Master CI Build/drop/Automation```
    * Test filter criteria: ```TestCategory=Smoke```
    * Override test run parameters: ```-SeleniumMaqs:Browser Chrome -SeleniumMaqs:WebSiteBase- $(BaseUrl)```
* Add new Visual Studio Test task (higher)
    * Same as lower but leave test filter criteria blank
 