using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.Helpers
{
    public class Constants
    {
        public static readonly string ORDERS_COLLECTION_NAME = "OrdersList";
        public static readonly string CONNECTION_STRING = "mongodb://localhost:27017";
        public static readonly string DBNAME = "IruTest";
        public static readonly string JSON_FILE_NAME = "orders.json";
    }
}
