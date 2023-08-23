# Tech Stack

# SRS
+ ..\requirements\NVChien_BTL.docx
+ **Role**: Admin, User
+ **User**: Admin, manh, chien (Password: **Abc@123$**)
+ **Customer**: Nguyễn Viết Mạnh

# GitHub
+ https://github.com/gtechsltn/CRM-ASPX/

# Project Plan
+ https://docs.google.com/spreadsheets/d/1eNtpyN6KS4yfSc6q8iavuXgJvzaUogWvf6YYg-S7LOQ/

## Libraries
+ Log4net
+ Unity.Mvc5
+ Dapper.Contrib
+ DataTables

# How to debug
+ Git clone: https://github.com/gtechsltn/CRM-ASPX/
+ Create DB: **CRMS**
+ Run DB Script: ..\databases\DBScripts.sql
+ Open solution: ..\src\WebApplication1.sln
+ Change Connection String: ....\src\WebApplication1\web.config
+ F5 to debug

# How to

## .Gitignore for ASP.NET MVC
+ https://gist.github.com/gtechsltn/70459cbccdfa2c66e7e54cd349527847

## SQL Server
+ **Check table exists**
+ https://stackoverflow.com/questions/167576/check-if-table-exists-in-sql-server
+ **Auto Increment with ID column**
+ https://stackoverflow.com/questions/1049625/sql-how-to-insert-row-without-auto-incrementing-a-id-column

## Encrypt/Decrypt password
+ https://qawithexperts.com/article/c-sharp/encrypt-password-decrypt-it-c-console-application-example/169

## DI in ASP.NET MVC 5
+ https://www.c-sharpcorner.com/article/dependency-injection-in-asp-net-mvc-5/

## Connection String
+ **Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True**
+ .NET Framework Data Provider for SQL Server in Connection String in web.config
+ https://stackoverflow.com/questions/5484771/sql-providername-in-web-config

## Forms Authentication
+ https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/security/authenticating-users-with-forms-authentication-cs
+ https://www.ifourtechnolab.com/blog/explain-forms-authentication-in-asp-net-mvc
+ https://dotnettutorials.net/lesson/authentication-and-authorization-in-mvc/
+ https://www.c-sharpcorner.com/article/forms-authentication-in-mvc/
+ https://dotnettutorials.net/lesson/forms-authentication-in-mvc/

## Data Annotation
+ https://www.c-sharpcorner.com/article/model-validation-using-data-annotations-in-asp-net-mvc/
+ https://www.c-sharpcorner.com/article/data-annotations-and-validation-in-mvc/

## DataTables
+ https://www.c-sharpcorner.com/article/using-jquery-datatable-with-asp-net-mvc-client-side/

## SQL Server Data Type Mappings - ADO.NET
+ https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
+ https://stackoverflow.com/questions/425389/c-sharp-equivalent-of-sql-server-datatypes

## Navbar left and right
+ https://stackoverflow.com/questions/19733447/bootstrap-navbar-with-left-center-or-right-aligned-items
+ https://www.w3schools.com/bootstrap/tryit.asp?filename=trybs_navbar_right&stacked=h

## Register and Logout function
+ https://www.aspsnippets.com/Articles/Implement-Logout-functionality-in-ASPNet-MVC.aspx
+ https://www.c-sharpcorner.com/UploadFile/raj1979/how-to-make-custom-login-register-and-logout-in-mvc-4-usin/
+ https://dev.to/skipperhoa/login-and-register-using-asp-net-mvc-5-3i0g
+ https://hiepsiit.com/detail/aspxmvc/asp-net-mvc/login-va-register

## Logging
+ ..\Src\WebApplication1\logs\debug-appending.log
+ ..\Src\WebApplication1\logs\debug-rolling.log
+ ..\Src\WebApplication1\logs\traceroll.day.log
+ ..\Src\WebApplication1\logs\traceroll.roll.log