using JobbyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobbyProject.ViewModel
{
    public class Authorizem : AuthorizeAttribute,IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
         if(filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true)

                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            if (HttpContext.Current.Session["Admin"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Accountadmin/LogIndex");
            }
        }
    }
}

