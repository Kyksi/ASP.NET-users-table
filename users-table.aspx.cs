using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ASP.NET_pages
{
    public partial class users_table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connect();
            }
            else
            {
                DodajDoStopki();
            }
        }

        public void connect()
        {
            String connectionString = @"Data Source=SQL6004.site4now.net;Initial Catalog=DB_A4475E_database1;User Id=DB_A4475E_database1_admin;Password=Root_2000;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * from users";
            command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


           DodajDoStopki();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            String id = GridView1.DataKeys[e.RowIndex]["Id"].ToString();
            String connectionString = @"Data Source=SQL6004.site4now.net;Initial Catalog=DB_A4475E_database1;User Id=DB_A4475E_database1_admin;Password=Root_2000;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("delete from users where id={0}", id);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            connect();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            connect();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            connect();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = GridView1.DataKeys[e.RowIndex]["Id"].ToString();
            String connectionString = @"Data Source=SQL6004.site4now.net;Initial Catalog=DB_A4475E_database1;User Id=DB_A4475E_database1_admin;Password=Root_2000;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                DataControlFieldCell objCell = (DataControlFieldCell)GridView1.Rows[e.RowIndex].Cells[i];
                GridView1.Columns[i].ExtractValuesFromCell(e.NewValues, objCell, DataControlRowState.Edit, false);
            }
            command.CommandText = string.Format("update users set name='{0}',surname='{1}', city='{2}' where ID={3}", e.NewValues["name"], e.NewValues["surname"], e.NewValues["city"], id);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GridView1.EditIndex = -1;

            connect();
        }

        public void DodajDoStopki()
        {
            
            TextBox txt = new TextBox();
            TextBox txt2 = new TextBox();
            TextBox txt3 = new TextBox();
            Button btn = new Button();
            btn.ID = new Guid().ToString();
            btn.CssClass = "btn btn-success";
            btn.Text = "Add +";
            btn.Click += new EventHandler(AddNew);
            GridView1.FooterRow.Cells[1].Controls.Add(txt);
            GridView1.FooterRow.Cells[2].Controls.Add(txt2);
            GridView1.FooterRow.Cells[3].Controls.Add(txt3);
            GridView1.FooterRow.Cells[5].Controls.Add(btn);
            
        }

        public void AddNew(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=SQL6004.site4now.net;Initial Catalog=DB_A4475E_database1;User Id=DB_A4475E_database1_admin;Password=Root_2000;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            String name = ((TextBox)GridView1.FooterRow.Cells[1].Controls[0]).Text;
            String surname = ((TextBox)GridView1.FooterRow.Cells[2].Controls[0]).Text;
            String city = ((TextBox)GridView1.FooterRow.Cells[3].Controls[0]).Text;
            command.CommandText = String.Format("insert into users(name, surname, city) values('{0}','{1}', '{2}')", name, surname, city);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            connect();
        }
    }
}