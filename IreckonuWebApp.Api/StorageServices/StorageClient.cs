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
            client = new MongoClient(Constants.CONNECTION_STRING);
        }
        

        public IMongoDatabase GetDatabase(string name)
        {
            return client.GetDatabase(name);
        }
    }
}
