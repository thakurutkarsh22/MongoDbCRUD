using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.ComponentModel; 
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbCRUD.Models
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, MinimumLength = 3)]
        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Desc is required")]
        [StringLength(30)]
        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        [BsonElement("Quantity")]
        public string Quantity { get; set; }

    }
}