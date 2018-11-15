using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IreckonuWebApp.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        public Order() { }

        [BsonConstructor]
        public Order(Guid id, string key, string artikelCode, string colorCode, string desciption, long price, long discountPrice, string deliveredIn, string q1, string size, string color, DateTime timestamp)
        {
            Id = id;
            Key = key;
            ArtikelCode = artikelCode;
            ColorCode = colorCode;
            Desciption = desciption;
            Price = price;
            DiscountPrice = discountPrice;
            DeliveredIn = deliveredIn;
            Q1 = q1;
            Size = size;
            Color = color;
            Timestamp = timestamp;
        }

        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        [BsonElement("Key")]
        public string Key { get; set; }
        [BsonElement("ArtikelCode")]
        public string ArtikelCode { get; set; }
        [BsonElement("ColorCode")]
        public string ColorCode { get; set; }
        [BsonElement("Desciption")]
        public string Desciption { get; set; }
        [BsonElement("Price")]
        public long Price { get; set; }
        [BsonElement("DiscountPrice")]
        public long DiscountPrice { get; set; }
        [BsonElement("DeliveredIn")]
        public string DeliveredIn { get; set; }
        [BsonElement("Q1")]
        public string Q1 { get; set; }
        [BsonElement("Size")]
        public string Size { get; set; }
        [BsonElement("Color")]
        public string Color { get; set; }
        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    } 
}
