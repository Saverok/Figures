using Figures.Interfaces.Entitys;
using System;

namespace Figures.Classes.Entitys
{
    public class Circle: IFigure
    {
        private double radius { get; init; }
        
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius length must be greater than 0");
            }
            this.radius = radius;
        }

        public double GetArea()
        {
            return radius * Math.PI;
        }
    }
}
