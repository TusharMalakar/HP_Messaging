# This application built with "netcoreapp3.1" Framework, including 
1. "AutoMapper 5.0.2", 
2. "Microsoft.AspNetCore.SpaServices.Extensions 3.1.0"
3. "Microsoft.EntityFrameworkCore 3.1.0"
4. "Microsoft.EntityFrameworkCore.SqlServer  3.1.0"
5. "Microsoft.EntityFrameworkCore.Tools 3.1.0".

# 
# Steps to run this application, 
       1. You need to install  Visual Studio , SQL Server and  (latest) Node.Js 
       2. When you are done with installation, build the solution by right clicking and hitting 'build' option.
       3. Publish the database project to your local database server.
       4. Build 'ClientApp': Run "npm install" using the terminal in the 'ClientApp' path. 
       5. Finally, hit "IIS Express" to run the application.



#
#
# DB Migration Script
1. PM> Remove-Migration
2. PM> add-migration Init;
3. PM> update-database
