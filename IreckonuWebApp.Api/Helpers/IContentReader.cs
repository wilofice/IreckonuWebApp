using IreckonuWebApp.Api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.Helpers
{
    public interface IContentReader
    {
        List<Order> ReadContent(JObject json);
    }
}
