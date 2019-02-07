using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbCRUD.Models
{
    public class RegistrationModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, MinimumLength = 3)]
        [BsonElement("FirstName")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Second Name is required")]
        [StringLength(60, MinimumLength = 3)]
        [BsonElement("SecondName")]
        public string SecondName { get; set; }



        [Required(ErrorMessage = "Desc is required")]
        [StringLength(30)]
        [BsonElement("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is needed")]
        [BsonElement("Password")]
        public string Password { get; set; }

    }
}