using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
     public class LegacyRectangle
    {
        public void Draw(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine($"LegacyRectangle: Draw({x1}, {y1}, {x2}, {y2})");
        }
    }
}
