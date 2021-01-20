using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ManipulationsBDD
{
    public class BddLocale
    {
        public static bool ouvreConnection()
        {
            bool ouvertureOk = false;
            SqlCommand cmd = new SqlCommand();
            return ouvertureOk;
        }
    }
}
