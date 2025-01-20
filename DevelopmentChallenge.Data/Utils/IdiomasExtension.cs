using DevelopmentChallenge.Data.Enums;
using System.Collections.Generic;
using System.Globalization;

namespace DevelopmentChallenge.Data.Utils
{
    public static class IdiomasExtension
    {
        private static readonly Dictionary<Idiomas, string> DiccionarioCultura = new Dictionary<Idiomas, string>
        {
            { Idiomas.Castellano, "es" },
            { Idiomas.Ingles, "en" },
            { Idiomas.Italiano, "it" }
        };

        public static CultureInfo ToCulture(this Idiomas idioma)
        {
            if (DiccionarioCultura.TryGetValue(idioma, out var cultureName))
            {
                return new CultureInfo(cultureName);
            }

            return new CultureInfo("en");
        }
    }
}
