using IreckonuWebApp.Api.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.StorageServices
{
    public class StorageClient : IStorageClient
    {
        private readonly IMongoClient client;

        public StorageClient()
        {
            //var settings = GetMongoClientSettings();

            client = new MongoClient(Constants.CONNECTION_STRING);
        }
        
        //private MongoClientSettings GetMongoClientSettings()
        //{
        //    var settings = new MongoClientSettings
        //    {
        //        Server = new MongoServerAddress(host, 10255),
        //        UseSsl = true,
        //        SslSettings = new SslSettings()
        //    };
        //    settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

        //    MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
        //    MongoIdentityEvidence evidence = new PasswordEvidence(password);

        //    settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);
        //    return settings;
        //}

        public IClientSessionHandle GetSession()
        {
            return client.StartSession();
        }


        public IMongoDatabase GetDatabase(string name)
        {
            return client.GetDatabase(name);
        }
    }
}
