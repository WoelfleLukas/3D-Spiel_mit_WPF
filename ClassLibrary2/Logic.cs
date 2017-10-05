using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    class Logic :ILogic
    {
        private Thread Ticker;
        private List<Planet> planeten;

        private void Tick()
        {
            Thread.Sleep(100);
            planeten.ForEach(AendereRessourcen);
        }

        private void AendereRessourcen(Planet p)
        {
            p.VeraendereBevoelkerung();
            p.VerbraucheProdukte();
        }

        public Logic()
        {
            Ticker = new Thread(Tick);
            Ticker.Start();
        }

        public List<Planet> GetPlaneten()
        {
            return planeten;
        }
    }
}
