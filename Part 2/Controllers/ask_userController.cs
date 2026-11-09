using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;
/*
namespace prompt_users.Controllers
{//start of namespace
    [Route("api/[controller]")]
    [ApiController]
    public class ask_userController : ControllerBase
    {//start of class

        //post http request to send user's info
        //to the database 
        [HttpPost]
        public string user_info (string participant_id, string participant_name, string participant_surname, string participant_email, int participant_number)
        {//start of method
            
 
            //crate an object for store_info
            store_info store = new store_info();
            //calling method that will insert info in database 
            store.user_info(participant_id, participant_name, participant_surname, participant_email, participant_number);

            //testing message
            return "Your id is  " + participant_id + " " + ",And your details are saved Thank you " + participant_name;

        }//end of method

        //get request method to get the users info 


        //http GET
        [HttpGet]
        public string get_info (string participant_id, int participant_number)
        {//start of method



            return "it works ";
        }//end of method

        [HttpGet("{id}")]
        public string get_info_Id(int id)
        {//start         
            get_user_info get_user = new get_user_info();
           // get_user.get_user_onfo_ById(id);

            return get_user.get_user_onfo_ById(id);
        }//end of method get_info_Id


        //put request to update 
        [HttpPut]
        public string update_userinfo(int update_byid, string update_participant_name, string update_participant_surname, string update_participant_email, int update_participant_number)
        {//start of update method 




            //creating an instance for the classs update_user_info
            update_user_info update_user = new update_user_info();

            string result = update_user.update_info(update_byid,  update_participant_name,  update_participant_surname,  update_participant_email,  update_participant_number);

            return result;

        }//end of update method 


        //put request to delete
        [HttpDelete]
        public string delete_userinfo(int participant_id)
        {//start of method

            //create a instance for delete class
            delete_info delete_user = new delete_info();

            return delete_user.delete_user_info(participant_id);

            
        }//end of method

    }//end of class
}//end of namespace
*/
