using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    public abstract class Állapot
    {
        public abstract List<int> SetÁktuális(int j, int ny, int e);
        public abstract string ToString();
    }
}
