using AbstratoPackage.Globalization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstratoPackage.MVC.HtmlHelpers
{
    public static class Globalization
    {
        public static GlobalizationController GlobalizationControllerInstance;

        public static string GetString(string strName)
        {
            return GlobalizationControllerInstance.GetString(strName);
        }
    }
}
