using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaldd
{
    public partial class WebForm2 : System.Web.UI.Page
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
                string query = "select  TBLEMPMST.ID,TBLEMPMST.NAME,TBLSALARY.EMPID,TBLSALARY.MONTH,TBLSALARY.SALARY from TBLSALARY LEFT  JOIN TBLEMPMST ON TBLEMPMST.ID=TBLSALARY.EMPID WHERE TBLSALARY.SALARY!='0'";
                //string query1 = "select EMPNAME,SALARY,MONTH FROM TBLSALARYMST";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataSourceID = null;
                GridView1.DataBind();
            
            con.Close();

        }
        

        protected void btn2_Click1(object sender, EventArgs e)
        {
          //  TextBox1.Text = DropDownList1.SelectedItem.Text;
           // TextBox2.Text = DropDownList2.SelectedItem.Text;
            //TextBox3.Text = txt1.Text;
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            //  int salary = Convert.ToInt32(TextBox3.Text);
            //  string query = "Insert into TBLSALARYMST (EMPNAME,MONTH,SALARY) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + salary + "')";
            //String query1 ="insert into TBLSALARYMST(EMPNAME,MONTH,SALARY) VALUES(@NAME,@MONTH,@SALARY)";
            SqlCommand cmd = new SqlCommand("update", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@salary", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@month", DropDownList2.SelectedItem.Text);
            //cmd.Parameters.AddWithValue("@name", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@salary1", txt1.Text);

            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
         
            GridView1.DataBind();
             this.bindgrid();

        }

        protected void btn5_Click(object sender, EventArgs e)
        {
           // TextBox1.Text = DropDownList1.SelectedItem.Text;
           // TextBox2.Text = DropDownList2.SelectedItem.Text;
           // TextBox3.Text = txt1.Text;
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("procedure", con);
            cmd.Parameters.AddWithValue("@name", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@month", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@SALARY", txt1.Text);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
          //  int salary = Convert.ToInt32(txt1.Text);
           // string query = "DELETE FROM TBLSALARYMST WHERE SALARY='" + salary + "'";
          //  SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            this.bindgrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                // string query = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY),TBLEMPMST.ID from TBLEMPMST , TBLSALARYMST WHERE TBLEMPMST.ID=TBLSALARYMST.EMPID  GROUP BY TBLSALARYMST.SALARY,TBLEMPMST.ID,TBLEMPMST.NAME ";
                // string query3 = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY),TBLEMPMST.ID from TBLEMPMST INNER JOIN TBLSALARYMST ON TBLEMPMST.ID=TBLSALARYMST.EMPID";
                // string query1 = "SELECT SUM(SALARY),EMPID FROM TBLSALARYMST WHERE TBLEMPMST.ID=TBLSALARYMST.EMPID GROUP BY EMPID ";
                // string query2 = "SELECT TBLSALARYMST.ID, TBLEMPMST.NAME,SUM( TBLSALARYMST.SALARY) FROM TBLSALARYMST INNER JOIN TBLEMPMST ON TBLSALARYMST.EMPID = TBLEMPMST.ID; ";
                SqlCommand cmd = new SqlCommand(query5, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else if (DropDownList3.SelectedItem.Text.Equals("3"))
            {
                string query = "select TBLEMPMST.NAME,TBLSALARY.SALARY , CASE WHEN TBLSALARY.MONTH='MAR' THEN 'MAR' ELSE '' END AS MONTH FROM TBLSALARYINNER JOIN TBLEMPMST ON TBLEMPMST.ID =TBLSALARY.EMPID ORDER BY TBLSALARY.SALARY ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else
            {
                if (DropDownList3.SelectedItem.Text.Equals("4"))
                {
                   //  string query = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY) AS [SUM OF SALARY]FROM TBLSALARYMST INNER JOIN (SELECT TBLSALARYMST.SALARY, FROM TBLSALARYMST GROUP BY TBLSALARYMST.MONTH) TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID WHERE TBLEMPMST.AGE>25 ";
                   string query1 = "select TBLEMPMST.NAME,SUM(TBLSALARY.SALARY) as [SUM OF SALARY] from TBLSALARY INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARY.EMPID WHERE TBLEMPMST.AGE>25  GROUP BY TBLSALARY.MONTH,TBLEMPMST.NAME ";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    GridView3.DataSource = rd;
                    GridView3.DataSourceID = string.Empty;
                    GridView3.DataBind();

                }
            }
            con.Close();
        }

        

       

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
         //   HiddenField1.Value = row.Cells[1].Text;
           // HiddenField2.Value = row.Cells[2].Text;
            //TextBox1.Text = row.Cells[2].Text;
            //TextBox2.Text = row.Cells[1].Text;
            DropDownList1.SelectedItem.Text = row.Cells[3].Text;
     
            DropDownList2.SelectedItem.Text = row.Cells[4].Text;
            txt1.Text = row.Cells[5].Text;

           

        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            string connection;
            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@salary", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@month", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@name", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@salary1", txt1.Text);
           
            SqlDataReader rd=cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            this.bindgrid();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connection;

            connection = @"Data Source=desktop-c9bhqlo;Initial Catalog=divya;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
          //  GridViewRow row = GridView3.SelectedRow;
            // DropDownList3.SelectedItem.Text = row.Cells[0].Text;
            // if (DropDownList3.SelectedItem.Text.Equals("1"))
            //{
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
                // string query = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY),TBLEMPMST.ID from TBLEMPMST , TBLSALARYMST WHERE TBLEMPMST.ID=TBLSALARYMST.EMPID  GROUP BY TBLSALARYMST.SALARY,TBLEMPMST.ID,TBLEMPMST.NAME ";
                // string query3 = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY),TBLEMPMST.ID from TBLEMPMST INNER JOIN TBLSALARYMST ON TBLEMPMST.ID=TBLSALARYMST.EMPID";
                // string query1 = "SELECT SUM(SALARY),EMPID FROM TBLSALARYMST WHERE TBLEMPMST.ID=TBLSALARYMST.EMPID GROUP BY EMPID ";
                // string query2 = "SELECT TBLSALARYMST.ID, TBLEMPMST.NAME,SUM( TBLSALARYMST.SALARY) FROM TBLSALARYMST INNER JOIN TBLEMPMST ON TBLSALARYMST.EMPID = TBLEMPMST.ID; ";
                SqlCommand cmd = new SqlCommand(query5, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();
            }
            else if (DropDownList3.SelectedItem.Text.Equals("3"))
            {
               // string query = "select TBLEMPMST.NAME,TBLSALARYMST.SALARY , CASE WHEN TBLSALARYMST.MONTH='MAR' THEN 'MAR' ELSE '0' END AS MONTH FROM TBLSALARYMST INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID ORDER BY TBLSALARYMST.SALARY ";
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
                    //  string query = "select TBLEMPMST.NAME,SUM(TBLSALARYMST.SALARY) AS [SUM OF SALARY]FROM TBLSALARYMST INNER JOIN (SELECT TBLSALARYMST.SALARY, FROM TBLSALARYMST GROUP BY TBLSALARYMST.MONTH) TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID WHERE TBLEMPMST.AGE>25 ";
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
          
            SqlCommand cmd = new SqlCommand("addnewdata", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@name", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@salary", txt1.Text);
            SqlDataReader rd = cmd.ExecuteReader();
           
            rd.Close();
           // SqlCommand cmd1=new SqlCommand("select TBLEMPMST.NAME,TBLSALARY.MONTH,TBLSALARY.SALARY from TBLSALARY LEFT JOIN TBLEMPMST ON TBLEMPMST.ID=TBLSALARY.EMPID and TBLSALARY.SALARY!='0'", con);
            //SqlDataReader rd1 = cmd1.ExecuteReader();
           
           // GridView1.DataSource = rd1;
            //GridView1.DataSourceID = string.Empty;
            //GridView1.DataBind();
            con.Close();
            this.bindgrid();
          
        }

       
    }
}
    

