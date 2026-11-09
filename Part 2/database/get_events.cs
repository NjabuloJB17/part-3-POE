
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Part_2.database
{
    public class get_events
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        //method to get all events
        public List<string> get_all_events()
        {
            List<string> events = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM events";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Event ID: " + reader["events_id"].ToString();
                            message += ", Event Name: " + reader["events_name"].ToString();
                            message += ", Event Date: " + reader["events_date"].ToString();

                            events.Add(message);
                        }
                    }
                }

                connect.Close();
            }

            return events;
        }
    
        //method to get event by ID
        public string get_event_by_id(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM events WHERE events_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            message = "Event ID: " + reader["events_id"].ToString();
                            message += ", Event Name: " + reader["events_name"].ToString();
                            message += ", Event Date: " + reader["events_date"].ToString();
                        }
                    }
                }
            }

            return message;
        }
       
            //method to add an event
        public string add_event(string event_name, DateTime event_date)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO events (events_name, events_date)
                         VALUES (@name, @date)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@name", event_name);
                    run_query.Parameters.AddWithValue("@date", event_date);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Event added successfully";
                    }
                }
            }

            return message;
        }
      
//method to update an event
public string update_event(int id, string event_name, DateTime event_date)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"UPDATE events
                         SET events_name = @name, events_date = @date
                         WHERE events_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);
                    run_query.Parameters.AddWithValue("@name", event_name);
                    run_query.Parameters.AddWithValue("@date", event_date);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Event updated successfully";
                    }
                }
            }

            return message;
        }
        
            //method to delete an event
        public string delete_event(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"DELETE FROM events WHERE events_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Event deleted successfully";
                    }
                }
            }

            return message;
        }

    }

}
