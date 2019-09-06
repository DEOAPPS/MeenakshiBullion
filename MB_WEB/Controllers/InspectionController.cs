using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class InspectionController : Controller
    {
        // GET: Inspection
        public ActionResult Index()
        {
            sri123_mbdbEntities1 db = new sri123_mbdbEntities1();
            MInspection objInspe = new MInspection();
            objInspe.GetInspectioinCollections = db.user_tbl.Where(s => s.USER_TYPE == "3" & s.IS_ACTIVE == "Y").Select(s => new MDropDown1 { Value = s.USER_ID, Text = s.NAME }).ToList();

            return View(objInspe);

        }
    }
}