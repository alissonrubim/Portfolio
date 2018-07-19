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
            GlobalizationController.AppendGlobalization("Portfolio.Strings.fr-FR", "fr-FR", null);
            GlobalizationController.OnGetCurrentLanguage += new GlobalizationController.GlobalizationControllerGetCurrentLanguageHandle(() =>
            {
                return GetCurrentLanguage();
            });
        }

        public static void SetCurrentLanguage(string language)
        {
            if (language == "pt-BR")
            {
                HttpContext.Current.Session["CURRENT_LANGUAGE"] = "pt-BR";
            }
            else if (language == "fr-FR")
            {
                HttpContext.Current.Session["CURRENT_LANGUAGE"] = "fr-FR";
            }
            else
            {
                HttpContext.Current.Session["CURRENT_LANGUAGE"] = "en-US";
            }
        }

        public static string GetCurrentLanguageName()
        {
            string name = "English";
            if (GlobalizationConfig.GetCurrentLanguage() == "pt-BR")
            {
                name = "Português";
            }
            else if (GlobalizationConfig.GetCurrentLanguage() == "fr-FR")
            {
                name = "Français";
            }

            return name;
        }

        public static string GetCurrentLanguage()
        {
            return HttpContext.Current.Session["CURRENT_LANGUAGE"] != null ? (string)HttpContext.Current.Session["CURRENT_LANGUAGE"] : "en-US";
        }

    }
}