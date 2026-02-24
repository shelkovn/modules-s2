using System.Windows.Media;

namespace ShapeFactory.Model.Fabric2
{
    public class YellowFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle
        {
            Color = Colors.Yellow
        };
        public Square CreateSquare() => new Square
        {
            Color = Colors.Yellow
        };
        public Triangle CreateTriangle() => new Triangle
        {
            Color = Colors.Yellow
        };
    }
}
