using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class CascadingController : Controller
    {

        sri123_mbdbEntities1 db = new sri123_mbdbEntities1();
        // GET: Cascading
        public ActionResult Index()
        {

            List<STATE_MASTER> StateList = db.STATE_MASTER.ToList();
            ViewBag.StateList = new SelectList(StateList, "STATE_ID", "STATE_NAME");


            return View();
        }
        public JsonResult GetDISTRICTList(int STATE_ID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<DISTRICT_MASTER> DISTRICTList = db.DISTRICT_MASTER.Where(x => x.STATE_ID == STATE_ID).ToList();
            return Json(DISTRICTList, JsonRequestBehavior.AllowGet);

        }
    }
}