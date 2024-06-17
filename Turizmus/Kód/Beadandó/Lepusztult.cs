using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    public class Lepusztult : Állapot
    {
        public override string ToString()
        {
            return "Lepusztult";
        }

        public override List<int> SetÁktuális(int j, int ny, int e)
        {
            Japán japán = new Japán();
            Nyugati nyugati = new Nyugati();
            Egyéb egyéb = new Egyéb();
            List<int> list = new List<int>();
            list.Add((int)(j * japán.Szorzó(this)));
            list.Add((int)(ny * nyugati.Szorzó(this)));
            list.Add((int)(e * egyéb.Szorzó(this)));
            return list;
        }

        private static Lepusztult instance = null;
        public static Lepusztult Instance()
        {
            if (instance == null)
            {
                instance = new Lepusztult();
            }
            return instance;
        }
    }
}
