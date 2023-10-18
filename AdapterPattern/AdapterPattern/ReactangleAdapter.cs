using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class RectangleAdapter : IShape
    {
        private LegacyRectangle legacyRectangle;

        public RectangleAdapter(LegacyRectangle legacyRectangle)
        {
            this.legacyRectangle = legacyRectangle;
        }

        public void Display(int x, int y, int width, int height)
        {
            int x1 = x;
            int y1 = y;
            int x2 = x + width;
            int y2 = y + height;

            legacyRectangle.Draw(x1, y1, x2, y2);
        }
    }

}
