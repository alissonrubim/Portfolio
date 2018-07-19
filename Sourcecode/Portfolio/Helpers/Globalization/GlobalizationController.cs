using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstratoPackage.Globalization
{
    public class GlobalizationController
    {
        public delegate string GlobalizationControllerGetCurrentLanguageHandle();

        public List<Globalization> Globalizations = new List<Globalization>();
        public string DefaultLanguage;
        public GlobalizationControllerGetCurrentLanguageHandle OnGetCurrentLanguage;

        public GlobalizationController()
        {
            this.DefaultLanguage = "en-US";
        }

        public void AppendGlobalization(string resourceName, string language, Assembly assembly = null)
        {
            Globalizations.Add(new Globalization(resourceName, language, assembly));
        }

        public string GetString(string identifier)
        {
            Globalization globalization = getGlobalizationByLanguage(getLanguage());
            return globalization.GetString(identifier);
        }

        public Dictionary<string, string> GetAllStrings()
        {
            Globalization globalization = getGlobalizationByLanguage(getLanguage());
            return globalization.GetAllStrings();
        }

        public Globalization GetCurrentGlobalization()
        {
            return getGlobalizationByLanguage(getLanguage());
        }

        #region Private
        private string getLanguage()
        {
            string currentLanguage = OnGetCurrentLanguage?.Invoke();
            var language = this.DefaultLanguage;
            if (currentLanguage != null)
                language = currentLanguage;
            return language;
        }

        private Globalization getGlobalizationByLanguage(string language)
        {
            return Globalizations.Where(g => g.CultureInfo.Name.Equals(language)).FirstOrDefault();
        }
        #endregion
    }
}
