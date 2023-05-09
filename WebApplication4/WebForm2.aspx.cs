using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }        
        protected void bnSubmit_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=TEACHER_STUDENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO [dbo].[STUDENT] ([STUDENT_ID],[STUDENT_NAME],[MARKS])
                                 VALUES(@STUDENT_ID,@STUDENT_NAME,@MARKS)";
            Student student = new Student();
            cmd.Parameters.AddWithValue("@STUDENT_ID", txtStudid.Text);
            cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStudname.Text);
            cmd.Parameters.AddWithValue("@MARKS", txtMarks.Text);
            cmd.ExecuteNonQuery();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=TEACHER_STUDENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE [dbo].[STUDENT]
                                   SET [STUDENT_ID] = @STUDENT_ID
                                      ,[STUDENT_NAME] = @STUDENT_NAME
                                      ,[MARKS] = @MARKS
                                 WHERE STUDENT_ID=@STUDENT_ID";
            Student student = new Student();
            cmd.Parameters.AddWithValue("@STUDENT_ID", txtStudid.Text);
            cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStudname.Text);
            cmd.Parameters.AddWithValue("@MARKS", txtMarks.Text);
            cmd.ExecuteNonQuery();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=TEACHER_STUDENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM [dbo].[STUDENT] WHERE STUDENT_ID=@STUDENT_ID";
            cmd.Parameters.AddWithValue("@STUDENT_ID",txtStudid.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtStudid.Text = dr[0].ToString();
                txtStudname.Text = dr[1].ToString();
                txtMarks.Text = dr[2].ToString();   
            }

            cmd.Parameters.AddWithValue("STUDENT_ID", txtStudid.Text);
            cmd.Parameters.AddWithValue("@STUDENTN_AME", txtStudname.Text);
            cmd.Parameters.AddWithValue("@MARKS", txtMarks.Text);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=TEACHER_STUDENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [STUDENT_ID],[STUDENT_NAME],[MARKS] FROM [dbo].[STUDENT] WHERE STUDENT_ID=@STUDENT_ID";
            cmd.Parameters.AddWithValue("@STUDENT_ID",txtStudid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtStudname.Text = reader[1].ToString();
                txtMarks.Text = reader[2].ToString();
            }                       
        }

    }
   
}