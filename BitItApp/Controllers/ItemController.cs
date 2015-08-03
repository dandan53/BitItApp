using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BitItApp.Models;

namespace BitItApp.Controllers
{
    public class ItemController : ApiController
    {
        //private List<Item> Items;

         // GET api/Items
         public IEnumerable<Item> Get(int categoryId = 0, int subCategoryId = 1000)
         {
             List<Item> Items = DAL.Instance.GetItems();
             
             IEnumerable<Item> filteredItems = null;
             
             if (categoryId == 0)
             {
                 filteredItems = Items;
             }
             else if (subCategoryId == 1000)
             {
                 filteredItems = Items.Where(i => i.CategoryId == categoryId);
             }
             else
             {
                 filteredItems = Items.Where(i => i.CategoryId == categoryId && i.SubCategoryId == subCategoryId);             
             }
             
             return filteredItems;
         }

        //// GET api/Items
        // public IEnumerable<Item> Get(string q = null, string sort = null, bool desc = false,
        //                                                 int? limit = null, int offset = 0)
        // {
        //     return Items;
        // }

      
        // GET api/Todo/5
        public Item Get(int id)
        {
            Item item = DAL.Instance.GetItem(id);
            return item;
            
            //Item item1 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 1,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 1
            //};

            //return item1;
        }

        // DELETE api/Item/5
        public HttpResponseMessage Delete(int id)
        {
           return Request.CreateResponse(HttpStatusCode.OK, new Item());
        }

        // POST api/Item
        public HttpResponseMessage PostTodo(Item item)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(uriString: Url.Link("DefaultApi", new { id = item.Id }));

            DAL.Instance.AddItem(item);

            return response;   
        }

        // PUT api/Item/5
        public HttpResponseMessage PutTodo(int id, Item item)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private ItemController()
        {
        }

        //private ItemController()
        //{
        //    Item item1 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "l.s.d",
        //        ProductId = 1,
        //        SubCategory = "טלויזיה",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item1);

        //    Item item2 = new Item()
        //    {
        //        Amount = 12,
        //        Category = "כלי עבודה",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(2),
        //        FirstPrice = 10,
        //        Id = 2,
        //        Product = "מטאטא",
        //        ProductId = 2,
        //        SubCategory = "חומרי עבודה",
        //        SubCategoryId = 101
        //    };

        //    Items.Add(item2);

        //    Item item3 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "מאוורר קיר",
        //        ProductId = 1,
        //        SubCategory = "מאוורר",
        //        SubCategoryId = 200
        //    };

        //    Items.Add(item3);

        //    Item item4 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "ריהוט",
        //        CategoryId = 3,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "ארון מחשב",
        //        ProductId = 1,
        //        SubCategory = "ארונות",
        //        SubCategoryId = 300
        //    };

        //    Items.Add(item4);

        //    Item item5 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item5);

        //    Item item6 = new Item()
        //    {
        //        Amount = 12,
        //        Category = "ריהוט",
        //        CategoryId = 3,
        //        DueDate = DateTime.Now.AddDays(2),
        //        FirstPrice = 10,
        //        Id = 2,
        //        Product = "כסאות",
        //        ProductId = 2,
        //        SubCategory = "כסאות",
        //        SubCategoryId = 301
        //    };

        //    Items.Add(item6);

        //    Item item7 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "מזגן קטן",
        //        ProductId = 1,
        //        SubCategory = "מזגן",
        //        SubCategoryId = 201
        //    };

        //    Items.Add(item7);

        //    Item item8 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item8);

        //    Item item9 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 111,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item9);

        //    Item item10 = new Item()
        //    {
        //        Amount = 12,
        //        Category = "ציוד משרדי",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(2),
        //        FirstPrice = 10,
        //        Id = 2,
        //        Product = "דפים למדפסת",
        //        ProductId = 2,
        //        SubCategory = "דפים",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item10);

        //    Item item11 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item11);

        //    Item item12 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item12);

        //    Item item13 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item13);

        //    Item item14 = new Item()
        //    {
        //        Amount = 12,
        //        Category = "ציוד משרדי",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(2),
        //        FirstPrice = 10,
        //        Id = 2,
        //        Product = "דפים למדפסת",
        //        ProductId = 2,
        //        SubCategory = "דפים",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item14);

        //    Item item15 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 202
        //    };

        //    Items.Add(item15);

        //    Item item16 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item16);

        //    Item item17 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item17);

        //    Item item18 = new Item()
        //    {
        //        Amount = 12,
        //        Category = "ציוד משרדי",
        //        CategoryId = 2,
        //        DueDate = DateTime.Now.AddDays(2),
        //        FirstPrice = 10,
        //        Id = 2,
        //        Product = "דפים למדפסת",
        //        ProductId = 2,
        //        SubCategory = "דפים",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item18);

