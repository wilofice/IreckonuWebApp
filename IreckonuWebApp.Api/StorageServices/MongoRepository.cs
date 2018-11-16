using IreckonuWebApp.Api.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.StorageServices
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly IStorageClient storageClient;
        private readonly IContentWriter contentWriter;
        private readonly string collectionName;
        public MongoRepository(IStorageClient storageClient, IContentWriter contentWriter, string collectionName)
        {
            this.storageClient = storageClient;
            this.collectionName = collectionName;
            this.contentWriter = contentWriter;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var collection = storageClient.GetDatabase(Constants.DBNAME).GetCollection<T>(collectionName);
            return await collection.Find(_ => true).ToListAsync();
        }


        public async Task InsertMany(IEnumerable<T> t)
        {
            var collection = storageClient.GetDatabase(Constants.DBNAME).GetCollection<T>(collectionName);
            await collection.InsertManyAsync(t);
            await contentWriter.WriteContentToJsonFileAsync(collection, Constants.JSON_FILE_NAME);
        }


    }
}
