using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class EstablishmentController : Controller
    {
        //
        // GET: /Establishment/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new EstablishmentRepository(x);
                List<EstablishmentModel> list = repo.All().Select(s => new EstablishmentModel
                {
                    id = s.Id,
                    name = s.Name,
                    address = s.Address,
                    postCode = s.PostCode,
                    town = s.Town,
                    userName = s.User.UserName,
                    userId =s.User_Id,
                    academyName = s.Academy.Name,
                    academyId = s.Academie_Id
                }).ToList();
                return View(list);
            }
        }



        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
                EstablishmentModel ss= new EstablishmentModel();
                UserRepository erepo = new UserRepository(x);
                List<UserModel> l = erepo.All().Select(s => new UserModel
                {
                    id = s.Id,
                    userName = s.UserName
                }).ToList();
                ViewData["users"] = l;

                AcademyRepository prepo = new AcademyRepository(x);
                List<AcademyModel> lp = prepo.All().Select(s => new AcademyModel
                {
                    id = s.Id,
                    name = s.Name
                }).ToList();
                ViewData["academies"] = lp;
                return View(ss);
            }
        }

        [HttpPost]
        public ActionResult Create(EstablishmentModel s)
        {

            s.id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    var repo = new EstablishmentRepository(x);
                    Establishment p = createEstablishmentToEstablishmentModel(s);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Views/Establishment/Read.cshtml", s);
                }
            }
            else
            {
                return View(s);
            }
        }

        private Establishment createEstablishmentToEstablishmentModel(EstablishmentModel s)
        {
            Establishment p = new Establishment();
            p.Academie_Id = s.academyId;
            p.Address = s.address;
            p.Name = s.name;
            p.User_Id = s.userId;
            p.Town = s.town;
            p.Id = s.id;
            p.PostCode = s.postCode;
            return p;
        }

        private void convertEstablishmentToEstablishmentModel(EstablishmentModel s, Establishment p)
        {
            p.Academie_Id = s.academyId;
            p.Address = s.address;
            p.Name = s.name;
            p.User_Id = s.userId;
            p.Town = s.town;
            p.Id = s.id;
            p.PostCode = s.postCode;
        }
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {

                var repoClass = new ClassroomRepository(x);
                List<ClassroomModel> classrooms = repoClass.getByEstablishmentId(id).Select(s => new ClassroomModel
                {
                    title = s.Title,
                    id = s.Id
                }).ToList();

                var repo = new EstablishmentRepository(x);
                EstablishmentModel establishment = repo.getById(id).Select(s => new EstablishmentModel
                {
                    id = s.Id,
                    name = s.Name,
                    postCode = s.PostCode,
                    town = s.Town,
                    userName = s.User.UserName,
                    academyName = s.Academy.Name,
                    address = s.Address,
                    academyId = s.Academie_Id,
                    userId = s.User_Id
                    
                }).First();
                establishment.classrooms = classrooms;
                return View(establishment);
            }

        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var x = new Entities())
            {
                var repo = new EstablishmentRepository(x);
                EstablishmentModel establishment = repo.getById(id).Select(s => new EstablishmentModel
                {
                    id = s.Id,
                    name = s.Name,
                    postCode = s.PostCode,
                    town = s.Town,
                    userName = s.User.UserName,
                    academyName = s.Academy.Name,
                    address = s.Address,
                    academyId = s.Academie_Id,
                    userId = s.User_Id

                }).First();

                UserRepository erepo = new UserRepository(x);
                List<UserModel> l = erepo.All().Select(s => new UserModel
                {
                    id = s.Id,
                    userName = s.UserName
                }).ToList();
                ViewData["users"] = l;

                AcademyRepository prepo = new AcademyRepository(x);
                List<AcademyModel> lp = prepo.All().Select(s => new AcademyModel
                {
                    id = s.Id,
                    name = s.Name
                }).ToList();
                ViewData["academies"] = lp;
                return View(establishment);
            }
        }


        [HttpPost]
        public ActionResult Edit(EstablishmentModel s)
        {

            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    var repo = new EstablishmentRepository(x);
                    Establishment p = repo.getById(s.id).First();
                    convertEstablishmentToEstablishmentModel(s,p);
                    repo.Save();
                    return View("~/Views/Establishment/Read.cshtml",s);
                }
            }
            else
            {
                return View(s);
            }
        }
    }
}
