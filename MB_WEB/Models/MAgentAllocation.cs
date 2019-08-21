using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MAgentAllocation
    {
        public int USER_ID { get; set; }
        public string USER_PASSWORD { get; set; }
        public string NAME { get; set; }
        public string USER_ADDRESS { get; set; }
        public string USER_MOBILENO { get; set; }
        public string USER_MAIL_ID { get; set; }
        public Nullable<DateTime> CREATED_DATE { get; set; }
        public Nullable<DateTime> UPDATED_DATE { get; set; }
        public Nullable<DateTime> IS_ACTIVE { get; set; }
        public string USER_TYPE { get; set; }
        public List<MAgentAllocation> GetAgentCollections { get; set; }
    }
}