using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BitItApp.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public LoginResult Post(LoginRequest request)
        {
            var retVal = new LoginResult();

            if (request != null)
            {
                if (request.Username.Equals("d") && request.Password.Equals("d"))
                {
                    retVal.CID = 1;
                }
            }

            return retVal;
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public int CID { get; set; }
    }
}
