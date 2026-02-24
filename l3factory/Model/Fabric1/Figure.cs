using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ShapeFactory.Model.Fabric1
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        public abstract UIElement Draw(double size = 67);
    }
}
