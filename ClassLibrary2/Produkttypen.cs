using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    class Produkttypen
    {
        private static List<Produkttyp> produkttypen;

        public static List<Produkttyp> GetProdukttypen()
        {
            if(produkttypen==null)
            {
                produkttypen = new List<Produkttyp>() { };
                produkttypen.Add(new Produkttyp() { Name = "Nahrung" });
                produkttypen.Add(new Produkttyp() { Name = "Wasser" });
                produkttypen.Add(new Produkttyp() { Name = "Gas" });
                produkttypen.Add(new Produkttyp() { Name = "Eisen" });
                produkttypen.Add(new Produkttyp() { Name = "Holz" });
            }
            return produkttypen;
        }
    }
}
