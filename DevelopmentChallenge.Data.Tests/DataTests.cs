using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Formas;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            ClassicAssert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Enums.Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            ClassicAssert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Enums.Idiomas.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Enums.Idiomas.Castellano);

            ClassicAssert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Enums.Idiomas.Ingles);

            ClassicAssert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Enums.Idiomas.Ingles);

            ClassicAssert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Enums.Idiomas.Castellano);

            ClassicAssert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(10, 6, 4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Enums.Idiomas.Castellano);

            ClassicAssert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Area 32 | Perimetro 25,66 <br/>TOTAL:<br/>1 formas Perimetro 25,66 Area 32",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(10, 6, 4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Enums.Idiomas.Ingles);

            ClassicAssert.AreEqual(
                "<h1>Shapes report</h1>1 Trapezoid | Area 32 | Perimeter 25,66 <br/>TOTAL:<br/>1 shapes Perimeter 25,66 Area 32",
                resumen);
        }
    }
}
