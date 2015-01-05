using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class AcademyController : Controller
    {
        //
        // GET: /Academy/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new AcademyRepository(x);
                List<AcademyModel> list = repo.All().Select(s => new AcademyModel
                {
                    id = s.Id,
                    name = s.Name,
                }).ToList();
                return View(list);
            }
        }

        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoEst = new EstablishmentRepository(x);
                List<EstablishmentModel> listEtablissement = repoEst.getByAcademyId(id).Select(s => new EstablishmentModel
                {
                   name = s.Name,
                   town = s.Town,
                   id = s.Id
                }).ToList();

                var repo = new AcademyRepository(x);
                AcademyModel academy = repo.getById(id).Select(s => new AcademyModel
                {
                    id = s.Id,
                    name = s.Name
                }).First();
                academy.establishments = listEtablissement;
                return View(academy);
            }

        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var x = new Entities())
            {
                var repo = new AcademyRepository(x);
                AcademyModel academy = repo.getById(id).Select(s => new AcademyModel
                {
                    id = s.Id,
                    name = s.Name
                }).First();
                return View(academy);
            }
        }

        [HttpPost]
        public ActionResult Edit(AcademyModel am)
        {
            using (var x = new Entities())
            {
                var repo = new AcademyRepository(x);


                Academy o = repo.getById(am.id).First();
                o = createAcademyToAcademyModel(am);
                repo.Save();
                return View("~/Views/Academy/Read.cshtml", am);

            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
                AcademyModel am = new AcademyModel();
                return View(am);
            }
        }

        [HttpPost]
        public ActionResult Create(AcademyModel am)
        {

            am.id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    var repo = new AcademyRepository(x);
                    Academy a = createAcademyToAcademyModel(am);
                    repo.Add(a);
                    repo.Save();
                    return View("~/Views/Academy/Read.cshtml", am);
                }
            }
            else
            {
                return View(am);
            }
        }

        private Academy createAcademyToAcademyModel(AcademyModel am)
        {
            Academy a = new Academy();
            a.Id = am.id;
            a.Name = am.name;
            return a;
        }

        [HttpPost]
        public ActionResult Search(string requete)
        {
            using (var x = new Entities())
            {
                String[] results = requete.Split(new Char[] { ' ', ',' });
                AcademyRepository repo = new AcademyRepository(x);
                List<AcademyModel> academies = repo.Search(results).Select(a => new AcademyModel
                {
                    id = a.Id,
                    name = a.Name
                }).ToList();

                return View("~/Views/Academy/Index.cshtml", academies);
            }
        }

    }
}
