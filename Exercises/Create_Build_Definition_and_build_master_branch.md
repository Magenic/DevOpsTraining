# Create build definition for Master CI Build

* Navigate to Build and Release -> Builds
* Select +New to create a new build definition
* Select ASP.NET Core (.NET Framework) template and Apply
* Setting up Build Definition for master branch
  * Rename to Master CI Build
  * The name must match the name used in the msdeploy command line later in the course.
  * Build process -> Agent queue: Select Hosted VS2017
  * Use NuGut 4.3.0 unchanged
  * NuGet restore
  * Clone Build solution: Right click -> Clone task
  * Rename Build solution task -> Build Web App
  * Unlink solution and modify field to WebApp\**.*sln
  * Rename Build solution copy task -> Build Automation
  * Clear MSBuild Arguments field in Build Automation task
  * Unlink Solution and modify field to TestAutomation\**.*sln
  * Modify Test assemblies field to:
```
WebApp\**\$(BuildConfiguration)\*test*.dll
!**\obj\**
```
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
* Create develop branch based on master
  * Navigate to Branches
  * Select New Branch
  * Name: develop
  * Based on: master
  * Select Create branch
  * Navigate to develop's  branch policies and enable Protect this branch
    * Check for comment resolution set to Optional
  * Navigate to Version Control and expand repositories and set develop as default branch
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