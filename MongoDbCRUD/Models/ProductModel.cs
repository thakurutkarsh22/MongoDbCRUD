﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbCRUD.Models
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }

        [BsonElement("Quantity")]
        public string Quantity { get; set; }

    }
}