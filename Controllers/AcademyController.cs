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
        public ActionResult Edit(AcademyModel sm)
        {
            using (var x = new Entities())
            {
                var repo = new AcademyRepository(x);


                Academy o = repo.getById(sm.id).First();
                o = createAcademyToAcademyModel(sm);
                repo.Save();
                return View("~/Views/Academy/Read.cshtml", sm);

            }
        }

        private Academy createAcademyToAcademyModel(AcademyModel sm)
        {
            Academy a = new Academy();
            a.Id = sm.id;
            a.Name = sm.name;
            return a;
        }

    }
}
