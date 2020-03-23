# Create 2 Azure Web App Services
## If you haven't setup Azure
* Go to https://my.visualstudio.com/ and sign in as your msdn account (select personal not work/school)
* Activate Azure $50 (or $150) monthly credit
## Once you have Azure setup
* Go to the Azure portal: https://portal.azure.com/
* Create a Web App
  * Navigate to: Create a resource -> Web -> Web App 
  * Subscription -> Visual Studio Professional (or Enterprise)
  * Create new Resource Group -> name with Lower/Higher
  * App name -> name with Lower/Higher - *suggest making this the same name as your resource group*
  * Runtime stack -> .Net Core 3.1 (LTS)
  * App Service plan -> Create new 
    * Change size -> Dev/Test -> F1 Free $0.00 -> Apply
    * or Select existing Free plan if one already exists
  * Go to Review + create tab
  * Create
  * Repeat and create a 2nd Web App service
* Navigate to the Web Apps you've created and view Overview
* Select Get publish profile and save them for later