using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeFactory.Model.Fabric2
{
    public class Circle : Figure
    {
        public override UIElement Draw(double size = 67)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }
}