        //    Item item19 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item19);

        //    Item item20 = new Item()
        //    {
        //        Amount = 10,
        //        Category = "מוצרי חשמל",
        //        CategoryId = 1,
        //        DueDate = DateTime.Now.AddDays(1),
        //        FirstPrice = 100,
        //        Id = 1,
        //        Product = "טלויזיה",
        //        ProductId = 1,
        //        SubCategory = "טלויזיות",
        //        SubCategoryId = 1
        //    };

        //    Items.Add(item20);

        //    //Item item21 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item21);

        //    //Item item22 = new Item()
        //    //{
        //    //    Amount = 12,
        //    //    Category = "ציוד משרדי",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(2),
        //    //    FirstPrice = 10,
        //    //    Id = 2,
        //    //    Product = "דפים למדפסת",
        //    //    ProductId = 2,
        //    //    SubCategory = "דפים",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item22);

        //    //Item item23 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item23);

        //    //Item item24 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item24);

        //    //Item item25 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item25);

        //    //Item item26 = new Item()
        //    //{
        //    //    Amount = 12,
        //    //    Category = "ציוד משרדי",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(2),
        //    //    FirstPrice = 10,
        //    //    Id = 2,
        //    //    Product = "דפים למדפסת",
        //    //    ProductId = 2,
        //    //    SubCategory = "דפים",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item26);

        //    //Item item27 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item27);

        //    //Item item28 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item28);

        //    //Item item29 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item29);

        //    //Item item30 = new Item()
        //    //{
        //    //    Amount = 12,
        //    //    Category = "ציוד משרדי",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(2),
        //    //    FirstPrice = 10,
        //    //    Id = 2,
        //    //    Product = "דפים למדפסת",
        //    //    ProductId = 2,
        //    //    SubCategory = "דפים",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item30);

        //    //Item item31 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item31);

        //    //Item item32 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item32);

        //    //Item item33 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "מוצרי חשמל",
        //    //    CategoryId = 1,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "טלויזיה",
        //    //    ProductId = 1,
        //    //    SubCategory = "טלויזיות",
        //    //    SubCategoryId = 1
        //    //};

        //    //Items.Add(item33);

        //    //Items = new List<Item>();
        //    //Item item70 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "category 1",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "message 1",
        //    //    ProductId = 1,
        //    //    SubCategory = "sub cat 1",
        //    //    SubCategoryId = 201,
        //    //    Text = "like a new product"
        //    //};

        //    //Items.Add(item70);

        //    //Item item71 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "category 1",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "message 1",
        //    //    ProductId = 1,
        //    //    SubCategory = "sub cat 1",
        //    //    SubCategoryId = 201,
        //    //    Text = "Only in black"
        //    //};

        //    //Items.Add(item71);

        //    //Item item72 = new Item()
        //    //{
        //    //    Amount = 10,
        //    //    Category = "category 1",
        //    //    CategoryId = 2,
        //    //    DueDate = DateTime.Now.AddDays(1),
        //    //    FirstPrice = 100,
        //    //    Id = 1,
        //    //    Product = "message 1",
        //    //    ProductId = 1,
        //    //    SubCategory = "sub cat 1",
        //    //    SubCategoryId = 201,
        //    //    Text = "Great performance"
        //    //};

        //    //Items.Add(item72);

        //}
    }
}

    
    
//    public class ItemController : ApiController
//    {
//        private ItemContext db = new ItemContext();

//        // GET api/Item
//        public IEnumerable<Item> GetItems()
//        {
//            return db.Items.AsEnumerable();
//        }

//        // GET api/Item/5
//        public Item GetItem(int id)
//        {
//            Item item = db.Items.Find(id);
//            if (item == null)
//            {
//                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
//            }

//            return item;
//        }

//        // PUT api/Item/5
//        public HttpResponseMessage PutItem(int id, Item item)
//        {
//            if (!ModelState.IsValid)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
//            }

//            if (id != item.Id)
//            {
//                return Request.CreateResponse(HttpStatusCode.BadRequest);
//            }

//            db.Entry(item).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException ex)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
//            }

//            return Request.CreateResponse(HttpStatusCode.OK);
//        }

//        // POST api/Item
//        public HttpResponseMessage PostItem(Item item)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Items.Add(item);
//                db.SaveChanges();

//                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
//                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.Id }));
//                return response;
//            }
//            else
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
//            }
//        }

//        // DELETE api/Item/5
//        public HttpResponseMessage DeleteItem(int id)
//        {
//            Item item = db.Items.Find(id);
//            if (item == null)
//            {
//                return Request.CreateResponse(HttpStatusCode.NotFound);
//            }

//            db.Items.Remove(item);

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException ex)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
//            }

//            return Request.CreateResponse(HttpStatusCode.OK, item);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}