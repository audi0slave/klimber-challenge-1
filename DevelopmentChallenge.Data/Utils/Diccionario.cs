using DevelopmentChallenge.Data.Enums;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Utils
{
    public static class Diccionario
    {
        private static readonly Dictionary<(TiposFormaGeometrica, bool), string> _clavesRecursos = new Dictionary<(TiposFormaGeometrica, bool), string>()
        {
            // Cuadrado
            { (TiposFormaGeometrica.Cuadrado, true), "NombreForma_CuadradoSingular" },
            { (TiposFormaGeometrica.Cuadrado, false), "NombreForma_CuadradoPlural" },

            // Circulo
            { (TiposFormaGeometrica.Circulo, true), "NombreForma_CirculoSingular" },
            { (TiposFormaGeometrica.Circulo, false), "NombreForma_CirculoPlural" },

            // TrianguloEquilatero
            { (TiposFormaGeometrica.TrianguloEquilatero, true), "NombreForma_TrianguloSingular" },
            { (TiposFormaGeometrica.TrianguloEquilatero, false), "NombreForma_TrianguloPlural" },

            // Trapecio
            { (TiposFormaGeometrica.Trapecio, true), "NombreForma_TrapecioSingular" },
            { (TiposFormaGeometrica.Trapecio, false), "NombreForma_TrapecioPlural" },
        };

        public static string TraducirNombreForma(TiposFormaGeometrica forma, Idiomas idioma, int cantidad)
        {
            bool singular = cantidad == 1;

            if (_clavesRecursos.TryGetValue((forma, singular), out string nombreClave))
            {
                return IdiomaHelper.GetLocalizedString(nombreClave, idioma);
            }

            return "N/A";
        }

    }
}
