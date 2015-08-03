using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitItApp.Models;

namespace BitItApp.Controllers
{
    public sealed class DAL
    {
        private static DAL instance = null;

        private DAL()
        {
        }

        public static DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL();

                    Init();
                }
                return instance;
            }
        }

        private static List<Item> Items;

        public List<Item> GetItems()
        {
            return Items;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item GetItem(int id)
        {
            //IEnumerable<Item> results = Items.Where(i => i.Id.Equals(id));
            Item result = Items.First(item => item.Id == id);
            return result;
        }

        private static void Init()
        {
            Items = new List<Item>();

            Item item1 = new Item()
            {
                Amount = 10,
                Category = "מוצרי חשמל",
                CategoryId = 2,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 100,
                Id = 1,
                Product = "l.s.d",
                ProductId = 1,
                SubCategory = "טלויזיה",
                SubCategoryId = 202
            };

            Items.Add(item1);

            Item item2 = new Item()
            {
                Amount = 12,
                Category = "כלי עבודה",
                CategoryId = 1,
                DueDate = DateTime.Now.AddDays(2),
                FirstPrice = 10,
                Id = 2,
                Product = "מטאטא",
                ProductId = 2,
                SubCategory = "חומרי עבודה",
                SubCategoryId = 101
            };

            Items.Add(item2);

            Item item3 = new Item()
            {
                Amount = 10,
                Category = "מוצרי חשמל",
                CategoryId = 2,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 100,
                Id = 1,
                Product = "מאוורר קיר",
                ProductId = 1,
                SubCategory = "מאוורר",
                SubCategoryId = 200
            };

            Items.Add(item3);

            //Item item4 = new Item()
            //{
            //    Amount = 10,
            //    Category = "ריהוט",
            //    CategoryId = 3,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "ארון מחשב",
            //    ProductId = 1,
            //    SubCategory = "ארונות",
            //    SubCategoryId = 300
            //};

            //Items.Add(item4);

            //Item item5 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item5);

            //Item item6 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ריהוט",
            //    CategoryId = 3,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "כסאות",
            //    ProductId = 2,
            //    SubCategory = "כסאות",
            //    SubCategoryId = 301
            //};

            //Items.Add(item6);

            //Item item7 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "מזגן קטן",
            //    ProductId = 1,
            //    SubCategory = "מזגן",
            //    SubCategoryId = 201
            //};

            //Items.Add(item7);

            //Item item8 = new Item()
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
            //    SubCategoryId = 202
            //};

            //Items.Add(item8);

            //Item item9 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 111,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item9);

            //Item item10 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item10);

            //Item item11 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item11);

            //Item item12 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item12);

            //Item item13 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item13);

            //Item item14 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item14);

            //Item item15 = new Item()
            //{
            //    Amount = 10,
            //    Category = "מוצרי חשמל",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "טלויזיה",
            //    ProductId = 1,
            //    SubCategory = "טלויזיות",
            //    SubCategoryId = 202
            //};

            //Items.Add(item15);

            //Item item16 = new Item()
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

            //Items.Add(item16);

            //Item item17 = new Item()
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

            //Items.Add(item17);

            //Item item18 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item18);

            //Item item19 = new Item()
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

            //Items.Add(item19);

            //Item item20 = new Item()
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

            //Items.Add(item20);

            //Item item21 = new Item()
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

            //Items.Add(item21);

            //Item item22 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item22);

            //Item item23 = new Item()
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

            //Items.Add(item23);

            //Item item24 = new Item()
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

            //Items.Add(item24);

            //Item item25 = new Item()
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

            //Items.Add(item25);

            //Item item26 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item26);

            //Item item27 = new Item()
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

            //Items.Add(item27);

            //Item item28 = new Item()
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

            //Items.Add(item28);

            //Item item29 = new Item()
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

            //Items.Add(item29);

            //Item item30 = new Item()
            //{
            //    Amount = 12,
            //    Category = "ציוד משרדי",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(2),
            //    FirstPrice = 10,
            //    Id = 2,
            //    Product = "דפים למדפסת",
            //    ProductId = 2,
            //    SubCategory = "דפים",
            //    SubCategoryId = 1
            //};

            //Items.Add(item30);

            //Item item31 = new Item()
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

            //Items.Add(item31);

            //Item item32 = new Item()
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

            //Items.Add(item32);

            //Item item33 = new Item()
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

            //Items.Add(item33);

            //Items = new List<Item>();
            //Item item70 = new Item()
            //{
            //    Amount = 10,
            //    Category = "category 1",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "message 1",
            //    ProductId = 1,
            //    SubCategory = "sub cat 1",
            //    SubCategoryId = 201,
            //    Text = "like a new product"
            //};

            //Items.Add(item70);

            //Item item71 = new Item()
            //{
            //    Amount = 10,
            //    Category = "category 1",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "message 1",
            //    ProductId = 1,
            //    SubCategory = "sub cat 1",
            //    SubCategoryId = 201,
            //    Text = "Only in black"
            //};

            //Items.Add(item71);

            //Item item72 = new Item()
            //{
            //    Amount = 10,
            //    Category = "category 1",
            //    CategoryId = 2,
            //    DueDate = DateTime.Now.AddDays(1),
            //    FirstPrice = 100,
            //    Id = 1,
            //    Product = "message 1",
            //    ProductId = 1,
            //    SubCategory = "sub cat 1",
            //    SubCategoryId = 201,
            //    Text = "Great performance"
            //};

            //Items.Add(item72);

        }
    }
}