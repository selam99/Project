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
    public partial class profilejson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //format should look like this: {“Records”:[

            //Response.Write(String.Format("{2}{0}{1}{0}: {3}", "\"", "Records", "{", "["));
            Response.Write("{\"Records\":[");


            string connectionString = ConfigurationManager.ConnectionStrings["slm"].ConnectionString;
            string queryString = "SELECT * FROM dbo.provider";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    int x = 0;
                    while (reader.Read())
                    {
                        if (x == 0)
                        {
                            //format should look like this:  {“sql01”:”sql02”}

                            Response.Write(String.Format("{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));
                        }
                        else
                        {
                            //format should look like this: ,{“sql01”:”sql02”}

                            Response.Write(String.Format(",{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], reader[3], reader[2], "{", "\"", "}"));
                        }
                        x = x + 1;

                    }
                    //format should look like this: ]}   

                    Response.Write(String.Format("{0} {1}", "]", "}"));

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