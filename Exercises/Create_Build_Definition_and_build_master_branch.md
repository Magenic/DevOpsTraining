# Create build definition for Master CI Build
* Navigate to your project in Azure DevOps
* Navigate to Pipelines -> Pipelines
* Select "New pipeline"
* Select "Use the classic editor" - it is down at the bottom and a little hard to notice
  * Make sure you have your project and repository selected as well as the Master branch
  * Continue
  * Select ASP.NET Core (.NET Framework) template and Apply
* Setting up Build Definition for master branch
  * Rename to Master CI Build
  * Agent Specification: Windows 2019
  * In the agent job
    * Clone Build solution: Right click -> Clone task
    * Rename Build solution task -> Build Web App
    * Unlink solution and modify field to WebApp\**.*sln
    * Rename Build solution copy task -> Build Automation
    * Clear MSBuild Arguments field in Build Automation task
    * Unlink Solution and modify field to TestAutomation\**.*sln
    * Modify Test assemblies field to: ```WebApp\**\$(BuildConfiguration)\*test*.dll
  !**\obj\**```
    * Add new task: Utility -> Copy Task
    * Source Folder: TestAutomation/DemoTests/Tests/bin/$(BuildConfiguration)
    * Contents: **\*
    * Target Folder: $(build.artifactstagingdirectory)/Automation
    * Save
      * Queue Build
* Queue Build and build passes
* Enable CI Trigger
  * Edit build definition
  * Triggers tab -> Enable Continuous Integration Trigger status
  * Type: Include
  * Branch specification: master
* Save definition
* Turn on Branch Policies
  * Enable Check for comment resolution - Required
* Create Gated Build
  * Right click -> Clone current build
  * Rename to Master Gated Build
  * Remove Publish symbols path
  * Remove Publish Artifact
  * Disable CI for Gated Build
  * Update master branch policy and add the Master Gated Build as a build policy
* Test Gated Build by submitting pull request
  * Make an edit in a file and commit it
  * Request a pull request and observe the Gated Build kicks off
  * Complete pull request and observe the Master CI build kicks off