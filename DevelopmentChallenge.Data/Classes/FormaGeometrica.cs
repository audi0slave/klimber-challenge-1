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
using DevelopmentChallenge.Data.Utils;
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
                string emptyListMessage = IdiomaHelper.GetLocalizedString("ListaVacia", idioma);

                return emptyListMessage;
            }

            StringBuilder sb = new StringBuilder();

            #region HEADER
            sb.Append(IdiomaHelper.GetLocalizedString("TextoHeader", idioma));

            #endregion

            #region BODY

            // Agrupamos las formas por su tipo. Pasamos 1 como cantidad porque solo nos interesa obtener el nombre de la forma
            // para luego procesar y realizar los cálculos correspondientes.
            
            // todo: (Esta agrupación quizás podria mejorarse utilizando otra propiedad en lugar de ObtenerNombre?. Quizas usar GetType ?)
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
            sb.Append($"{numeroTotal} {IdiomaHelper.GetLocalizedString("TextoFormas", idioma)} ");
            sb.Append($"{IdiomaHelper.GetLocalizedString("TextoPerimetro", idioma)} {totalPerimetro:#.##} ");
            sb.Append($"{IdiomaHelper.GetLocalizedString("TextoArea", idioma)} {totalArea:#.##}");

            #endregion

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, IFormaGeometrica tipoForma, Idiomas idioma)
        {
            string nombreForma = tipoForma.ObtenerNombre(idioma, cantidad);
            string tituloPerimetro = IdiomaHelper.GetLocalizedString("TextoPerimetro", idioma);
            string tituloArea = IdiomaHelper.GetLocalizedString("TextoArea", idioma);

            return $"{cantidad} {nombreForma} | {tituloArea} {area:#.##} | {tituloPerimetro} {perimetro:#.##} <br/>";
        }
    }
}
