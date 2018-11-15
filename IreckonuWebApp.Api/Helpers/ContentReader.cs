using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IreckonuWebApp.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IreckonuWebApp.Api.Helpers
{
    public class ContentReader : IContentReader
    {
        public List<Order> ReadContent(JObject json)
        {
            var orders = new List<Order>();
            var filesContent = JsonConvert.DeserializeObject<List<string>>(json["filesContent"].ToString());
            foreach(var fileContent in filesContent)
            {
                var lines = fileContent.Split(new[] { Environment.NewLine },StringSplitOptions.None).Skip(1);
                foreach(var line in lines)
                {
                    orders.Add(CreateOrder(line));
                }

            }
            return orders;
        }

        private Order CreateOrder(string csvline)
        {
            string[] values = csvline.Split(',');
            var order = new Order
            {
                Key = values[0],
                ArtikelCode = values[1],
                ColorCode = values[2],
                Desciption = values[3],
                Price = Convert.ToInt64(values[4]),
                DiscountPrice = Convert.ToInt64(values[5]),
                DeliveredIn = values[6],
                Q1 = values[7],
                Size = values[8],
                Color = values[9],
                Timestamp = DateTime.Now
            };
            return order;
        }

    }
}
