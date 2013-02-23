using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProcessCrash
{
    class Map
    {
        StreamReader map;
        public Map()
        {
            

        }
        
        public int[,] tab_bin = new int[9,49];
        public int[,] Getcol()
        {
            return tab_bin;
        }
    }
}
