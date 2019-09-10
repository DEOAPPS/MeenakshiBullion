using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MDistrict
    {
        public List<MDropDown2> GetStateCollections { get; set; }
        public int DISTRICT_ID { get; set; }
        public string DISTRICT_NAME { get; set; }
        public int STATE_ID { get; set; }

    }
        public class MDropDown2
        {
            public int Value { get; set; }

            public string Text { get; set; }

        }



    
}