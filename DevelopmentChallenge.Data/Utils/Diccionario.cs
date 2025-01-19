using DevelopmentChallenge.Data.Enums;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Utils
{
    public static class Diccionario
    {
        private static readonly Dictionary<(TiposFormaGeometrica, Idiomas, bool), string> _traduccion
            = new Dictionary<(TiposFormaGeometrica, Idiomas, bool), string>()
        {
            // Cuadrado
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Castellano, true), "Cuadrado" },
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Castellano, false), "Cuadrados" },
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Ingles, true), "Square" },
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Ingles, false), "Squares" },
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Italiano, true), "Quadrato" },
            { (TiposFormaGeometrica.Cuadrado, Idiomas.Italiano, false), "Quadrati" },

            // Circulo
            { (TiposFormaGeometrica.Circulo, Idiomas.Castellano, true), "Círculo" },
            { (TiposFormaGeometrica.Circulo, Idiomas.Castellano, false), "Círculos" },
            { (TiposFormaGeometrica.Circulo, Idiomas.Ingles, true), "Circle" },
            { (TiposFormaGeometrica.Circulo, Idiomas.Ingles, false), "Circles" },
            { (TiposFormaGeometrica.Circulo, Idiomas.Italiano, true), "Cerchio" },
            { (TiposFormaGeometrica.Circulo, Idiomas.Italiano, false), "Cerchi" },

            // TrianguloEquilatero
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Castellano, true), "Triángulo" },
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Castellano, false), "Triángulos" },
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Ingles, true), "Triangle" },
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Ingles, false), "Triangles" },
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Italiano, true), "Triangolo" },
            { (TiposFormaGeometrica.TrianguloEquilatero, Idiomas.Italiano, false), "Triangoli" },

            // Trapecio
            { (TiposFormaGeometrica.Trapecio, Idiomas.Castellano, true), "Trapecio" },
            { (TiposFormaGeometrica.Trapecio, Idiomas.Castellano, false), "Trapecios" },
            { (TiposFormaGeometrica.Trapecio, Idiomas.Ingles, true), "Trapezoid" },
            { (TiposFormaGeometrica.Trapecio, Idiomas.Ingles, false), "Trapezoids" },
            { (TiposFormaGeometrica.Trapecio, Idiomas.Italiano, true), "Trapezio" },
            { (TiposFormaGeometrica.Trapecio, Idiomas.Italiano, false), "Trapezi" },
        };

        public static string TraducirNombreForma(TiposFormaGeometrica forma, Idiomas idioma, int cantidad)
        {
            bool singular = cantidad == 1;

            if (_traduccion.TryGetValue((forma, idioma, singular), out string nombre))
            {
                return nombre;
            }

            return "N/A";
        }

    }
}
