using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClassLibrary2
{
    class Planetentyp
    {
        private ImageBrush img;
        private String name;

        public ImageBrush Img { get => img; set => img = value; }
        public string Name { get => name; set => name = value; }
    }
}
