using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IreckonuWebApp.Api.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace IreckonuWebApp.Api.StorageServices
{
    public class ContentWriter : IContentWriter
    {
        public async Task WriteContentToJsonFileAsync<T>(IMongoCollection<T> mongoCollection, string outputFileName)
        {

            using (StreamWriter streamWriter = new StreamWriter(File.Open(outputFileName, System.IO.FileMode.Create)))
            {
                await mongoCollection.Find(_ => true)
                    .ForEachAsync(async (document) =>
                    {
                        using (var stringWriter = new StringWriter())
                        using (var jsonWriter = new JsonWriter(stringWriter))
                        {
                            var context = BsonSerializationContext.CreateRoot(jsonWriter);
                            mongoCollection.DocumentSerializer.Serialize(context, document);
                            var line = stringWriter.ToString();
                            await streamWriter.WriteAsync(line);
                        }
                    });
            }
        }
    }
}
