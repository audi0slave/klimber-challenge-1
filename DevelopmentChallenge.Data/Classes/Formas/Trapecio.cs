using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Utils;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public decimal CalcularArea()
        {
            return (_baseMayor + _baseMenor) * _altura / 2;
        }

        public decimal CalcularPerimetro()
        {
            decimal ladoInclinado = (decimal)Math.Sqrt((double)((_baseMayor - _baseMenor) * (_baseMayor - _baseMenor) + _altura * _altura));

            return _baseMayor + _baseMenor + _altura + ladoInclinado;
        }

        public string ObtenerNombre(Idiomas idioma, int cantidad)
        {
            return Diccionario.TraducirNombreForma(TiposFormaGeometrica.Trapecio, idioma, cantidad);
        }
    }
}
