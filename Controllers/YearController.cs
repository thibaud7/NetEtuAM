using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class YearController : Controller
    {
        //
        // GET: /Year/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new YearRepository(x);
                List<YearModel> list = repo.All().Select(s => new YearModel
                {
                    id = s.Id,
                    year = s.Year1,
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
                YearModel y = new YearModel();
                y.year = 2014;
                return View(y);
            }
        }

        [HttpPost]
        public ActionResult Create(YearModel s)
        {
            s.id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    var repo = new YearRepository(x);
                    Year y = createYearToYearModel(s);
                    repo.Add(y);
                    repo.Save();
                    return View("~/Views/Classroom/Read.cshtml", s);
                }
            }
            else
            {
                return View(s);
            }
        }


        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                
                var repoP = new PeriodRepository(x);
                List<PeriodModel> periods = repoP.getByYearId(id).Select(s => new PeriodModel
                {
                    id = s.Id,
                    begin = s.Begin,
                    end = s.End

                }).ToList();

                var repoY = new ClassroomRepository(x);
                List<ClassroomModel> classrooms = repoY.getByYearId(id).Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();

                var repo = new YearRepository(x);
                YearModel period = repo.getById(id).Select(s => new YearModel
                {
                    id = s.Id,
                    year = s.Year1

                }).First();
                period.periods = periods;
                period.classrooms = classrooms;
                return View(period);
            }

        }

        public Year createYearToYearModel(YearModel ym)
        {
            Year y = new Year();
            y.Id = ym.id;
            y.Year1 = ym.year;
            return y;
        }
    }
}
