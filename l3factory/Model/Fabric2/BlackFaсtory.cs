using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapeFactory.Model.Fabric2
{
    public class BlackFaсtory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle
        {
            Color = Colors.Black
        };
        public Square CreateSquare() => new Square
        {
            Color = Colors.Black
        };
        public Triangle CreateTriangle() => new Triangle
        {
            Color = Colors.Black
        };
    }
}
