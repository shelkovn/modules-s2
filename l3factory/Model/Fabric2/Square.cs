using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeFactory.Model.Fabric2
{
    public class Square : Figure
    {
        public override UIElement Draw(double size = 67)
        {
            return new Rectangle
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }
}
