﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitItApp.Models
{
    public class User
    {
        public int CID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Item> BidsList { get; set; }
        public List<Item> AsksList { get; set; }
    }
}