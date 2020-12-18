﻿using PMS.Models;
using PMS.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{

    public class StudioPermalinkController : Controller
    {
        photogEntities db = new photogEntities();

        [StudioPermalinkValidate]
        // GET: Studio Profile Page
        public ActionResult Index()
        {
            long studioID = (long)ViewBag.StudioID;
            var studio = db.Studios.FirstOrDefault(x => x.id == studioID);

            return View(studio);
        }


        [StudioPermalinkValidate]
        [StudioAuthorizationRole(RoleID = 1)]
        public ActionResult TestPage()
        {
            ViewBag.Perm = RouteData.Values.FirstOrDefault(x=>x.Key.ToLower() == "permalink").Value;

            return View();
        }
    }
}