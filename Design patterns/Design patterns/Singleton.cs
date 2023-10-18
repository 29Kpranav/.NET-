using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    
    public sealed class singleTonclass
    {
        private static singleTonclass instance;
        private static object obj;

        private singleTonclass() { 
        
        }

        public static singleTonclass GetInstance()
        {
            lock (obj)
            {
                if(instance == null)
                {
                    instance = new singleTonclass();
                }
            }
            return instance;
        }
    }

    class program
    {
        static void Main(string[] args) {
            singleTonclass s = singleTonclass.GetInstance();


        }
    }
}
