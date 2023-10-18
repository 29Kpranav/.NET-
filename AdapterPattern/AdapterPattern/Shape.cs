using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IShape
    {
        void Display(int x, int y, int width, int height);
    }

}
