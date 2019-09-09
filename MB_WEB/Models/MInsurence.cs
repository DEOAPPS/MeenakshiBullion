using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MInsurence
    {
        public int INSURANCE_ID { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER INSURANCE NAME ")]
        public string INSURANCE_NAME { get; set; }
        [Required(ErrorMessage = "PLEASE ENTER INSURANCE TYPE ")]
        public string INSURANCE_TYPE { get; set; }
        [Required(ErrorMessage = "PLEASE ENTER INSURANCE_CLAIM_DATE ")]
        [DataType(DataType.Date)]
        public DateTime INSURANCE_CLAIM_DATE { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER INSURANCE__EXPIRY_DATE ")]
        [DataType(DataType.Date)]
        public DateTime INSURANCE_EXPIRE_DATE { get; set; }
        [Required(ErrorMessage = "PLEASE ENTER INSURANCE_DOCUMENT_URL ")]
        public string INSURANCE_DOCUMENT_URL { get; set; }
        public HttpPostedFileBase UploadFiles { get; set; }
        public int CUSTOMER_ID { get; set; }






    }
}