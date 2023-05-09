using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO[dbo].[DEPT] ([DEPTNO],[DNAME],[LOC])
                            VALUES(@DEPTNO,@DNAME,@LOC)";

            cmd.Parameters.AddWithValue("@DEPTNO",txtDeptNo.Text);
            cmd.Parameters.AddWithValue("@DNAME",txtDeptName.Text);
            cmd.Parameters.AddWithValue("@LOC",txtDeptLoc.Text);
            cmd.ExecuteNonQuery();
        }
         


        
       protected void btnUpdate_Click(object sender, EventArgs e)
        {

            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE [dbo].[DEPT]
                                       SET [DEPTNO] = @DEPTNO
                                          ,[DNAME] = @DNAME
                                          ,[LOC] = @LOC
                                     WHERE DEPTNO=@DEPTNO";
            Dept d=new Dept();

            cmd.Parameters.AddWithValue("@DEPTNO",txtDeptNo.Text);
            cmd.Parameters.AddWithValue("@DNAME",txtDeptName.Text);
            cmd.Parameters.AddWithValue("@LOC",txtDeptLoc.Text);
            cmd.ExecuteNonQuery();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [DEPTNO],[DNAME],[LOC] FROM [dbo].[DEPT] WHERE [DEPTNO]=@DEPTNO";
            cmd.Parameters.AddWithValue("@DEPTNO", txtDeptNo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtDeptLoc.Text = dr[2].ToString();
                txtDeptName.Text = dr[1].ToString();
            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM [dbo].[DEPT] WHERE DEPTNO=@DEPTNO";
            cmd.Parameters.AddWithValue("@DEPTNO", txtDeptNo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtDeptLoc.Text = dr[2].ToString();
                txtDeptName.Text = dr[1].ToString();
            }

            cmd.Parameters.AddWithValue("@DEPTNO", txtDeptNo.Text);
            cmd.Parameters.AddWithValue("@DNAME", txtDeptName.Text);
            cmd.Parameters.AddWithValue("@LOC", txtDeptLoc.Text);
            //cmd.ExecuteNonQuery();
        }
    }
}