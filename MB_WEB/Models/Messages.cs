using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MB_WEB.Models
{
   public class Messages
    {
        public bool isWarning { set; get; }
        public bool isError { set; get; }
        public bool isSuccess { set; get; }
        public bool isInfo { set; get; }
        public string Message { set; get; }
        public int ErrorCode { set; get; }
        public Messages()
        {
            this.isWarning = false; this.isError = false; this.isSuccess = false; this.isInfo = false; this.Message = string.Empty;
        }

    }
}
