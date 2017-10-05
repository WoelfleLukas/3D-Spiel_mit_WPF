using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ClassLibrary2
{
    class Planetentypen
    {
        public static Planetentyp[] GetPlanetentypen()
        {
            Planetentyp[] typen = new Planetentyp[5];
            typen[0] = new Planetentyp() { Img = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) }, Name = "Nahrung" };
            typen[1] = new Planetentyp() { Img = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) }, Name = "Wasser" };
            typen[2] = new Planetentyp() { Img = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) }, Name = "Gas" };
            typen[3] = new Planetentyp() { Img = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) }, Name = "Eisen" };
            typen[4] = new Planetentyp() { Img = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"F:\planet1.jpg")) }, Name = "Holz" };

            return typen;
        }
    }
}
