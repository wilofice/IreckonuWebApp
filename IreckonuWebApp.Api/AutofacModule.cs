using Autofac;
using IreckonuWebApp.Api.StorageServices;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IreckonuWebApp.Api.Models;
using IreckonuWebApp.Api.Helpers;

namespace IreckonuWebApp.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<StorageClient>().As<IStorageClient>();
            builder.RegisterType<ContentReader>().As<IContentReader>();
            builder.RegisterType<ContentWriter>().As<IContentWriter>();
            builder.RegisterType<MongoRepository<Order>>().As<IMongoRepository<Order>>().WithParameter("collectionName", Constants.ORDERS_COLLECTION_NAME);
        }
    }
}
