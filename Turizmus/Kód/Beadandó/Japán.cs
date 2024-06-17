using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    public class Japán : TúristaTipús
    {
        public double Szorzó(Lepusztult v)
        {
            return 0.0;
        }
        public double Szorzó(Átlagos v)
        {
            return 1.0;
        }
        public double Szorzó(Jó v)
        {
            return 1.2;
        }
    }
}
