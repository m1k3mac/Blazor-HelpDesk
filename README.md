# Blazor-HelpDesk
An open source HelpDesk system written in Blazor Server side.

Requires SQL Server or SQL Server Express
(1) Configure the database connection string in appsettings.json file.
(2) In the Package Manager Console type Update-Database (this will scaffold the seeded data and setup the database). Wait until it shows 'Done.'
(3) Run the project and register as a new user.
(4) The next page shows Register Confirmation. Unless you have your smtp details setup this step would normally send you an email to confirm your address and activate your account. Do this manually for now by editing the table AspNetUsers in the newly created HelpDesk database. Change fields EmailConfirmed = true and LockoutEnabled = false. Confirming your email by clicking the link does this step for you.
(5) Stop and start the project again and login.
(6) Complete your details and click ok. The next page will show that your details have been confirmed. If this was a regular user then the admin would have to go into the User Management
section of the website and enable the newly created user. In this case you are admin but cannot confirm yourself. Stop the project and uncomment this section in the index.razor page.
Uncomment the lines so the section looks like this below:

// ------------------------------------------------------------------------------------------------------------
        // -- Check if 'Administrator' and 'Support' roles exist, if not then create them. Usually for first time setup

        bool adminExists = await userRoleService.DoesRoleExistAsync("Administrators");
        bool supportExists = await userRoleService.DoesRoleExistAsync("Support");
        if (!adminExists)
            await userRoleService.CreateNewRoleAsync("Administrators");
        if (!supportExists)
            await userRoleService.CreateNewRoleAsync("Support");
        
        //--For manually adding a user to Role. Usually used at Dev time to add admin role.
        await userRoleService.AddUserToRoleAsync(currentUser.Identity.Name, "Administrators");        

 // ------------------------------------------------------------------------------------------------------------

(7) Start the project and now you will be able to login. Once logged in stop the project and login a second time. 
(8) Comment out the section above again - important!
(9) Edit the URL in the EditTicket.razor page to your URL (line number 286)
(10) Edit the StaticData.cs file in the Data folder in the project. Enter your company and smtp details here. 
Thats it!
Company logo can be changed by replacing the file logo_placeholder.png under wwwroot\images in the solution explorer.

NB: The dashboard will not work until you have created and closed some tickets. It needs some data to display statistics.

NuGet Dependencies:
DevExpress.Blazor version v20.1.4 (used for Dashboard Donut Chart control - free component)
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.Identity.UI
Microsoft.AspNetCore.FrameworkCore.SqlServer
Microsoft.AspNetCore.FrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGeneration.Design
