ContactInformation 
This UI - provides MVC architecture that consume Web API.


ContactInformationService
This API — MyMDB — provides endpoints that perform CRUD operations on a database of contact information.

It is written in ASP.NET Core using EF Core and SQL Server.

The aim of the article is to show the generic repository pattern with asynchronous methods.

Folder structure:
Models: Add Model Classes. eg. Contact
Data: Base Interfaces, DB Context, Generic Repository.
Controller: Generic API Controllers eg. ContactsController.
Migration: EF migration to database.



Steps To DO before run application:
Creating Database using Migrations:
Open Tools -> NuGet Package Manager > Package Manager Console(PMC) and run the following commands in the PMC:
Add-Migration Initial
Update-Database


