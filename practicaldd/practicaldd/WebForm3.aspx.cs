using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaldd
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.bindgrid();
            }
        }
        protected void bindgrid()
        {
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select  TBLEMPMST.ID,TBLEMPMST.NAME,TBLSALARY.EMPID,TBLSALARY.MONTH,TBLSALARY.SALARY from TBLSALARY left JOIN TBLEMPMST ON TBLEMPMST.ID=TBLSALARY.EMPID WHERE TBLSALARY.SALARY!='0'";
            //string query1 = "select EMPNAME,SALARY,MONTH FROM TBLSALARYMST";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataSourceID = null;
            GridView1.DataBind();
            con.Close();


        }


        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            DropDownList4.SelectedItem.Text = row.Cells[2].Text;
            DropDownList5.SelectedItem.Text = row.Cells[4].Text;
            txt1.Text = row.Cells[5].Text;
            TextBox1.Text = row.Cells[1].Text;

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connection;

            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
           
            if (DropDownList3.SelectedItem.Text.Equals("1"))
            {
                string query = "select NAME,AGE from TBLEMPMST WHERE AGE>25";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else if (DropDownList3.SelectedItem.Text.Equals("2"))
            {
                string query5 = "select SUM(TBLSALARY.SALARY) AS [SUM OF SALARY] ,TBLEMPMST.NAME   FROM TBLSALARY INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARY.EMPID GROUP BY TBLEMPMST.NAME ";
               
                SqlCommand cmd = new SqlCommand(query5, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else if (DropDownList3.SelectedItem.Text.Equals("3"))
            {
              
                string query1 = "select TBLEMPMST.NAME,TBLSALARY.SALARY ,TBLSALARY.MONTH FROM TBLSALARY INNER JOIN TBLEMPMST ON TBLEMPMST.ID =TBLSALARY.EMPID where TBLSALARY.MONTH !='null' ORDER BY TBLSALARY.SALARY  ";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else
            {
                if (DropDownList3.SelectedItem.Text.Equals("4"))
                {
                  
                    string query1 = "select TBLEMPMST.NAME,SUM(TBLSALARY.SALARY) as [SUM OF SALARY] from TBLSALARY  INNER JOIN TBLEMPMST ON TBLEMPMST.ID =TBLSALARY.EMPID WHERE TBLEMPMST.AGE>25   GROUP BY TBLSALARY.MONTH,TBLEMPMST.NAME ORDER BY [SUM OF SALARY]";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    GridView3.DataSource = rd;
                    GridView3.DataSourceID = string.Empty;
                    GridView3.DataBind();

                }
            }
            con.Close();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            GridViewRow row = GridView1.SelectedRow;
            SqlCommand cmd2 = new SqlCommand("select ID from TBLEMPMST where NAME='" + DropDownList4.SelectedItem.Text + "'",con);
            int empid = (int)cmd2.ExecuteScalar();
            SqlCommand cmd = new SqlCommand("addnewdata", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month", DropDownList5.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@empid",empid);
            cmd.Parameters.AddWithValue("@salary", txt1.Text);
            SqlDataReader rd = cmd.ExecuteReader();

            
           

            con.Close();
            this.bindgrid();
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
          
            SqlCommand cmd = new SqlCommand("updatesalary", con);
            SqlCommand cmd2 = new SqlCommand("select ID from TBLEMPMST where NAME='" + DropDownList4.SelectedItem.Text + "'", con);
            int empid = (int)cmd2.ExecuteScalar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@salary", txt1.Text);
            cmd.Parameters.AddWithValue("@month", DropDownList5.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@empid",empid);

            SqlDataReader rd = cmd.ExecuteReader();
            con.Close();
            this.bindgrid();
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete", con);
            SqlCommand cmd2 = new SqlCommand("select ID from TBLEMPMST where NAME='" + DropDownList4.SelectedItem.Text + "'", con);
            int empid = (int)cmd2.ExecuteScalar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@salary", txt1.Text);
            cmd.Parameters.AddWithValue("@month", DropDownList5.SelectedItem.Text);

           
    
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            this.bindgrid();
        }
    }
    
}