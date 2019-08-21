using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class Agent
    {
        public int USER_ID { get; set; }
        public string USER_PASSWORD { get; set; }
        public string NAME { get; set; }
        public string USER_ADDRESS { get; set; }
        public string USER_MOBILENO { get; set; }
        public string USER_MAIL_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public string IS_ACTIVE { get; set; }
        public string USER_TYPE { get; set; }
        public List<Agent> GetCustomerList { get; set; }
    }
}