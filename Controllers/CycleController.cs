using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class CycleController : Controller
    {
        //
        // GET: /Cycle/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new CycleRepository(x);
                List<CycleModel> list = repo.All().Select(s => new CycleModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                return View(list);
            }
            
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoLevel = new LevelRepository(x);
                List<LevelModel> listLevels = repoLevel.getByCycleId(id).Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title           
                }).ToList();
                var repo = new CycleRepository(x);
                CycleModel cycle = repo.getById(id).Select(s => new CycleModel
                {
                    id = s.Id,
                    title = s.Title,
                }).First();
                cycle.levels = listLevels;
                return View(cycle);
            }

        }

    }
}
