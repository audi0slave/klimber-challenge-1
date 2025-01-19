using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Utils;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public string ObtenerNombre(Idiomas idioma, int cantidad)
        {
            return Diccionario.TraducirNombreForma(TiposFormaGeometrica.TrianguloEquilatero, idioma, cantidad);
        }
    }
}
