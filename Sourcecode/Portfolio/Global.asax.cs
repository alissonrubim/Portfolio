using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalizationConfig.RegisterGlobalizationController();
            AbstratoPackage.MVC.HtmlHelpers.Globalization.GlobalizationControllerInstance = GlobalizationConfig.GlobalizationController;
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            if (HttpContext.Current != null) {
                if (HttpContext.Current.Session["CURRENT_LANGUAGE"] == null)
                {
                    string browserLanguage = null;
                    string browserLanguages = Request.ServerVariables.Get("HTTP_ACCEPT_LANGUAGE");
                    string[] splitbrowserLanguages = browserLanguages.Split(';');
                    if (splitbrowserLanguages.Length > 0)
                    {
                        browserLanguage = splitbrowserLanguages[0].Split(',')[0];
                    }

                    if(browserLanguage == "pt-BR")
                    {
                        HttpContext.Current.Session["CURRENT_LANGUAGE"] = "pt-BR";
                    }
                    else
                    {
                        HttpContext.Current.Session["CURRENT_LANGUAGE"] = "en-US";
                    }
                }
            }
        }
    }
}
