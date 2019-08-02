using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaldd
{
    public partial class WebForm1 : System.Web.UI.Page
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
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\version\documents\visual studio 2015\Projects\practicaldd\practicaldd\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from TBLSALARYMST";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
           
        }
        protected void Insert(object sender, EventArgs e)
        {
            string connection;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\version\documents\visual studio 2015\Projects\practicaldd\practicaldd\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "insert into TBLSALARYMST (ID,EMPID,EMPNAME,MONTH,SALARY)values('16','5','asa','FEB','50') ";
            SqlCommand cmd = new SqlCommand(query, con);
            DropDownList1.Items.Insert(0, new ListItem("Add New", ""));
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            // this.bindgrid();
            DropDownList1.Items.Add(new ListItem("item"));
        }

        protected void btn4_Click(object sender, EventArgs e)
        {

        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.SelectedItem.Text;
            TextBox2.Text = DropDownList2.SelectedItem.Text;
            TextBox3.Text =txt1.Text;
            string connection;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\version\Documents\Visual Studio 2015\Projects\practicaldd\practicaldd\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            int salary = Convert.ToInt32(TextBox3.Text);
            string query="Insert into TBLSALARYMST (EMPNAME,MONTH,SALARY) VALUES('"+TextBox1.Text+"','"+TextBox2.Text+"','"+salary+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            this.bindgrid();

        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.SelectedItem.Text;
            TextBox2.Text = DropDownList2.SelectedItem.Text;
            TextBox3.Text = txt1.Text;
            string connection;
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\version\Documents\Visual Studio 2015\Projects\practicaldd\practicaldd\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            int salary = Convert.ToInt32(TextBox3.Text);
            string query = "DELETE FROM TBLSALARYMST WHERE SALARY='"+salary+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            this.bindgrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connection;
           
            connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\version\documents\visual studio 2015\Projects\practicaldd\practicaldd\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (DropDownList3.SelectedItem.Text.Equals("1"))
            {
                string query = "select ID,NAME,AGE from TBLEMPMST WHERE AGE>25";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataSourceID = string.Empty;
                GridView3.DataBind();

            }
            else if (DropDownList3.SelectedItem.Text.Equals("2"))
            {
                string query5 = "select TBLSALARYMST.EMPID,SUM(TBLSALARYMST.SALARY),TBLEMPMST.NAME FROM TBLSALARYMST INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID GROUP BY TBLSALARYMST.EMPID,TBLEMPMST.NAME ";
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
                string query = "select TBLSALARYMST.EMPID,TBLSALARYMST.SALARY , CASE WHEN TBLSALARYMST.MONTH='MAR' THEN 'MAR' ELSE '' END AS MONTH FROM TBLSALARYMST INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID ORDER BY TBLSALARYMST.EMPID ";
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
                   // string query = "select SUM(TBLSALARYMST.SALARY) FROM TBLSALARYMST GROUP BY TBLSALARYMST.MONTH";
                    string query1= "select SUM(TBLSALARYMST.SALARY)from TBLSALARYMST INNER JOIN TBLEMPMST ON TBLEMPMST.ID = TBLSALARYMST.EMPID WHERE TBLEMPMST.AGE>25 GROUP BY TBLSALARYMST.MONTH ";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    GridView3.DataSource = rd;
                    GridView3.DataSourceID = string.Empty;
                    GridView3.DataBind();

                }
            }
            con.Close();
        }

       
    }
}