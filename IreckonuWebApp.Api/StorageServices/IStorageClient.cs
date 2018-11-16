using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.StorageServices
{
    public interface IStorageClient
    {
        IMongoDatabase GetDatabase(string dBNAME);
    }
}
