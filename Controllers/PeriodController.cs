using AuvrayMonmertNetEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class PeriodController : Controller
    {
        //
        // GET: /Period/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new PeriodRepository(x);
                List<PeriodModel> list = repo.All().Select(s => new PeriodModel
                {
                    id = s.Id,
                    begin = s.Begin,
                    end = s.End,
                    year = s.Year.Year1
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoE = new EvaluationRepository(x);
                List<EvaluationModel> evals = repoE.getByPeriodId(id).Select(s => new EvaluationModel
                {
                    id = s.Id,
                    classroomTitle = s.Classroom.Title,
                    date = s.Date
                    
                }).ToList();
                
                var repo = new PeriodRepository(x);
                PeriodModel period = repo.getById(id).Select(s => new PeriodModel
                {
                    id = s.Id,
                    begin = s.Begin,
                    end = s.End,
                    year = s.Year.Year1,
                    yearId = s.Year_Id
                }).First();
                period.evaluations = evals;
                return View(period);
            }

        }

    }
}
