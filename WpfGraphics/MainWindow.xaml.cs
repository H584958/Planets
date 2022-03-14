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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceSim;
using WpfSolarSystem;

namespace WpfGraphics
{
    public partial class MainWindow : Window
    {

        List<SpaceObject> solarSystem = new List<SpaceObject>();
        List<SpaceObject> solarSystemReal = new List<SpaceObject>();

        double days = 0;
        double SunScale = 500;
        double z = 1.0;
        double speed = 0.5;

        public MainWindow()
        {
            InitializeComponent();
            getSolarSystem tempSol = new getSolarSystem();
            solarSystem = tempSol.getSolar();
            solarSystemReal = tempSol.getRealSolar();

            makeZoomButton();
            makeSpeedButton();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(100000) //sekk
            };
            timer.Tick += t_Tick;
            timer.Start();
        }

        private void makeSpeedButton()
        {
            Button fasterButton = new Button()
            {
                Content = "faster"
            };
            Button slowerButton = new Button()
            {
                Content = "slower"
            };
            Canvas.SetLeft(fasterButton, 0);
            Canvas.SetTop(fasterButton, 50);
            canvasArea.Children.Add(fasterButton);
            Canvas.SetLeft(slowerButton, 50);
            Canvas.SetTop(slowerButton, 50);
            canvasArea.Children.Add(slowerButton);
            fasterButton.Click += new RoutedEventHandler(faster);
            slowerButton.Click += new RoutedEventHandler(slower);


        }

        private void faster(object sender, RoutedEventArgs e)
        {
            speed = speed + 2;
        }

        private void slower(object sender, RoutedEventArgs e)
        {
            speed = speed - 2;
        }

        private void makeZoomButton()
        {
            Button Plusbutton = new Button()
            {
                Content = " zoom in "
            };
            Button minusButton = new Button()
            {
                Content = " zoom out "
            };
            Canvas.SetLeft(Plusbutton, 0);
            Canvas.SetTop(Plusbutton, 30);
            Canvas.SetLeft(minusButton, 50);
            Canvas.SetTop(minusButton, 30);
            Plusbutton.Click += new RoutedEventHandler(zoomInn);
            minusButton.Click += new RoutedEventHandler(zoomOut);
            canvasArea.Children.Add(Plusbutton);
            canvasArea.Children.Add(minusButton);
        }


        private void zoomInn(object sender, RoutedEventArgs e)
        {
            var scaler = Grid.LayoutTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(z, z);
                Grid.LayoutTransform = scaler;
            }
            DoubleAnimation animator = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(600)),
            };
            if (scaler.ScaleX == z)
            {
                z = z + 0.5;
                animator.To = z;
            }
            else if (scaler.ScaleX > 1.0)
            {
                z = z + 0.5;
                animator.To = z;
            }
            scaler.BeginAnimation(ScaleTransform.ScaleXProperty, animator);
            scaler.BeginAnimation(ScaleTransform.ScaleYProperty, animator);
        }
        private void zoomOut(object sender, RoutedEventArgs e)
        {
            var scaler = Grid.LayoutTransform as ScaleTransform;
            if (scaler == null)
            {
                scaler = new ScaleTransform(1.0, 1.0);
                Grid.LayoutTransform = scaler;
            }
            DoubleAnimation animator = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(600)),
            };
            if (scaler.ScaleX > 1.0)
            {
                z = scaler.ScaleX - 0.5;
                animator.To = z;
            }

            scaler.BeginAnimation(ScaleTransform.ScaleXProperty, animator);
            scaler.BeginAnimation(ScaleTransform.ScaleYProperty, animator);
        }

        private void spaceObjectInfo(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            int i = 0;
            SpaceObject temp = null;
            foreach (SpaceObject space in solarSystem)
            {
                if (ellipse.Height == space.objectRadius / SunScale)
                {
                    i = solarSystem.IndexOf(space);
                }
            }

            temp = solarSystemReal[i];

            if (temp.Parent == null)
            {
                TextBox textbox = new TextBox
                {
                    Text = temp.name + "\n" + "Object Radius: " + temp.objectRadius
                };
                Canvas.SetLeft(textbox, 0);
                Canvas.SetTop(textbox, 200);
            }
            else
            {
                TextBox textbox = new TextBox();

                textbox.Text = temp.name + "\nOrbital Radius: " + temp.orbitalRadius + "*10^6 km " +
                "around the " + temp.Parent.name + "\n" +
                "Orbital Period: " + temp.orbitalPeriod + " days \n" +
                "Rotation Period: " + temp.rotationPeriod + " days \n" +
                "Object Radius: " + temp.objectRadius + " km";

                if (temp.Children.Count > 0)
                {
                    textbox.Text += "\n \nMoons:\n";
                    foreach (SpaceObject child in temp.Children)
                    {
                        textbox.Text += child.name + "\nOrbital Radius: " + child.orbitalRadius + "*10^6 km " +
                        "around the " + child.Parent.name + "\n" +
                        "Orbital Period: " + child.orbitalPeriod + " days \n" +
                        "Rotation Period: " + child.rotationPeriod + " days \n" +
                        "Object Radius: " + child.objectRadius + " km\n";
                    }
                }
                Canvas.SetLeft(textbox, 0);
                Canvas.SetTop(textbox, 200);
            }
        }







        private void ClearCanvasSpaceObj()
        {
            for (int i = canvasArea.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = canvasArea.Children[i];
                if (Child is Ellipse || Child is Label)
                    canvasArea.Children.Remove(Child);
            }

        }


        private void t_Tick(object sender, EventArgs e)
        {
            ClearCanvasSpaceObj();
            days = days + speed;
            makeSolarSystem();
        }

        public void makeSolarSystem()
        {
            foreach (SpaceObject obj in solarSystem)
            {
                obj.getPosition(days);
                double x = obj.posX + ((canvasArea.ActualWidth - ((obj.objectRadius) / SunScale)) / 2);
                double y = obj.posY + ((canvasArea.ActualHeight - ((obj.objectRadius) / SunScale)) / 2);

                Ellipse ellipse = makeSpaceObject(obj.objectRadius, obj.color);

                ellipse.MouseLeftButtonDown += spaceObjectInfo;

                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);


                canvasArea.Children.Add(ellipse);
            }
        }

        public Ellipse makeSpaceObject(double objectRadius, String color)
        {
            Ellipse ellipse = new Ellipse();
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Color.FromArgb(0, 255, 255, 1);
            ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            ellipse.StrokeThickness = 2;
            ellipse.Stroke = Brushes.Black;
            ellipse.Width = objectRadius / SunScale;
            ellipse.Height = objectRadius / SunScale;

            return ellipse;
        }
    }
        
}
