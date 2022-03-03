using SpaceSim;
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



namespace WpfGraphics
{
    public partial class MainWindow : Window
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>() {new Star("Sun", 0, 0, 69635, 0, "YELLOW")};

 

        public MainWindow()
        {
            InitializeComponent();
            foreach(SpaceObject obj in solarSystem)
            {
                makeObject(obj);
            }
            
        }

        public Ellipse makeObject(SpaceObject spaceObject)
        {

            Ellipse planet = new Ellipse();

            planet.Height =(int) spaceObject.objectRadius;
            planet.Width = (int)spaceObject.objectRadius;

            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Color.FromArgb(0, 255, 255, 0);
            planet.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(spaceObject.color));
            planet.Stroke = Brushes.Black;
            planet.StrokeThickness = 3;
            planet.Stroke = Brushes.Black;


            return planet;
        }

    }
}
