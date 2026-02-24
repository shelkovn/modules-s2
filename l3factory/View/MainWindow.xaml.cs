using ShapeFactory.Model.Fabric1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapeFactory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        CircleCreator circleCreator;
        SquareCreator squareCreator;
        TriangleCreator triangleCreator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ComboBox && e.AddedItems.Count != 0)
            {
                ComboBoxItem item = (ComboBoxItem)e.AddedItems[0];
                if (stackp != null)
                {
                    stackp.Children.Clear();
                }
                switch (item.Content.ToString())
                {

                    case "Purple":
                        circleCreator = new PurpleCircleCreator();
                        squareCreator = new PurpleSquareCreator();
                        triangleCreator = new PurpleTriangleCreator();
                        break;
                    case "Black":
                        circleCreator = new BlackCircleCreator();
                        squareCreator = new BlackSquareCreator();
                        triangleCreator = new BlackTriangleCreator();
                        break;
                    case "Yellow":
                        circleCreator = new YellowCircleCreator();
                        squareCreator = new YellowSquareCreator();
                        triangleCreator = new YellowTriangleCreator();
                        break;
                    default:
                        return;
                }
            }
            
        }

        private void DrawCircle(object sender, RoutedEventArgs e)
        {
            Model.Fabric1.Figure circle = circleCreator.CreateCircle();
            stackp.Children.Add(circle.Draw());
        }

        private void DrawSquare(object sender, RoutedEventArgs e)
        {
            Model.Fabric1.Figure square = squareCreator.CreateSquare();
            stackp.Children.Add(square.Draw());

        }
        private void DrawTriangle (object sender, RoutedEventArgs e)
        {
            Model.Fabric1.Figure triangle = triangleCreator.CreateTriangle();
            stackp.Children.Add(triangle.Draw());

        }
    }
}
