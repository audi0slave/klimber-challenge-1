/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public static string Imprimir(List<IFormaGeometrica> formas, Idiomas idioma)
        {
            if (!formas.Any())
            {
                return MostrarMensajeListaVacia(idioma);
            }

            StringBuilder sb = new StringBuilder();

            #region HEADER

            sb.Append(ObtenerHeader(idioma));

            #endregion

            #region BODY

            // Agrupamos las formas por su tipo. Pasamos 1 como cantidad porque solo nos interesa obtener el nombre de la forma
            // para luego procesar y realizar los cálculos correspondientes.
            // todo: (Esta agrupación podria mejorarse utilizando otra propiedad. Quizas GetType ?)

            var formasAgrupadas = formas
                .GroupBy(_ => _.ObtenerNombre(idioma, 1))
                .Select(g => new
                {
                    Nombre = g.Key,
                    Cantidad = g.Count(),
                    Area = g.Sum(_ => _.CalcularArea()),
                    Perimetro = g.Sum(_ => _.CalcularPerimetro()),
                    TipoForma = g.First()
                })
                .ToList();

            // ahora hacemos los cálculos correspondientes sobre todas las formas agrupadas previamente
            foreach (var grupoForma in formasAgrupadas)
            {
                sb.Append(ObtenerLinea(grupoForma.Cantidad, grupoForma.Area, grupoForma.Perimetro, grupoForma.TipoForma, idioma));
            }

            #endregion

            #region FOOTER
            int numeroTotal = formasAgrupadas.Sum(_ => _.Cantidad);
            decimal totalPerimetro = formasAgrupadas.Sum(_ => _.Perimetro);
            decimal totalArea = formasAgrupadas.Sum(_ => _.Area);

            sb.Append("TOTAL:<br/>");
            sb.Append($"{numeroTotal} {ObtenerNombreFormas(idioma)} ");
            sb.Append($"{ObtenerNombrePerimetro(idioma)} {totalPerimetro:#.##} ");
            sb.Append($"{ObtenerNombreArea(idioma)} {totalArea:#.##}");

            #endregion

            return sb.ToString();
        }

        private static string ObtenerHeader(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                    return "<h1>Reporte de Formas</h1>";
                case Idiomas.Italiano:
                    return "<h1>Relazione delle Forme</h1>";
                default:
                    return "<h1>Shapes report</h1>";
            }
        }

        private static string ObtenerNombrePerimetro(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                case Idiomas.Italiano:
                    return "Perimetro";
                default:
                    return "Perimeter";
            }
        }

        private static string ObtenerNombreArea(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                case Idiomas.Italiano:
                    return "Area";
                default:
                    return "Area";
            }
        }

        private static string ObtenerNombreFormas(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                    return "formas";
                case Idiomas.Italiano:
                    return "forme";
                default:
                    return "shapes";
            }
        }

        private static string MostrarMensajeListaVacia(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                    return "<h1>Lista vacía de formas!</h1>";
                case Idiomas.Italiano:
                    return "<h1>Lista vuota di forme!</h1>";
                default:
                    return "<h1>Empty list of shapes!</h1>";
            }
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, IFormaGeometrica tipoForma, Idiomas idioma)
        {
            string nombreForma = tipoForma.ObtenerNombre(idioma, cantidad);
            string tituloPerimetro = ObtenerNombrePerimetro(idioma);
            string tituloArea = ObtenerNombreArea(idioma);

            return $"{cantidad} {nombreForma} | {tituloArea} {area:#.##} | {tituloPerimetro} {perimetro:#.##} <br/>";
        }
    }
}
