using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Utils;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public string ObtenerNombre(Idiomas idioma, int cantidad)
        {
            return Diccionario.TraducirNombreForma(TiposFormaGeometrica.Cuadrado, idioma, cantidad);
        }
    }
}
