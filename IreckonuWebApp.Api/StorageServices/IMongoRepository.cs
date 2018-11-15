using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IreckonuWebApp.Api.Models;

namespace IreckonuWebApp.Api.StorageServices
{
    public interface IMongoRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertMany(IEnumerable<T> t);
    }
}
