using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public class BlackSquareCreator : SquareCreator
    {
        public override Square CreateSquare()
        {
            return new Square { Color = Colors.Black };
        }
    }
}
