using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using MongoDbCRUD.App_Start;
using MongoDB.Driver;
using MongoDbCRUD.Models;
using MongoDbCRUD.Controllers;
using System.Security; 

namespace MongoDbCRUD.Controllers
{
    public class ProductController : Controller
    {
        private MongoDBContext dbcontext;
        private IMongoCollection<ProductModel> productCollection;

        private IMongoCollection<RegistrationModel> registerCollection;

        public ProductController()
        {
            dbcontext = new MongoDBContext();
            productCollection = dbcontext.database.GetCollection<ProductModel>("product");

            registerCollection = dbcontext.database.GetCollection<RegistrationModel>("student");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegistrationModel students)
        {
            try
            {
                if (ModelState.IsValid)
                {   //  Db 

                    string pass = students.Password;
                    string password = Helper.EncodePasswordMd5(pass)+ "THis is the password";
                    students.Password = (string)password;


                    registerCollection.InsertOne(students);
                }
                // return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product
        public ActionResult Index()
        {
            List<ProductModel> products = productCollection.AsQueryable<ProductModel>().ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductModel>().SingleOrDefault(x=>x.Id==productId);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            //return View("Create");
            return View();
        }

        // POST: Product/Create
        /*    [HttpPost]
            public ActionResult Create(ProductModel product)
            {

                try
                {
                    if (ModelState.IsValid)
                    {   //  Db is updated from here boiyee
                        productCollection.InsertOne(product);
                    }
                    // return RedirectToAction("Index");
                    return View();  
                }
                catch
                {
                    return View();
                }
            } */

        [HttpPost]
        public ActionResult Create(ProductModel product)
        {

            try
            {
                if (ModelState.IsValid)
                {   //  Db is updated from here boiyee
                 
                    string pass = product.Password;
                    string password = Helper.EncodePasswordMd5(pass);
                    product.Password = (string)password;
                    

                    productCollection.InsertOne(product);
                }
                // return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductModel>().SingleOrDefault(x => x.Id == productId);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ProductModel product)
        {
            try
            {
                 var filter = Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(id));
                 var update = Builders<ProductModel>.Update.Set("ProductName", product.ProductName)
                    .Set("ProductDescription", product.ProductDescription)
                    .Set("Quantity", product.Quantity);

                var result = productCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductModel>().SingleOrDefault(x => x.Id == productId);

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                productCollection.DeleteOne(Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
