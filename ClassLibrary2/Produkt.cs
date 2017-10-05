using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    class Produkt
    {
        private double menge;
        private Produkttyp typ;

        public double Menge { get => menge; set => menge = value; }
        internal Produkttyp Typ { get => typ; set => typ = value; }
    }
}
