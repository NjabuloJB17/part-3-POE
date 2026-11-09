
using System;
using System.Data.SqlClient;

namespace Part_2.database
{
    public class get_authentication
    {
        string connection_string = @"Data source=(localdb)\api_guide;database=raceday;";

        // Register a new user
        public string register_user(string email, string password, string role)
        {
            string message = "";

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                string query = "INSERT INTO accounts (email, password, role) VALUES ('"
                    + email + "', '"
                    + password + "', '"
                    + role + "')";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    message = "User registered successfully.";
                }
                else
                {
                    message = "User registration failed.";
                }
            }

            return message;
        }
        // Login a user
        public string login_user(string email, string password)
        {
            string message = "";

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                string query = "SELECT * FROM accounts WHERE email = '"
                    + email + "' AND password = '"
                    + password + "'";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    message = "Login successful. Role: " + reader["role"].ToString();
                }
                else
                {
                    message = "Invalid email or password.";
                }

                reader.Close();
            }

            return message;
        }
    }
}
