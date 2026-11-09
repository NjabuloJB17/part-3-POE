using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Part_2.database
{
    public class get_performance
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        // method to get all performance records
        public List<string> get_all_performance()
        {
            List<string> performance = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM performance";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Performance ID: " + reader["performance_id"].ToString();
                            message += ", Performance History: " + reader["performance_history"].ToString();
                            message += ", Participant ID: " + reader["participant_id"].ToString();

                            performance.Add(message);
                        }
                    }
                }
            }

            return performance;
        }

        // method to get performance by participant ID
        public List<string> get_performance_by_participant(int participant_id)
        {
            List<string> performance = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM performance WHERE participant_id = @participant_id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Performance ID: " + reader["performance_id"].ToString();
                            message += ", Performance History: " + reader["performance_history"].ToString();
                            message += ", Participant ID: " + reader["participant_id"].ToString();

                            performance.Add(message);
                        }
                    }
                }
            }

            return performance;
        }

        // method to add performance


        // method to add performance
        public string add_performance(string performance_history, int participant_id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO performance
                                 (performance_history, participant_id)
                                 VALUES (@performance_history, @participant_id)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@performance_history", performance_history);
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Performance added successfully";
                    }
                }
            }

            return message;
        }



        // method to update performance
        public string update_performance(int id, string performance_history)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"UPDATE performance
                          SET performance_history = @performance_history
                          WHERE performance_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@performance_history", performance_history);
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Performance updated successfully";
                    }
                }
            }

            return message;
        }

        // method to delete performance
        public string delete_performance(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"DELETE FROM performance WHERE performance_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Performance deleted successfully";
                    }
                }
            }

            return message;
        }

    }
}