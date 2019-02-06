using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.ComponentModel; 
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Web.Security;

namespace MongoDbCRUD.Models
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, MinimumLength = 3 , ErrorMessage = "Name is required bacche") ]
        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Desc is required")]
        [StringLength(30, ErrorMessage = "Desc is required bacche")]
        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        [BsonElement("Quantity")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).")]
        [MembershipPassword(
                 MinRequiredNonAlphanumericCharacters = 1,
                 MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
                 ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
                 MinRequiredPasswordLength = 6
                   )]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [BsonElement("Password")]
        public string Password { get; set; }

    }
}