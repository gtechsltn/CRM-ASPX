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
+ Bootstrap.Datepicker
+ Moment.js

# How to debug
+ Git clone: https://github.com/gtechsltn/CRM-ASPX/
+ Open SSMS and
  + Create DB: **CRMS**
  + Run DB Script: ..\databases\DBScripts.sql
+ Open Visual Studio and
  + Change Connection String: ....\src\WebApplication1\web.config
  + Open solution file: ..\src\WebApplication1.sln
  + Build/Rebuild solution successful
+ F5 to debug
+ Login URL: /Account/Login
  + User: **Admin**
  + Password: **Abc@123$**

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

## SQL UNIQUE
+ Bảng User không thể có 2 bản ghi trùng UserName
+ https://www.w3schools.com/sql/sql_unique.asp

## SQL FOREIGN KEY
+ Trường Owner của bảng Customer chính là UserName của bảng User
+ https://www.w3schools.com/sql/sql_foreignkey.asp

## AutoMapper
+ For .NET Core
+ https://github.com/gtechsltn/Automapper.Sample
+ For .NET Framework
+ https://github.com/gtechsltn/SocialGoal
+ https://github.com/gtechsltn/GigHub

## Error Handling
+ https://stackify.com/aspnet-mvc-error-handling/
+ https://www.c-sharpcorner.com/UploadFile/mscratnesh/exception-handling-in-mvc/

## Bootstrap Modal
+ https://laracasts.com/discuss/channels/laravel/have-bootstrap-modal-open-after-ajax-loads-data
+ https://stackoverflow.com/questions/2537741/how-to-render-partial-view-into-a-string
+ https://codexworld.com/bootstrap-modal-dynamic-content-jquery-ajax-php-mysql/
+ https://www.aspdotnet-suresh.com/2016/07/jquery-show-bootstrap-modal-popup-on-button-click-with-example.html
+ https://aspsnippets.com/Articles/MVC-Partial-View-String-Render-Return-Partial-View-as-String-from-Controller-in-ASPNet-MVC.aspx

## Menu Navigation
+ https://codepen.io/bootstrapped/pen/KwYGwq

## Login and Return Url
+ https://www.aspsnippets.com/Articles/Forms-Authentication-Login-with-ReturnUrl-in-ASPNet-MVC.aspx
+ https://www.devargument.com/postdetails/11041/how-to-implement-return-url-functionality-for-login-page-in-aspnet-mvc-
+ https://stackoverflow.com/questions/20123612/how-am-i-supposed-to-use-returnurl-viewbag-returnurl-in-mvc-4

## Logout issue
+ Try with link: ~/Account/Login?ReturnUrl=/Account/Logout
+ [Beginning ASP.NET MVC 4](https://github.com/Apress/beg-asp.net-mvc-4)
+ [Working With Html.BeginForm() and Ajax.BeginForm() in MVC 3](https://www.c-sharpcorner.com/UploadFile/3d39b4/working-with-html-beginform-and-ajax-beginform-in-mvc-3/)

## Client-Side Validation
+ https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/adding-validation
+ https://www.aspsnippets.com/Articles/Enable-Client-Side-validation-in-ASPNet-MVC.aspx
+ [How to Enable and Disable Client-Side Validation in MVC](https://www.dotnettricks.com/learn/mvc/how-to-enable-and-disable-client-side-validation-in-mvc)
+ https://www.freecodespot.com/blog/ajax-model-validation-in-asp-net/
+ https://www.c-sharpcorner.com/article/asp-net-mvc5-jquery-form-validator/

## Modal Bootstrap Hide Not Working
+ https://stackoverflow.com/questions/23677765/bootstrap-modal-hide-is-not-working
+ https://stackoverflow.com/questions/10466129/how-to-hide-bootstrap-modal-with-javascript/29560331#29560331
```
$('#myModal').hide();
```
+ =>
```
$('#myModal').hide();
$('.modal-backdrop').hide();
```

## Bootstrap Datepicker
+ https://tutorialdeep.com/bootstrap/
+ https://tutorialdeep.com/live-editor/bootstrap-datepicker-textbox-with-calendar-icon/
+ https://www.aspsnippets.com/Articles/Implement-Bootstrap-DatePicker-with-Calendar-Icon-Image.aspx