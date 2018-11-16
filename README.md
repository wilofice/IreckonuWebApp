# IreckonuWebApp 

## Requirements:
-C# 
-WEB API 2
-.NET CORE 2
-Autofac Nuget Packages and Autofac extension for ASP.NET Core Web API
-Service API versioning library for Microsoft ASP.NET Core 2.3.0
-Azure Service Fabric Tools for Visual Studio
-Service Fabric Local Cluster
-Service Fabric Explorer
-ReactJs

## Instructions to Run solution
-Open solution in Visual Studio (with Admin privileges)
-Install/Update Nuget Package for solutions
-Launch Service Fabric Cluster: set Cluster Mode (default: 1 local Node)
-Launch Service Fabric Explorer
-Launch Mongo DB Server
-Publish the project IreckonuWebApp
-Go to http://localhost:8412
-Import new data and visualize them

## Design
### Web API
- Our API contain a main controller OrderController with two methods GET and POST
