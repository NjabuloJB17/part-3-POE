
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Part_2.database
{
    public class get_profile
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        // method to get all participant profiles
        public List<string> get_all_profiles()
        {
            List<string> profiles = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM participant";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Participant ID: " + reader["participant_id"].ToString();
                            message += ", Name: " + reader["participant_name"].ToString();
                            message += ", Surname: " + reader["participant_surname"].ToString();
                            message += ", Email: " + reader["participant_email"].ToString();
                            message += ", Phone: " + reader["participant_number"].ToString();

                            profiles.Add(message);
                        }
                    }
                }
            }

            return profiles;
        }

        // method to get profile by participant ID
        public string get_profile_by_id(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM participant WHERE participant_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            message = "Participant ID: " + reader["participant_id"].ToString();
                            message += ", Name: " + reader["participant_name"].ToString();
                            message += ", Surname: " + reader["participant_surname"].ToString();
                            message += ", Email: " + reader["participant_email"].ToString();
                            message += ", Phone: " + reader["participant_number"].ToString();
                        }
                    }
                }
            }

            return message;
        }

        // method to update participant profile
        public string update_profile(int id, string name, string surname,
                                     string email, string number)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"UPDATE participant
                          SET participant_name = @name,
                              participant_surname = @surname,
                              participant_email = @email,
                              participant_number = @number
                          WHERE participant_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@name", name);
                    run_query.Parameters.AddWithValue("@surname", surname);
                    run_query.Parameters.AddWithValue("@email", email);
                    run_query.Parameters.AddWithValue("@number", number);
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Profile updated successfully";
                    }
                }
            }

            return message;
        }

        // method to add participant profile
        public string add_profile(string name, string surname,
                                  string email, string number)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO participant
                          (participant_name, participant_surname,
                           participant_email, participant_number)
                          VALUES (@name, @surname, @email, @number)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@name", name);
                    run_query.Parameters.AddWithValue("@surname", surname);
                    run_query.Parameters.AddWithValue("@email", email);
                    run_query.Parameters.AddWithValue("@number", number);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Participant registered successfully";
                    }
                }
            }

            return message;
        }

        // method to delete participant profile
        public string delete_profile(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"DELETE FROM participant WHERE participant_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Participant profile deleted successfully";
                    }
                }
            }

            return message;
        }

    }
}
