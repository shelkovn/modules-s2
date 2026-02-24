using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeFactory.Model.Fabric1
{
    public class Triangle : Figure
    {
        public override UIElement Draw(double size = 67)
        {
            return new Polygon
            {
                Points = new PointCollection
                {
                    new Point(size/2, 0),
                    new Point(0, size/2),
                    new Point(size, size)
                },
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5),
                Width = size,
                Height= size,
                Stretch = Stretch.Fill
            };
        }
    }
}
