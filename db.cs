using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc_cnpm
{
    class db
    {
        public const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=bcao_cnpm;Integrated Security=True";
        public static SqlConnection Connection = new SqlConnection(ConnectionString);
    }
}
