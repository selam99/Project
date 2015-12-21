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
    public partial class benejson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //format should look like this: {“Records”:[

            // Response.Write(String.Format("{2}{0}{1}{0}: {3}", "\"", "Records", "{", "["));
            Response.Write("{\"Records\":[");


            string connectionString = ConfigurationManager.ConnectionStrings["slm"].ConnectionString;
            string queryString = "SELECT * FROM dbo.benefit";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    int x = 0;
                    string Member_ID = "10418";
                    string First_Name = "Sharlin";
                    string Last_Name = "Davis";
                    string Date__Of_Birth = "10/20/70";
                    string Subscriber = "Sharlin_Davis";
                    string Amount_Paid = "$900";
                    string Amount_Claimed = "$300";
                    string Relationship = "Member";

                    while (reader.Read())
                    {
                        Member_ID = reader[0] + " ";
                        First_Name = reader[1].ToString();
                        Last_Name = reader[2].ToString();
                        Date__Of_Birth = reader[3].ToString();
                        Subscriber = reader[4].ToString();
                        Amount_Paid = reader[5].ToString();
                        Amount_Claimed = reader[6].ToString();
                        Relationship = reader[7].ToString();
                        if (x == 0)
                        {
                            Response.Write("{");
                        }
                        else
                        {
                            Response.Write(",{");

                        }
                        Response.Write(String.Format("\"Member_ID\":\"{0}\"", Member_ID));
                        Response.Write(",");
                        Response.Write(String.Format("\"First_Name\":\"{0}\"", First_Name));
                        Response.Write(",");
                        Response.Write(String.Format("\"Last_Name\":\"{0}\"", Last_Name));
                        Response.Write(",");
                        Response.Write(String.Format("\" Date__Of_Birth\":\"{0}\"", Date__Of_Birth));
                        Response.Write(",");
                        Response.Write(String.Format("\" Subscriber\":\"{0}\"", Subscriber));
                        Response.Write(",");
                        Response.Write(String.Format("\"Amount_Paid\":\"{0}\"", Amount_Paid));
                        Response.Write(",");
                        Response.Write(String.Format("\"Amount_Claimed\":\"{0}\"", Amount_Claimed));
                        Response.Write(",");
                        Response.Write(String.Format("\"Relationship\":\"{0}\"", Relationship));
                        Response.Write(",");
                        Response.Write("]");
                        Response.Write("}");
                    }
                }


                // format should look like this: ]}   

                //Response.Write(String.Format("{0} {1}", "]", "}"));

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }
    }
}