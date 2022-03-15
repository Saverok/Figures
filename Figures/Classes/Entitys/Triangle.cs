using Figures.Interfaces.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Classes.Entitys
{
    public class Triangle : IFigure
    {
        private readonly int skipCount = 1;
        private readonly int degree = 2;
        private double fierstSide;
        private double secondSide;
        private double thierdSide;

        public Triangle(double fierstSide, double secondSide, double thirdSide)
        {
            if (fierstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentException("Side length must be greater than 0");
            }
            this.fierstSide = fierstSide;
            this.secondSide = secondSide;
            this.thierdSide = thirdSide;
        }

        public double GetArea()
        {
            var halfPerimeter = (fierstSide + secondSide + thierdSide) / 2;
            var area = Math.Sqrt(halfPerimeter * (halfPerimeter - fierstSide)
                * (halfPerimeter - secondSide) * (halfPerimeter - thierdSide));
            return area;
        }

        public bool IsRectangular()
        {
            var triangle = new List<double>
            {
                fierstSide,
                secondSide,
                thierdSide
            };
            triangle = triangle
              .Select(side => Math.Pow(side, degree))
              .OrderBy(side => side)
              .ToList();
            return triangle.LastOrDefault() == triangle.SkipLast(skipCount).Sum();
        }
    }
}
