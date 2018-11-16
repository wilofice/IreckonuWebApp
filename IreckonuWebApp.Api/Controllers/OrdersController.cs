using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IreckonuWebApp.Api.Helpers;
using IreckonuWebApp.Api.Models;
using IreckonuWebApp.Api.StorageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IreckonuWebApp.Api.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Orders")]
    public class OrdersController : Controller
    {
        private readonly IMongoRepository<Order> mongoRepository;
        private readonly IContentReader contentReader;

        public OrdersController(IMongoRepository<Order> mongoRepository, IContentReader contentReader)
        {
            this.mongoRepository = mongoRepository;
            this.contentReader = contentReader;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAsync()
        {
            var orders = await mongoRepository.GetAllAsync();
            orders.OrderByDescending(o => o.Timestamp);
            return orders;
        }

        // POST api/Orders
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]JObject json)
        {
            var orders = contentReader.ReadContent(json);
            await mongoRepository.InsertMany(orders);
            return StatusCode(200);
        }

    }
}
