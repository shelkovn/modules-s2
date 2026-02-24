using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public class BlackTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Black };
        }
    }
}
