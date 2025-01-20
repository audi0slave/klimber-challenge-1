using DevelopmentChallenge.Data.Enums;
using System.Globalization;
using System.Resources;


namespace DevelopmentChallenge.Data.Utils
{
    public static class IdiomaHelper
    {
        private static readonly ResourceManager ResourceManager = Resources.Messages.ResourceManager;

        public static string GetLocalizedString(string key, Idiomas idioma)
        {
            CultureInfo culture = idioma.ToCulture();
            return ResourceManager.GetString(key, culture) ?? "N/A";
        }
    }
}
