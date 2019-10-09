using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СS5
{
    abstract partial class Plant     
    { 
        public struct Charact
        {
            public string color;
            public string location;
            public short years;

            public void Show()
            {
                Console.WriteLine($"{color}\t{location}\t{years}");
            }
        }
    }
}
