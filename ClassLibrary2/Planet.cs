using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    class Planet
    {
        private Position pos;
        private double bevoelkerung;
        private List<Produkt> produkte;
        private Produkttyp produktionsTyp;
        private double produktionsMenge = 100;

        public Position Pos { get => pos; set => pos = value; }
        public double Bevoelkerung { get => bevoelkerung; set => bevoelkerung = value; }
        internal List<Produkt> Produkte { get => produkte; set => produkte = value; }
        internal Produkttyp ProduktionsTyp { get => produktionsTyp; set => produktionsTyp = value; }
        public double ProduktionsMenge { get => produktionsMenge; set => produktionsMenge = value; }

        public Planet()
        {

        }

        public void VeraendereBevoelkerung()
        {
            if(produkte[0].Menge>0)
            {
                if (bevoelkerung < 1000) bevoelkerung *= 1.01;
                else if (produkte[1].Menge > 0 && produkte[2].Menge > 0 && produkte[3].Menge > 0 && produkte[4].Menge > 0)
                    bevoelkerung *= 1.01;
            }
        }

        public void VerbraucheProdukte()
        {
            produkte.ForEach(delegate(Produkt p) { if (p.Menge > 0) p.Menge -= bevoelkerung*0.01; });
            produkte.Find(delegate (Produkt p) { if (p.Typ == ProduktionsTyp) { return true; } else { return false; } }).Menge += ProduktionsMenge;
        }

        public void VerbessereProduktionsmenge()
        {
            ProduktionsMenge *= 1.1;
        }
    }
}
