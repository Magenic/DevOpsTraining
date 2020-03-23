# Create task groups for reusability

* Navigate to Master CI Build definition -> Tasks
* Create Base Build task group
  * Multi-select the following tasks
    * Use Nuget
    * NuGet restore
    * Build Web App
    * Build Test Automation
    * Test Assemblies
  * Right click and select Create task group
  * Name it Base Group and Create
  * Save
* Clean up Gated Build definition tasks
  * Navigate to Gated Build definition
  * Add your newly create task group, Base Build
  * Delete the old tasks since they are compiled into a Base Build task group
  * Save
* Create Deployment task group
  * Navigate to New Release Definition and edit
  * Right click command line task -> Create task group
  * Name it Deployment and Create
  * Fix the SiteName and Pass values to reference the variables you've created