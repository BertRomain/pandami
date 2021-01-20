using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulationEF
{
    public class AccessBddEF
    {
        public void GetNomAndRegionFromBdd()
        {
            using (bddEQLEntities ef = new bddEQLEntities())
            {
                ef.GetClientAndRegion();
            }
        }
    }
}
