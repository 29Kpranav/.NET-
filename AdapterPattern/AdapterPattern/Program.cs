using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main()
        {
            // Using the Adapter to interact with the LegacyRectangle
            LegacyRectangle legacyRectangle = new LegacyRectangle();
            IShape adaptedRectangle = new RectangleAdapter(legacyRectangle);

            adaptedRectangle.Display(10, 20, 50, 30);
        }
    }

}
