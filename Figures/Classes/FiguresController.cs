using Figures.Classes.Entitys;

namespace Figures.Classes
{
    public class FiguresController
    {
        public double GetFigureArea(double radius)
        {
            var circle = new Circle(radius);
            return circle.GetArea();
        }

        public double GetFigureArea(double fierstSide, double secondSide, double thierdSide)
        {
            var triangle = new Triangle(fierstSide, secondSide, thierdSide);
            return triangle.GetArea();
        }
    }
}
