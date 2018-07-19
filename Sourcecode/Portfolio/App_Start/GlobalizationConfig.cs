using AbstratoPackage.Globalization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Portfolio
{
    public class GlobalizationConfig
    {
        public static GlobalizationController GlobalizationController = null;

        public static void RegisterGlobalizationController()
        {
            GlobalizationController = new GlobalizationController();
            GlobalizationController.DefaultLanguage = "en-US";
            GlobalizationController.AppendGlobalization("Portfolio.Strings.en-US", "en-US", null);
            GlobalizationController.AppendGlobalization("Portfolio.Strings.pt-BR", "pt-BR", null);
            GlobalizationController.OnGetCurrentLanguage += new GlobalizationController.GlobalizationControllerGetCurrentLanguageHandle(() =>
            {
                return HttpContext.Current.Session["CURRENT_LANGUAGE"] != null ? (string)HttpContext.Current.Session["CURRENT_LANGUAGE"] : "en-US";
            });
        }

    }
}