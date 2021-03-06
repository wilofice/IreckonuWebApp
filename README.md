# IreckonuWebApp #

Project realized by ALAHASSA Genereux

## Requirements: ##
- C# 
- WEB API 2
- .NET CORE 2
- Mongo DB
- Autofac and Autofac extension for ASP.NET Core Web API
- Newtonsoft.Json nuget package
- Service API versioning library for Microsoft ASP.NET Core 2.3.0
- Azure Service Fabric Tools for Visual Studio
- Service Fabric Local Cluster
- Service Fabric Explorer
- ReactJs

## Instructions to Run solution ##
- Open solution in Visual Studio (with Admin privileges)
- Install/Update Nuget Package for solutions
- Launch Service Fabric Cluster: set Cluster Mode (default: 1 local Node)
- Launch Service Fabric Explorer
- Launch Mongo DB Server
- Update Mongo DB connection string in Constants
- Update the "endpoint" property in ClientApp.FetchData.tsx if you modified api endpoint in ServiceManifest.xml or if you are publishing directly 
on Azure 
- Publish (or Debug) the project IreckonuWebApp (IreckonuWebApp must be as start project)
- Go to http://localhost:8412 
- Import new data and visualize 

NB: 
Solution may not run properly localy 
- if CORS policies are activated in the browser as web client will be sending cross-origin request to web api
- if NETWORK USER user doesn't have full privilege over csv files to be imported on disk and over solution folder as the process 
will need access  

## Design ##
- I create two microservices: a Web API application for the backend and a Reactjs application for the frontend

### Web API (Back end) ###
-The backend is an ASP.NET Core Stateless service 
- My  web api has a unique controller OrdersController which has two methods:
    * GetAsync which retrive all data imported from the mongo db database
    * PostAsync which insert data sent by the client and store it in the mongo db. While doing that, I also write the data in a json file called 
    "orders.json". Data received by the api is in json format which I format with the help of Newtonsoft.Json nuget package. The json sent by the client contains only one key "filesContent" which has as value a list of string, each string representing the content of one csv file imported
    by the user
- I use Autofac as a dependency injection container. I register all services and controllers in Autofac in Startup.cs. Thanks to Autofac
I don't violate the SOLID principle: Dependency inversion principle by applying the IoC pattern
- Base on the data in the csv file provided in the assignment I defined one logical model called "Order" which reprensent an order with all the necessary informations. Since I'm using a mongo database I added the necessary annotations to the model.
- The StorageService folder contains services interfaces (IContentWriter, IMongoRepository and IStorageClient) which defines methods that allows to request the mongo database and write stored data in a json file on disk
- In the Helper folder, I defined interfaces like IContentReader which parse the JSON data received by the api and return a list of orders
The Constants class contains all static variables used in all the project. 
- In AutofacModule.cs we add services in the Autofac container. Notice that StorageClient has InstancePerLifetimeScope. It is a Singleton.
- In Startup.ConfigureServices method, we configure services and build Autofac container.

### Json File ###
- When the service fabric application is deployed, the json file "orders.json" can be found in C:\SfDevCluster\Data\_App\_Node_0\IreckonuWebAppType_App36\IreckonuWebApp.ApiPkg.Code.1.0.0 . 
- The name and the emplacement of the file can be changed in the Constants class in the Web api project.
 "orders.json" contained all the data store in the mongo db database. I saved one copy of this file in this repo.

### Client (frontend) ###

- the frontend is a Reactjs application.
- the Client contain one main component FetchData which is loaded at the application startup.
- When loading, the FetchData component request the Web API to retrieve data from database.
- On the page, the client can select csv files to import. After file selection, the client read the data from the csv files and send the content to the web api via the POST method. The html  table on the page is automatically reloaded after all the data has been stored in the database.

## Things that can be improved ##
- Exception Handling
- API HTTP Status return code
- Separation between react component for listing data and importing data
- API versioning 
- Front-end design
- Writing unit and functional tests

 
 