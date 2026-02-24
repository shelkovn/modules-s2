using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public class BlackCircleCreator : CircleCreator
    {
        public override Circle CreateCircle()
        {
            return new Circle { Color = Colors.Black };
        }
    }
}
