using NUnit.Framework;
using Figures.Classes;
using Figures.Classes.Entitys;
using System;

namespace FiguresTests
{
    [TestFixture]
    public class Tests
    {
        FiguresController controller;

        [SetUp]
        public void Setup()
        {
            controller = new FiguresController();
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void GetFigureArea_Circle_Test(double radius)
        {
            var circle = new Circle(radius);
            Assert.AreEqual(circle.GetArea(), controller.GetFigureArea(radius));
        }

        [Test]
        [TestCase(5,3,4)]
        [TestCase(11,11,5)]
        [TestCase(6,7,8)]
        public void GetFigureArea_Triangle_Test(double fierstSide, double secondSide, double thierdSide)
        {
            var triangle = new Triangle(fierstSide, secondSide, thierdSide);
            Assert.AreEqual(triangle.GetArea(), controller.GetFigureArea(fierstSide, secondSide, thierdSide));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void GetFigureArea_Circle_ArgumentException_Test(double radius)
        {
            Assert.Throws<ArgumentException>(() => controller.GetFigureArea(radius));
        }

        [Test]
        [TestCase(0, 3, 4)]
        [TestCase(11, -1, 5)]
        [TestCase(6, 7, -2)]
        public void GetFigureArea_Triangle_ArgumentException_Test(double fierstSide, double secondSide, double thierdSide)
        {
            Assert.Throws<ArgumentException>(() => controller.GetFigureArea(fierstSide, secondSide, thierdSide));
        }
    }
}