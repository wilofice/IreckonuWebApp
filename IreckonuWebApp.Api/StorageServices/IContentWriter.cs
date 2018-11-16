using IreckonuWebApp.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.StorageServices
{
    public interface IContentWriter
    {
        Task WriteContentToJsonFileAsync<T>(IMongoCollection<T> mongoCollection, string outputFileName);
    }
}
