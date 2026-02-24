using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public class PurpleSquareCreator : SquareCreator
    {
        public override Square CreateSquare()
        {
            return new Square { Color = Colors.Purple };
        }
    }
}
