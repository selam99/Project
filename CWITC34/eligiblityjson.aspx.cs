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
    public partial class eligiblityjson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //format should look like this: {“Records”:[

            // Response.Write(String.Format("{2}{0}{1}{0}: {3}", "\"", "Records", "{", "["));
            Response.Write("{\"Records\":[");


            string connectionString = ConfigurationManager.ConnectionStrings["slm"].ConnectionString;
            string queryString = "select  M.memberID, M.firstname, M.lastname, M.DateofBirth, M.subscriber, C.amountpaid, C.amountclaimed, M.relation From Member m, Claim c where M.MemberID = C.MemberID order by lastname;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    
                    int x = 0;
                    string patient_name = "";
                    string patient_dob = "";
                    string subscriber_name = "";
                    while (reader.Read())
                    {
                        patient_name = reader[1] + " " + reader[2];
                        patient_dob = reader[3].ToString();
                        subscriber_name = reader[4].ToString();
                        if(x == 0)
                        {
                            Response.Write("{");
                        }
                        else{
                            Response.Write(",{");

                        }
                        Response.Write(String.Format("\"patient_name\":\"{0}\"", patient_name));
                        Response.Write(",");
                        Response.Write(String.Format("\"patient_dob\":\"{0}\"", patient_dob));
                        Response.Write(",");
                        Response.Write(String.Format("\"subscriber_name\":\"{0}\"", subscriber_name));
                        Response.Write("}");
                        


                        //                        Response.Write(String.Format("{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));


                        //format should look like this: ,{“sql01”:”sql02”}

                        //                            Response.Write(String.Format(",{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));
                        x = x + 1;


                    }
                    Response.Write("]}");
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