# IreckonuWebApp 

## Requirements: ##
-C# 
-WEB API 2
-.NET CORE 2
-Autofac Nuget Packages and Autofac extension for ASP.NET Core Web API
-Service API versioning library for Microsoft ASP.NET Core 2.3.0
-Azure Service Fabric Tools for Visual Studio
-Service Fabric Local Cluster
-Service Fabric Explorer
-ReactJs

## Instructions to Run solution ##
-Open solution in Visual Studio (with Admin privileges)
-Install/Update Nuget Package for solutions
-Launch Service Fabric Cluster: set Cluster Mode (default: 1 local Node)
-Launch Service Fabric Explorer
-Launch Mongo DB Server
-Update Mongo DB connection string in Constants
-Publish the project IreckonuWebApp
-Go to http://localhost:8412
-Import new data and visualize them

NB: Solution won't run properly localy 
-if CORS policies are activated in the browser as web client will be sending cross-origin request to web api
-if NETWORK USER user doesn't have full privilege over csv files to be imported on disk and over solution folder as the process 
will need access  
## Design ##
-I create two stateless service: a Web API application for the backend and a Reactjs application for the frontend

## Web API ##

- I use Autofac as a dependency injection container. I register all services and controllers in Autofac in Startup.cs. Thanks to Autofac
I don't violate the SOLID principle: Dependency inversion principle by applying the IoC pattern
-Base on the data in the csv file provided in the assignment I defined one logical model called Order which reprensent an order with all the necessary informations. Since I'm using a mongo database I added the necessary annotations to the model.  
-My  web api has a unique controller OrdersController which has two methods:
*GetAsync which retrive all data imported in the mongo db database
*PostAsync which insert data sent by the client and store it in the mongo db. While doing that, I also write the data in a json file called 
"orders.json". Data received by the api is in json format which I format with the help of Newtonsoft.Json nuget package. The json sent by the client contains only one key "filesContent" which has as value a list of string, each string representing the content of one csv file imported
by the user
-The StorageService folder contains services interfaces (IContentWriter, IMongoRepository and IStorageClient) which defines methods that allows to request the mongo database and write stored data in json files on disk
-In the Helper folder, I defined interfaces like IContentReader which parse the JSON data received by the api and return a list of orders
The Constants class contains all static variables used in all the project. 
-