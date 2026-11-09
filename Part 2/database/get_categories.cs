
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Part_2.database
{
    public class get_categories
    {
        string connection_stirng = @"Data source=(localdb)\api_guide;database=raceday;";

        //method to get all categories
        public List<string> get_all_categories()
        {
            List<string> categories = new List<string>();

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM categories";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = "";

                            message = "Category ID: " + reader["categories_id"].ToString();
                            message += ", Category Name: " + reader["categories_name"].ToString();

                            categories.Add(message);
                        }
                    }
                }
            }

            return categories;
        }


        //method to get category by ID
        public string get_category_by_id(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"SELECT * FROM categories WHERE categories_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = run_query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            message = "Category ID: " + reader["categories_id"].ToString();
                            message += ", Category Name: " + reader["categories_name"].ToString();
                        }
                    }

                }

                return message;
            }
        }

        //method to add a category
        
        public string add_category(string category_name, int events_id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"INSERT INTO categories (categories_name, events_id)
                         VALUES (@name, @events_id)";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@name", category_name);
                    run_query.Parameters.AddWithValue("@events_id", events_id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Category added successfully";
                    }
                }
            }

            return message;
        }

        //method to update a category
        public string update_category(int id, string category_name)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"UPDATE categories
                         SET categories_name = @name
                         WHERE categories_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);
                    run_query.Parameters.AddWithValue("@name", category_name);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Category updated successfully";
                    }
                }
            }

            return message;
        }

//method to delete a category
public string delete_category(int id)
        {
            string message = string.Empty;

            using (SqlConnection connect = new SqlConnection(connection_stirng))
            {
                string query = @"DELETE FROM categories WHERE categories_id = @id";

                connect.Open();

                using (SqlCommand run_query = new SqlCommand(query, connect))
                {
                    run_query.Parameters.AddWithValue("@id", id);

                    int rows = run_query.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        message = "Category deleted successfully";
                    }
                }
            }

            return message;
        }

    }
}