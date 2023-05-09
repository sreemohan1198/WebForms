using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Program
    {
        private static List<Dept> insertDetails()
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO[dbo].[DEPT] ([DEPTNO],[DNAME],[LOC])
                            VALUES(@DEPTNO,@DNAME,@LOC)";
            

            cmd.Parameters.AddWithValue("@DEPTNO", 15);
            cmd.Parameters.AddWithValue("@DNAME", "SRIDEVI");
            cmd.Parameters.AddWithValue("@LOC", "VA");

        }
        
        
        
           
    }
}