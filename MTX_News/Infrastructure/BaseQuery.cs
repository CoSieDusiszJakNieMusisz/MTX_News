using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MTX_News.Infrastructure
{
    public abstract class BaseQuery
    {
        SqlConnection con;
        string cn;

        public BaseQuery()
        {
            string connectionString = "MultipleActiveResultSets = True; user id = aplikacjacennik; password = cenybambino!23; server = 10.0.10.5; database = CDNXL_MojeBambino; Data Source = 10.0.10.5; ";
            cn = connectionString;
        }

        public DataTable RunQuery(SqlCommand command)
        {                        
            DataTable result = new DataTable() { TableName = "result" };
            using (con = new SqlConnection(cn))
            {
                command.Connection = con;
                if (con.State != ConnectionState.Open)
                {
                    //try
                    //{
                    con.Open();
                    SqlDataReader wynik = command.ExecuteReader();
                    result.Load(wynik);
                    //}
                    //catch (Exception ex)
                    //{

                    //}
                }
                else
                {
                    //try
                    //{
                    SqlDataReader wynik = command.ExecuteReader();
                    result.Load(wynik);
                    con.Close();
                    //}
                    //catch (Exception ex)
                    //{

                    //}
                }
            }
               
            return result;
        }
    }
}