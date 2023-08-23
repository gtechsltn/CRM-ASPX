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
+ Connection String in Web.config
+ https://stackoverflow.com/questions/5484771/sql-providername-in-web-config

## Logging
+ ..\Src\WebApplication1\logs\debug-appending.log
+ ..\Src\WebApplication1\logs\debug-rolling.log
+ ..\Src\WebApplication1\logs\traceroll.day.log
+ ..\Src\WebApplication1\logs\traceroll.roll.log

## Libraries
+ Log4net
+ Unity.Mvc5
+ Dapper.Contrib