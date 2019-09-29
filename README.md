# SittingPlan 

This is a .NET Web API project here only back-end part. In this project code-based configuration implemented with using Entity Framework 6. 

## Description 

Main purpose of project, users can know each other easily and ease of communication between them with given information. 
SittingPlan helps employees to find out floor plan with all desks,chairs with person information on website. Users able to 
create their own floor plan with it. In Adittion , users will change sitting plan .

API allows users to post and get transactions like lists of entites or create them with relationships. Relations prepared with code first between entities. Relations were made
with Fluent APIs and Data Annotations.

## Running locally

Clone this project or download it. After that you should configure your own EntityFramework connection strings in SittingPlan.Web
Web.config and also SittingPlan.Data App.Config. 

```
  <connectionStrings>
    <add name="SittingPlan" connectionString="Application Name=SittingPlan; server=SQLTEST; database=SittingPlan; uid=SittingPlanUser;password=123456; Pooling=false" providerName="System.Data.SqlClient" />
  </connectionStrings>

```

On the side you can update your database typing "update-database 
on "Package Manager Console" (Tools>NuGet Packet Manager). 
Front-End side of project https://github.com/mrtdmrmrt/VueJs-SittingPlan.

