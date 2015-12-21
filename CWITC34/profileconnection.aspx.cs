using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace CWITC34
{
    public partial class profileconnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["slm"].ConnectionString;
            string queryString = "SELECT * FROM dbo.provider";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Response.Write(String.Format("{0}, {1},{2},{3}", reader[0], reader[1], reader[2], reader[3]));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }


        }
    }
}