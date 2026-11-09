using System.Data.SqlClient;
namespace Part_2.database
{
    public class get_results
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        // Get all results
        public string get_all_results()
        {
            string message = "";

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = "SELECT * FROM results";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message += "Result ID: " + reader["results_id"].ToString()
                                + ", Participant ID: " + reader["participant_id"].ToString()
                                + ", Event ID: " + reader["events_id"].ToString()
                                + ", Time: " + reader["result_time"].ToString()
                                + ", Position: " + reader["result_position"].ToString()
                                + "\n";
                        }
                    }
                }
            }

            return message;
        }

        // Add a result
        public string add_results(int participant_id, int events_id, string result_time, int result_position)
        {
            string message = "";

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO results
                    (participant_id, events_id, result_time, result_position)
                    VALUES (@participant_id, @events_id, @result_time, @result_position)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);
                    run_query.Parameters.AddWithValue("@events_id", events_id);
                    run_query.Parameters.AddWithValue("@result_time", result_time);
                    run_query.Parameters.AddWithValue("@result_position", result_position);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Result added successfully";
                    }
                }
            }

            return message;
        }
        //get the result with id 
        public string get_result_by_id(int id)
        {
            string message = "";

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = "SELECT * FROM results WHERE results_id = @results_id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@results_id", id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message = "Result ID: " + reader["results_id"].ToString()
                                + ", Participant ID: " + reader["participant_id"].ToString()
                                + ", Event ID: " + reader["events_id"].ToString()
                                + ", Time: " + reader["result_time"].ToString()
                                + ", Position: " + reader["result_position"].ToString();
                        }
                    }
                }
            }

            return message;
        }
        //update results
        public string update_results(int id, int participant_id, int events_id, string result_time, int result_position)
        {
            string message = "";

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"UPDATE results
                         SET participant_id = @participant_id,
                             events_id = @events_id,
                             result_time = @result_time,
                             result_position = @result_position
                         WHERE results_id = @results_id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@results_id", id);
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);
                    run_query.Parameters.AddWithValue("@events_id", events_id);
                    run_query.Parameters.AddWithValue("@result_time", result_time);
                    run_query.Parameters.AddWithValue("@result_position", result_position);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Result updated successfully";
                    }
                }
            }

            return message;
        }
        // Delete a result
        public string delete_results(int id)
        {
            string message = "";

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = "DELETE FROM results WHERE results_id = @results_id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@results_id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Result deleted successfully";
                    }
                }
            }

            return message;
        }

    }
}