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
    public partial class claimjson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //format should look like this: {“Records”:[

            // Response.Write(String.Format("{2}{0}{1}{0}: {3}", "\"", "Records", "{", "["));
            Response.Write("{\"Records\":[");


            string connectionString = ConfigurationManager.ConnectionStrings["slm"].ConnectionString;
            string queryString = "SELECT * FROM dbo.claim";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                { 
                Response.Write("{\"Records\":[");
                int x = 0;
                string Claim_ID = "";
                string Member_ID = "";
                string Amount_Paid = "";
                string Updated_Date = "";
                string Amount_Claimed = "";
                    while (reader.Read())
                {
                    Claim_ID = reader[1].ToString();
                    Member_ID = reader[2].ToString();
                    Amount_Paid = reader[3].ToString();
                    Updated_Date = reader[4].ToString();
                    Amount_Claimed = reader[5].ToString();
                    Response.Write("{");
                    Response.Write(String.Format("\"Claim_ID\":\"{0}\"", Claim_ID));
                    Response.Write(",");
                    Response.Write(String.Format("\"Member_ID\":\"{0}\"", Member_ID));
                    Response.Write(",");
                    Response.Write(String.Format("\"Updated_Date\":\"{0}\"", Updated_Date));
                    Response.Write(",");
                    Response.Write(String.Format("\"Amount_Claimed\":\"{0}\"", Amount_Claimed));
                    Response.Write("}");
                    Response.Write("}");
                    Response.Write("}");
                    Response.Write("}");
                    Response.Write("]");
                    Response.Write("}");


                    //                        Response.Write(String.Format("{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));


                    //format should look like this: ,{“sql01”:”sql02”}

                    //                            Response.Write(String.Format(",{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));
                    x = x + 1;


                }
                }
                //format should look like this: ]}   

                //                    Response.Write(String.Format("{0} {1}", "]", "}")); }

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();

                }
            }
        }
    }
}