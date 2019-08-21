using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MB_WEB.Models
{
    public class SendSMS
    {
        public int sendSMS(string MobileNumber, string Message)
        {
            int iSuccess = 0;
            String message = System.Web.HttpUtility.UrlEncode(Message);
            using (var wb = new WebClient())
            {
                string Username = "meenakshibulion";
                string Pwd = "y$3Fj)9T";
                string SenderName = "BULION";
                string Number = "91" + MobileNumber;
                string URL = "http://mgage.solutions/SendSMS/sendmsg.php?";
                // string PostData = "uname=" + Username + "&hash=" + Hash + "&sender=" + SenderName + "&numbers=" + Number + "&message=" + Message;
                string PostData = "uname=" + Username + "&pass=" + Pwd + "&send=" + SenderName + "&dest=" + Number + "&msg=" + Message;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
                req.Method = "POST";
                var data = Encoding.ASCII.GetBytes(PostData);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                try
                {
                    var response = (HttpWebResponse)req.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    iSuccess = 1;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    //ExceptionUtility.LogException(ex, "sendSMS");
                    iSuccess = 0;
                }
                return iSuccess;
            }
        }
    }
}