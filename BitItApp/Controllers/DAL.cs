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

        /// <summary>
        /// Items
        /// </summary>
        
        private static List<Item> Items;

        public List<Item> GetItems()
        {
            return Items;
        }

        public void AddItem(Item item)
        {
            item.Id = CreateItemId();
            item.FirstPriceDisplay = "--";
            Items.Add(item);
        }


        public void UpdateItem(Item item)
        {
            Item updatedItem = GetItem(item.Id);
            if (updatedItem != null)
            {
                if (updatedItem.FirstPrice == 0 || item.NewPrice < updatedItem.FirstPrice)
                {
                    updatedItem.FirstPrice = item.NewPrice;
                    updatedItem.FirstPriceDisplay = item.NewPrice.ToString();
                }
                else if (updatedItem.SecondPrice == 0 || item.NewPrice < updatedItem.SecondPrice)
                {
                    updatedItem.SecondPrice = item.NewPrice;
                    updatedItem.FirstPriceDisplay = item.NewPrice.ToString();
                }
                else if (updatedItem.ThirdPrice == 0 || item.NewPrice < updatedItem.ThirdPrice)
                {
                    updatedItem.ThirdPrice = item.NewPrice;
                    updatedItem.FirstPriceDisplay = item.NewPrice.ToString();
                }
            }
        }

        public Item GetItem(int id)
        {
            //IEnumerable<Item> results = Items.Where(i => i.Id.Equals(id));
            Item result = Items.First(item => item.Id == id);
            return result;
        }

        private static int CreateItemId()
        {
            int retVal = Items.Max(i => i.Id);
            retVal++;
            
            return retVal;
        }

        private static void Init()
        {
            InitItems();

            InitUsers();
        }
        
        private static void InitItems()
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
                Product = "LCD",
                ProductId = 20201,
                SubCategory = "טלויזיה",
                SubCategoryId = 202,
                FirstPriceDisplay = "100"
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
                ProductId = 10103,
                SubCategory = "חומרי עבודה",
                SubCategoryId = 101,
                FirstPriceDisplay = "10"
            };

            Items.Add(item2);

            Item item3 = new Item()
            {
                Amount = 10,
                Category = "מוצרי חשמל",
                CategoryId = 2,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 100,
                Id = 3,
                Product = "מאוורר תקרה",
                ProductId = 20001,
                SubCategory = "מאוורר",
                SubCategoryId = 200,
                FirstPriceDisplay = "100"
            };

            Items.Add(item3);

            Item item4 = new Item()
            {
                Amount = 10,
                Category = "ריהוט",
                CategoryId = 3,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 100,
                Id = 4,
                Product = "ארון קיר",
                ProductId = 30001,
                SubCategory = "ארונות",
                SubCategoryId = 300,
                FirstPriceDisplay = "100"
            };

            Items.Add(item4);

            Item item5 = new Item()
            {
                Amount = 10,
                Category = "מוצרי חשמל",
                CategoryId = 2,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 100,
                Id = 5,
                Product = "LED",
                ProductId = 20202,
                SubCategory = "טלויזיות",
                SubCategoryId = 202,
                FirstPriceDisplay = "100"
            };

            Items.Add(item5);

            Item item6 = new Item()
            {
                Amount = 12,
                Category = "ריהוט",
                CategoryId = 3,
                DueDate = DateTime.Now.AddDays(2),
                FirstPrice = 10,
                Id = 6,
                Product = "כסא בר",
                ProductId = 30102,
                SubCategory = "כסאות",
                SubCategoryId = 301,
                FirstPriceDisplay = "10"
            };

            Items.Add(item6);

            Item item7 = new Item()
            {
                Amount = 10,
                Category = "מוצרי חשמל",
                CategoryId = 2,
                DueDate = DateTime.Now.AddDays(1),
                FirstPrice = 1000,
                Id = 7,
                Product = "מזגן עילי",
                ProductId = 20101,
                SubCategory = "מזגן",
                SubCategoryId = 201,
                FirstPriceDisplay = "1000"
            };

            Items.Add(item7);

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

        /// <summary>
        /// Users
        /// </summary>

        private static List<User> Users;

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User result = Users.Find(user => user.Username.Equals(username) && user.Password.Equals(password));
            return result;
        }

        public User GetUserByUsername(string username)
        {
            User result = Users.Find(user => user.Username.Equals(username));
            return result;
        }

        public User GetUserByEmail(string email)
        {
            User result = Users.Find(user => user.Email.Equals(email.ToLower()));
            return result;
        }

        private static void InitUsers()
        {
            Users = new List<User>();

            // Ask
            User user1 = new User()
            {
                Username = "dan",
                Password = "1",
                Email = "dandan53@gmail.com",
                CID = 1,
                AsksList = new List<Item>()
            };

            Users.Add(user1);
            
            // Ask
            User user2 = new User()
            {
                Username = "carmi",
                Password = "2",
                Email = "carmilaks@gmail.com",
                CID = 2,
                AsksList = new List<Item>()
            };

            Users.Add(user2);

            // Bid
            User user3 = new User()
            {
                Username = "chen",
                Password = "3",
                Email = "chenvardi9@gmail.com",
                CID = 3,
                BidsList = new List<Item>()
            };

            Users.Add(user3);

            var i = 0;
            var items = DAL.instance.GetItems();
            foreach (var item in items)
            {
                i++;
                if (i % 2 == 0)
                {
                    user2.AsksList.Add(item);
                }
                else
                {
                    user1.AsksList.Add(item);
                }

                item.FirstAskUser = user3;
            }
        }


        // Register //

        public User AddUser(RegisterRequest registerRequest)
        {
            User existedUser = GetUserByUsername(registerRequest.Username);
            if (existedUser == null)
            {
                var user = new User()
                {
                    CID = CreateUserCId(),
                    Username = registerRequest.Username,
                    Password = registerRequest.Password,
                    Email = registerRequest.Email.ToLower()
                };

                Users.Add(user);

                return user;
            }
            
            return null;
        }

        private static int CreateUserCId()
        {
            int retVal = Users.Max(i => i.CID);
            retVal++;

            return retVal;
        }
        
    }
}