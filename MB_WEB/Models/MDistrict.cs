using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MDistrict
    {
        public List<MDropDown1> GetStateCollections { get; set; }
        public  int DISTRICT_ID {get;set;}
        public string DISTRICT_NAME { get; set; }
        public int STATE_ID { get; set; }


        public class MDropDown1
        {
            public int Value { get; set; }

            public string Text { get; set; }
        }



    }
}