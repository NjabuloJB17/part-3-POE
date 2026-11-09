
using System;
using System.Data.SqlClient;

namespace prompt_users.database
{
    public class get_user_info
    {
        string message = string.Empty;

        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        //method to get user info
        //call it get_user_onfo_ById

        public string get_user_onfo_ById(int id)
        {
            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM participant WHERE participant_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    //send the participant id to the query
                    run_query.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message = reader["participant_id"].ToString();

                            message += ", name is " + reader["participant_name"].ToString();

                            message += ", surname is " + reader["participant_surname"].ToString();

                            message += ", email is " + reader["participant_email"].ToString();
                        }
                    }
                }

                connect.Close();
            }

            return message;
        }
    }
}
