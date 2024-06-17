using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    public class Városvezetés
    {
        public readonly List<Város> városÉvei;

        public Városvezetés()
        {
            városÉvei = new();
        }

        public int Újév(int p, int j, int ny, int e)
        {
            Város újVáros = new Város(p, j, ny, e);
            újVáros.Meglátogat();
            városÉvei.Add(újVáros);
            return városÉvei[városÉvei.Count - 1].pont;
        }

        public int Legjobbév()
        {
            int index = 0;
            int legjobbpont = városÉvei[0].pont;

            if (legjobbpont == null)
            {
                throw new Exception();
            }

            for(int i = 0; i < városÉvei.Count; i++)
            {
                if (városÉvei[i].pont > legjobbpont)
                {
                    legjobbpont = városÉvei[i].pont;
                    index = i;
                }
            }

            return index + 1;
        }
    }
}
