using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ednevnik410b
{
    internal class konekcija
    {
        public static SqlConnection povezi()
        {
            string CS;
            CS = ConfigurationManager.ConnectionStrings["skola"].ConnectionString;
            SqlConnection rezultat = new SqlConnection(CS);
            return rezultat;
        }
    }
}
