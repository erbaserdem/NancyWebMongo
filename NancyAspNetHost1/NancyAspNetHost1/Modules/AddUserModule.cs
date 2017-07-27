using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using NancyAspNetHost1.Models;
using NancyAspNetHost1.Service;

namespace NancyAspNetHost1.Modules
{
    public class AddUserModule : NancyModule
    {
        string message = string.Empty;
        public AddUserModule()
        {
            Post["/NewUser"] = parameters =>
            {
                var newUser = this.Bind<User>();
                if(new AddUser().AddUserDb(newUser,out message))
                    return View["/tyforregister", message];
                else
                    return View["/ErrorRegister",message];
            };
        }
    }
}