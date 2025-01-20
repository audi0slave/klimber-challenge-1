using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();

        /// <summary>
        /// Obtiene el nombre de la forma
        /// </summary>
        /// <param name="idioma">Idioma en el cual se desea obtener la forma</param>
        /// <param name="cantidad">Cantidad de formas</param>
        string ObtenerNombre(Idiomas idioma, int cantidad);
    }
}