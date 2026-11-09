using System.Data.SqlClient;

namespace prompt_users.database
{//start of namespace 

    public class update_user_info
    {
        //method to update 
        public string update_info(int update_byid, string update_participant_name, string update_participant_surname, string update_participant_email, int update_participant_number) 
        {//start of method

            //temp variables 
            string message = "user info failed to update incorrect id ";


            //try and catch
            try
            {// start of try 
                using (SqlConnection connect = new SqlConnection(@"Data source=(localdb)\api_guide;database=api_database;"))

                {//start of using 
                    connect.Open();

                    //query 
                    string query = @"update users set participant = '" + update_participant_name + "', id= '" + update_byid + "'  where id=" + update_byid + "";

                    
                    //creating an instance for the class sqlcommand
                    SqlCommand run_query = new SqlCommand(query, connect);

                    //run the query 
                    int result = run_query.ExecuteNonQuery();

                    //check if the command worked 
                    if (result > 0)
                    {
                        //assign succes message 
                        message = "successfully updated";
                    }

                }//end of using 
            }//end of try 
            catch (Exception error)
            {//start of cacth

                //assign the error message to temp variable 
                message = error.Message;

            }//end of catch 

            return message;

        }//end of method
    }//end of class
}//end of namespace 