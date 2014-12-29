using AuvrayMonmertNetEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class LevelController : Controller
    {
        //
        // GET: /Level/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new LevelRepository(x);
                List<LevelModel> list = repo.All().Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title,
                    idCycle = s.Cycle.Id,
                    nomCycle = s.Cycle.Title
                }).ToList();
                return View(list);
            }

        }


    }
}
