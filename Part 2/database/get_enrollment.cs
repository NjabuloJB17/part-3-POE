
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Part_2.database
{
    public class get_enrollment
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        //method to get all enrolments
        public List<string> get_all_enrollments()
        {
            List<string> enrollments = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM enrollment";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Enrolment ID: " + reader["enrolment_id"].ToString();
                            message += ", Participant ID: " + reader["participant_id"].ToString();
                            message += ", Event ID: " + reader["events_id"].ToString();
                            message += ", Category ID: " + reader["categories_id"].ToString();

                            enrollments.Add(message);
                        }
                    }
                }
            }

            return enrollments;
        }


        //method to add an enrolment
        public string add_enrollment(int participant_id, int events_id, int categories_id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO enrollment (participant_id, events_id, categories_id)
                         VALUES (@participant_id, @events_id, @categories_id)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);
                    run_query.Parameters.AddWithValue("@events_id", events_id);
                    run_query.Parameters.AddWithValue("@categories_id", categories_id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Enrolment added successfully";
                    }
                }
            }

            return message;
        }

        
//method to get enrolments by participant ID
public List<string> get_enrollments_by_participant(int participant_id)
        {
            List<string> enrollments = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM enrollment
                         WHERE participant_id = @participant_id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@participant_id", participant_id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Enrolment ID: " + reader["enrolment_id"].ToString();
                            message += ", Participant ID: " + reader["participant_id"].ToString();
                            message += ", Event ID: " + reader["events_id"].ToString();
                            message += ", Category ID: " + reader["categories_id"].ToString();

                            enrollments.Add(message);
                        }
                    }
                }
            }

            return enrollments;
        }
        // method to delete an enrolment
        public string delete_enrollment(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"DELETE FROM enrollment WHERE enrolment_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Enrolment deleted successfully";
                    }
                }
            }

            return message;
        }
    }
}
