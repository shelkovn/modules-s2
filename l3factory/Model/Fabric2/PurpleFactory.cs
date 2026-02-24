using System.Windows.Media;

namespace ShapeFactory.Model.Fabric2
{
    public class PurpleFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle
        {
            Color = Colors.Purple
        };
        public Square CreateSquare() => new Square
        {
            Color = Colors.Purple
        };
        public Triangle CreateTriangle() => new Triangle
        {
            Color = Colors.Purple
        };
    }
}
