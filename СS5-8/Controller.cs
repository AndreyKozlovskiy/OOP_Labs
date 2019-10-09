using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СS5
{
    static class Controller
    {
       static  public int Buy(GetBouqet<Plant> COL)
        {
            return COL.BuyBouquet();
        }
    }
}
