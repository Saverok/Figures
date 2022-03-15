using NUnit.Framework;
using Figures.Classes.Entitys;

namespace FiguresTests
{
    [TestFixture]
    public class TriangleTests
    {
        Triangle triangle;

        [Test]
        [TestCase(5, 3, 4)]
        [TestCase(3, 5, 4)]
        [TestCase(4, 3, 5)]
        public void IsRectangular_True_Test(double fierstSide, double secondSide, double thierdSide)
        {
            var triangle = new Triangle(fierstSide, secondSide, thierdSide);
            Assert.IsTrue(triangle.IsRectangular());
        }

        [Test]
        [TestCase(2, 3, 3)]
        [TestCase(3, 3, 3)]
        [TestCase(5, 6, 15)]
        public void IsRectangular_False_Test(double fierstSide, double secondSide, double thierdSide)
        {
            var triangle = new Triangle(fierstSide, secondSide, thierdSide);
            Assert.IsFalse(triangle.IsRectangular());
        }
    }
}
