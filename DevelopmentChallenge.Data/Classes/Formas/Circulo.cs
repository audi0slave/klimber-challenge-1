using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Utils;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Circulo(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }

        public string ObtenerNombre(Idiomas idioma, int cantidad)
        {
            return Diccionario.TraducirNombreForma(TiposFormaGeometrica.Circulo, idioma, cantidad);
        }
    }
}
