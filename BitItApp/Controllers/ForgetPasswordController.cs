using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitItApp.Controllers
{
    public class ForgetPasswordController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public ForgetPasswordResult Post(ForgetPasswordRequest request)
        {
            var retVal = new ForgetPasswordResult();

            if (request != null)
            {
                var user = DAL.Instance.GetUserByEmail(request.Email);
                if (user != null)
                {
                    retVal.IsSuccess = EmailSender.SendForgetPasswordEmail(user.Email, user.Password);
                }
            }

            return retVal;
        }
    }

    public class ForgetPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ForgetPasswordResult
    {
        public bool IsSuccess { get; set; }
    }
}