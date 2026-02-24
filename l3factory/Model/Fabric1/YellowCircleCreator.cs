using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public class YellowCircleCreator : CircleCreator
    {
        public override Circle CreateCircle()
        {
            return new Circle { Color = Colors.Yellow };
        }
    }
}
