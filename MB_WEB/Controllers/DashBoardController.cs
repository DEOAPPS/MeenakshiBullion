using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        sri123_mbdbEntities1 sd = new sri123_mbdbEntities1();
        public ActionResult Index()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["UserType"].ToString() == "3")
            {

                int UserId = Convert.ToInt32(Session["cid"]);

                decimal? TotlaCustAmnt = sd.customer_tbl.Where(s => s.CUSTOMER_ID == UserId).Select(s => s.AMOUNT).FirstOrDefault();

                if (TotlaCustAmnt != null)
                {
                    ViewBag.TotalCustomerAmount = TotlaCustAmnt;
                }
                else
                {
                    ViewBag.TotalCustomerAmount = 0;

                }

                double? PaidAmount = null;
                var UsrCollection = sd.user_collections_tbl.Where(s => s.CUSTOMER_ID == UserId).FirstOrDefault();
                if (UsrCollection != null)
                {
                    PaidAmount = sd.user_collections_tbl.Where(s => s.CUSTOMER_ID == UserId).Sum(s => s.AMOUNT);
                }
                else
                {
                    PaidAmount = 0;
                }

                ViewBag.PaidCustAmnt = PaidAmount;

                if (PaidAmount != null && TotlaCustAmnt != null)
                {
                    ViewBag.BalanceAmnt = TotlaCustAmnt.Value - Convert.ToDecimal(PaidAmount);
                }
                else
                {
                    ViewBag.BalanceAmnt = 0;

                }
            }
            else
            {

                ViewBag.Agents = sd.user_tbl.Where(s => s.USER_TYPE == "2").Count();

                ViewBag.ToTalCustomers = sd.user_tbl.Where(s => s.USER_TYPE == "3").Count();

                ViewBag.ApprovedCustomers = sd.customer_tbl.Where(s => s.USER_ID != null).Count();

                ViewBag.UnAprovedCustomers = sd.customer_tbl.Where(s => s.USER_ID == null).Count();
            }

            return View();
        }
    }
}