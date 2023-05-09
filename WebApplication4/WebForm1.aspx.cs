using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Dept> depts = getDeptName();
            //ddlDeptname.DataSource = depts;
            //ddlDeptname.DataTextField = "DNAME";
            //ddlDeptname.DataValueField = "DEPTNO";
            //ddlDeptname.DataBind();
            if (!Page.IsPostBack)
            {
                ddlDeptname.DataSource = depts;
                ddlDeptname.DataTextField = "DNAME";
                ddlDeptname.DataValueField = "DEPTNO";
                ddlDeptname.DataBind();
            }
        }

        protected void txtEmpno_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [EMPNO],[ENAME] FROM [dbo].[EMP] WHERE EMPNO=@EMPNO";

            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            //cmd.Parameters.AddWithValue("@LOC", txtDeptLoc.Text);
            cmd.ExecuteNonQuery();

        }

        private static List<Dept> getDeptName()
        {

            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [DEPTNO],[DNAME] FROM [dbo].[DEPT]";
            SqlDataReader dr = cmd.ExecuteReader();

            List<Dept> dept = new List<Dept>();

            while (dr.Read())
            {
                Dept d = new Dept();
                d.DEPTNO = Convert.ToInt32(dr[0]);
                d.DNAME = Convert.ToString(dr[1]);
                //emp.DEPTNO = Convert.ToInt32(dr[2]);
                dept.Add(d);
            }

            //cmd.ExecuteScalar().ToString();
            return dept;

        }

        protected void txtEname_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [EMPNO],[ENAME] FROM [dbo].[EMP] WHERE EMPNO=@EMPNO";

            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            cmd.ExecuteNonQuery();
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [JOB] FROM [dbo].[EMP]";

            cmd.Parameters.AddWithValue("@JOB", txtJob.Text);
            //cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            cmd.ExecuteNonQuery();
        }

        protected void txtMgr_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [MGR] FROM [dbo].[EMP]";

            cmd.Parameters.AddWithValue("@MGR", txtMgr.Text);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [HIREDATE] FROM [dbo].[EMP]";

            cmd.Parameters.AddWithValue("@HIREDATE", CalHiredate.UniqueID);
        }

        protected void txtSalary_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [SAL] FROM [dbo].[EMP]";

            cmd.Parameters.AddWithValue("@SAL", txtSalary.Text);
        }

        protected void txtComm_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT [COMM] FROM [dbo].[EMP]";

            cmd.Parameters.AddWithValue("@COMM", txtComm.Text);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO [dbo].[EMP]([EMPNO],[ENAME],[JOB],[MGR],[HIREDATE],[SAL],[COMM],[DEPTNO])
                                VALUES(@EMPNO,@ENAME,@JOB,@MGR,@HIREDATE,@SAL,@COMM,@DEPTNO)";

            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            cmd.Parameters.AddWithValue("@JOB", txtJob.Text);
            cmd.Parameters.AddWithValue("@MGR", txtMgr.Text);
            cmd.Parameters.AddWithValue("@HIREDATE", CalHiredate.SelectedDate);
            cmd.Parameters.AddWithValue("@SAL", txtSalary.Text);
            cmd.Parameters.AddWithValue("@COMM", txtComm.Text);
            cmd.Parameters.AddWithValue("@DEPTNO", ddlDeptname.SelectedValue);
            cmd.ExecuteNonQuery();
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"ALTER TABLE [dbo].[Emp] ADD EMAIL varchar(255)";
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE [dbo].[EMP]
                                   SET [EMPNO] = @EMPNO
                                      ,[ENAME] = @ENAME
                                      ,[JOB] = @JOB,
                                       [MGR]=@MGR,
                                       [HIREDATE]=@HIREDATE,
                                       [SAL]=@SAL,[COMM]=@COMM,[DEPTNO]=@DEPTNO,[EMAIL]=@EMAIL
                                 WHERE EMPNO=@EMPNO";
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            cmd.Parameters.AddWithValue("@JOB", txtJob.Text);
            cmd.Parameters.AddWithValue("@MGR", txtMgr.Text);
            cmd.Parameters.AddWithValue("@HIREDATE", CalHiredate.SelectedDate);
            cmd.Parameters.AddWithValue("@SAL", txtSalary.Text);
            cmd.Parameters.AddWithValue("@COMM", txtComm.Text);
            cmd.Parameters.AddWithValue("@DEPTNO", ddlDeptname.SelectedValue);
            cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
        }


        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT [EMPNO],[ENAME],[JOB],[MGR],[HIREDATE],[SAL],[COMM],[EMAIL] FROM [dbo].[EMP] WHERE [EMPNO]=@EMPNO";
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtEname.Text = dr[1].ToString();
                txtJob.Text = dr[2].ToString();
                txtMgr.Text = dr[3].ToString();
                //CalHiredate.SelectedDate = dr[4];
                txtSalary.Text = dr[5].ToString();
                txtComm.Text = dr[6].ToString();
                txtEmail.Text = dr[7].ToString();
              
            }


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=.;Initial Catalog=Scottdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM [dbo].[EMP] WHERE EMPNO=@EMPNO";
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtEname.Text = dr[1].ToString();
                txtJob.Text = dr[2].ToString();
                txtMgr.Text = dr[3].ToString();
                //CalHiredate.SelectedDate = dr[4];
                txtSalary.Text = dr[5].ToString();
                txtComm.Text = dr[6].ToString();
                txtEmail.Text = dr[7].ToString();
            }
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@ENAME", txtEname.Text);
            cmd.Parameters.AddWithValue("@JOB", txtJob.Text);
            cmd.Parameters.AddWithValue("@MGR", txtMgr.Text);
            cmd.Parameters.AddWithValue("@HIREDATE", CalHiredate.SelectedDate);
            cmd.Parameters.AddWithValue("@SAL", txtSalary.Text);
            cmd.Parameters.AddWithValue("@COMM", txtComm.Text);
            cmd.Parameters.AddWithValue("@DEPTNO", ddlDeptname.SelectedValue);
            cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
           
        }
    }
}
  