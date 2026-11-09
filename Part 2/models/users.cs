using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Part_2.models
{
    public class users
    {
        //for organiser table
       public int organiser_id { get; set; }
        public string organiser_name { get; set; }
        public string organiser_surname { get; set; }
        public string organiser_email { get; set; }
        public int organiser_number { get; set; }


        // for participant table
        public int participant_id { get; set; }
        public string participant_name { get; set; }
        public string participant_surname { get; set; }
        public string participant_email { get; set; }
        public int participant_number { get; set; }



        //for raceday table
        public int raceday_id { get; set; }
        public string raceday_weather { get; set; }
        public string raceday_route_information { get; set; }

       


        

        //for perfomance table
        public int performance_id { get; set; }
        public string performance_history { get; set; }

        //for enrolment 
        public int enrolment_id { get; set; }

        //for register
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
