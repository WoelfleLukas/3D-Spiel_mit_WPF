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
using System.IO;
using System.Drawing;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Position> planeten = new List<Position>();
        private List<Position> anzeige = new List<Position>();
        private double kamerax = 55;
        private double kameray = 55;
        private double kameraz = 50;
        private int blickrichtung = 0;  //Winkel in dem gedreht wurde
        private double cosBlickrichtung = 1;
        private double sinBlickrichtung = 0;
        private double tan45 = Math.Tan(Math.PI * 45 / 180.0);

        public MainWindow()
        {
            InitializeComponent();
            cosBlickrichtung = Math.Cos(Math.PI * blickrichtung / 180.0);
            sinBlickrichtung = Math.Sin(Math.PI * blickrichtung / 180.0);

            planeten.Add(new Position() { X = 54, Y = 55, Z = 51 });
            planeten.Add(new Position() { X = 55, Y = 55, Z = 54 });
            planeten.Add(new Position() { X = 55, Y = 58, Z = 51 });
            planeten.Add(new Position() { X = 57, Y = 59, Z = 58 });
            planeten.Add(new Position() { X = 57, Y = 59, Z = 48 });
            Drehen();

        }

        /// <summary>
        /// Berechnet Z-Koordinate im Sichtfeld
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private double BerechneZ(double x, double z)
        {

            return (cosBlickrichtung) * (z-kameraz)  +(sinBlickrichtung) * (x - (kamerax));
            
        }

        /// <summary>
        /// Berechnet X-Koordinate im Sichtfeld
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private double BerechneX(double x, double z)
        {
            double erg = 0;
            erg= (cosBlickrichtung * (x-kamerax)  - sinBlickrichtung*(z-kameraz));
            return erg;
        }

     

        /// <summary>
        /// Zeichnet einen Planeten
        /// </summary>
        /// <param name="durchmesser">Durchmesser des Kreises</param>
        /// <param name="x">x Koordinate des Mittelpunktes</param>
        /// <param name="y">y Koordinate des Mittelpunktes</param>
        private Ellipse ErstelleKreis(double durchmesser, double x,double y)
        {
            Ellipse el = new Ellipse() { Width = durchmesser, Height = durchmesser };
            Canvas.SetTop(el, y-durchmesser/2);
            Canvas.SetLeft(el, x-durchmesser/2);
            el.Fill = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) };
            Oberfläche.Children.Add(el);
            return el;
        }

        /// <summary>
        /// Neues Spielfeld zu Anzeige erstellen
        /// </summary>
        private void Drehen()
        {
            planeten.ForEach(Berechnen);
            anzeige.Sort(delegate (Position pos1, Position pos2)
            {
                if (pos1.Z > pos2.Z) return -1;
                if (pos1.Z < pos2.Z) return 1;
                return 0;
            });
            anzeige.ForEach(Anzeigen);
        }

        /// <summary>
        /// ANzeigen eines Planeten
        /// </summary>
        /// <param name="obj">Planet, der angezeigt werden soll</param>
        private void Anzeigen(Position obj)
        {
            ErstelleKreis(200 / (obj.Z / 2.0 + 1), (obj.X * Oberfläche.Width / ((tan45 * obj.Z + 5) * 2) + Oberfläche.Width / 2), (obj.Y * Oberfläche.Height / ((tan45 * obj.Z + 5) * 2) + Oberfläche.Height / 2));
        }

        /// <summary>
        /// Berechnet Standort eines Planeten im neuen Systems
        /// </summary>
        /// <param name="obj">Planet, dessen Position berechnet werden soll</param>
        private void Berechnen(Position obj)
        {
            double z;
            double x;
            double y;
            z = BerechneZ(obj.X, obj.Z);
            x = BerechneX(obj.X,obj.Z);
            y = obj.Y - kameray;
            Position pos;
            if (( pos = Sollangezeigtwerden(x,y,z))!=null)
                anzeige.Add(pos);
           
        }

        /// <summary>
        /// Überprüfen, ob der Planet noch im Sichtfeld ist
        /// </summary>
        /// <param name="x">X Parameter des Planeten im neuen System</param>
        /// <param name="y">Y Parameter des Planeten im neuen System</param>
        /// <param name="z">Z Parameter des Planeten im neuen System</param>
        /// <returns>Position des Planeten im Sichtfeld</returns>
        private Position Sollangezeigtwerden(double x, double y, double z)
        {
            if (z < -0.2)
            {
                return null;
            }
            double grenzeneg;
            double grenzepos;
            grenzeneg = -(tan45 * z + 5);
            grenzepos = tan45 * z + 5;
            if (x < grenzepos && y < grenzepos && x > grenzeneg && y > grenzeneg)
                return new Position() { X = x, Z = z, Y = y };
            return null;

        }


        /// <summary>
        /// Verwendung der Eingabe des Benutzers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.E)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                blickrichtung -= 10;
                cosBlickrichtung = Math.Cos(Math.PI * blickrichtung / 180.0);
                sinBlickrichtung = Math.Sin(Math.PI * blickrichtung / 180.0);
                Drehen();
            }
            else if (e.Key == Key.Q)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                blickrichtung += 10;
                cosBlickrichtung = Math.Cos(Math.PI * blickrichtung / 180.0);
                sinBlickrichtung = Math.Sin(Math.PI * blickrichtung / 180.0);
                Drehen();
            }
            else if(e.Key == Key.W)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kameraz += cosBlickrichtung * 1;
                kamerax += sinBlickrichtung * 1;
                Kamerapruefen();
                Drehen();
            }
            else if (e.Key == Key.S)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kameraz -= cosBlickrichtung * 1;
                kamerax -= sinBlickrichtung * 1;
                Kamerapruefen();
                Drehen();
            }
            else if (e.Key == Key.D)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kamerax += cosBlickrichtung * 1;
                kameraz -= sinBlickrichtung * 1;
                Kamerapruefen();
                Drehen();
            }
            else if (e.Key == Key.A)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kamerax -= cosBlickrichtung * 1;
                kameraz += sinBlickrichtung * 1;
                Kamerapruefen();
                Drehen();
            }
            else if (e.Key == Key.R)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kameray += 1;
                if(kameray>100)
                {
                    kameray = 100;
                }
                Drehen();
            }
            else if (e.Key == Key.F)
            {
                Oberfläche.Children.Clear();
                anzeige.Clear();
                kameray -= 1;
                if (kameray < 0)
                {
                    kameray = 0;
                }
                Drehen();
            }
        }

        /// <summary>
        /// Überprüfung ob die Kamera noch im Bild ist, und falls nicht Veränderung der Kameraposition
        /// </summary>
        private void Kamerapruefen()
        {
            if (kameraz > 100)
            {
                kameraz = 100;
            }
            if (kamerax > 100)
            {
                kamerax = 100;
            }
            if (kameraz < 0)
            {
                kameraz = 0;
            }
            if (kamerax < 0)
            {
                kamerax = 0;
            }
        }
    }
}
