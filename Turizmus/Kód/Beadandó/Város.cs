using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    public class Város
    { 
        public int pont { get; private set; }
        public readonly List<int> tervezett;
        public readonly List<int> aktuális;
        public nint bevétel {  get; private set; }
        public Állapot állapot { get; private set; }

        public Város(int p, int j, int ny, int e)
        {
            this.pont = p;
            állapot = Állapotok();
            this.tervezett = new();
            this.tervezett.Add(j);
            this.tervezett.Add(ny);
            this.tervezett.Add(e);
            this.aktuális = new();
            this.aktuális = állapot.SetÁktuális(j, ny, e);
            this.bevétel = 0;
            
        }

        public int Meglátogat()
        {
            nint pénz = (nint)(aktuális[0] + aktuális[1] + aktuális[2]) * 100000;
            if(pénz > 20000000000)
            {
                nint költőpénz = pénz - (nint)20000000000;
                nint pluszpont = (nint)Math.Floor((decimal)költőpénz / 50000000);
                Console.WriteLine(pluszpont);
                pénz = pénz - (nint)(pluszpont * 50000000);
                nint maradék = ÁllapotVáltozás(pluszpont);
                pénz = pénz + (nint)(maradék * 50000000);
            }else
            {
                ÁllapotVáltozás(0);
            }
            bevétel = pénz;
            return this.pont;
        }

        private nint ÁllapotVáltozás(nint p)
        {
            nint köztes = pont - (int)Math.Floor((double)(aktuális[1] / 100)) - (int)Math.Floor((double)(aktuális[2] / 500));
            köztes += p;
            switch (köztes)
            {
                case < 0:
                    pont = 0;
                    köztes = 0;
                    break;
                case > 100:
                    pont = 100;
                    köztes -= 100;
                    break;
                default:
                    pont = (int)köztes;
                    köztes = 0;
                    break;
            }
            állapot = Állapotok();
            return köztes;
        }

        private Állapot Állapotok()
        {
            switch (pont)
            {
                case < 34:
                    return Lepusztult.Instance();
                    break;
                case < 68:
                    return Átlagos.Instance();
                    break;
                case < 101:
                    return Jó.Instance();
                    break;
                default:
                    throw new Exception();
                    break;
            }
        }
    }
}
