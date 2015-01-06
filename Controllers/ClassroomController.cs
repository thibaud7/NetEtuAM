using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;
using System.Web.UI.WebControls;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class ClassroomController : Controller
    {
        //
        // GET: /Classroom/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new ClassroomRepository(x);
                List<ClassroomModel> list = repo.All().Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title,
                    year = s.Year.Year1,
                    establishmentName = s.Establishment.Name,
                    userName = s.User.UserName
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
                ClassroomModel ss = new ClassroomModel();
                EstablishmentRepository erepo = new EstablishmentRepository(x);
                List<EstablishmentModel> l = erepo.All().Select(s => new EstablishmentModel
                {
                    id = s.Id,
                    name = s.Name
                }).ToList();
                ViewData["etablissements"] = l;

                YearRepository prepo = new YearRepository(x);
                List<YearModel> lp = prepo.All().Select(s => new YearModel
                {
                    id = s.Id,
                    year = s.Year1
                }).ToList();
                ViewData["annees"] = lp;
                return View(ss);
            }
        }

        [HttpPost]
        public ActionResult Create(ClassroomModel s)
        {
            
            s.id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    EstablishmentRepository er = new EstablishmentRepository(x);
                    s.userId = er.getById(s.establishmentId).First().User_Id;
                    var repo = new ClassroomRepository(x);
                    Classroom p = createClassroomToClassroomModel(s);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Views/Classroom/Read.cshtml", s);
                }
            }
            else
            {
                return View(s);
            }
        }

        public Classroom createClassroomToClassroomModel(ClassroomModel m)
        {
            Classroom c = new Classroom();
            c.Establishment_Id = m.establishmentId;
            c.Id = m.id;
            c.Title = m.title;
            c.User_Id = m.userId;
            c.Year_Id = m.yearId;
            return c;
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoEvaluation = new EvaluationRepository(x);
                List<EvaluationModel> listEvaluations = repoEvaluation.getByClassroomId(id).Select(s => new EvaluationModel
                {
                    id = s.Id,
                    classroomTitle = s.Classroom.Title,
                    userName = s.User.UserName,
                    periodBegin = s.Period.Begin,
                    periodEnd = s.Period.End,
                    date = s.Date,
                    totalPoint = s.TotalPoint,
                    idUser = s.User_Id,
                    idClassroom = s.Classroom_Id
                }).ToList();


                var repoPupil = new PupilRepository(x);
                List<PupilModel> listPupils = repoPupil.getByClassroomId(id).Select(s => new PupilModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    sex = s.Sex,
                    birthdayDate = s.BirthdayDate,
                    state = s.State,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,
                    levelTitle = s.Level.Title,
                    classroomId = s.Classroom_Id,
                    tutorId = s.Tutor_Id
                }).ToList();



                var repo = new ClassroomRepository(x);
                ClassroomModel classroom = repo.getById(id).Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title,
                    userName = s.User.FirstName + " " + s.User.LastName,
                    year = s.Year.Year1,
                    yearId = s.Year_Id,
                    userId = s.User_Id,
                    establishmentId = s.Establishment_Id,
                    establishmentName = s.Establishment.Name
                }).First();
                classroom.evaluations = listEvaluations;
                classroom.pupils = listPupils;
                return View(classroom);
            }

        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var x = new Entities())
            {
                var repo = new ClassroomRepository(x);
                ClassroomModel c = repo.getById(id).Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title,
                    establishmentName = s.Establishment.Name,
                    establishmentId = s.Establishment_Id,
                    userId = s.User_Id,
                    year = s.Year.Year1,
                    yearId = s.Year_Id
                    
                }).First();

                EstablishmentRepository erepo = new EstablishmentRepository(x);
                List<EstablishmentModel> l = erepo.All().Select(s => new EstablishmentModel
                {
                    id = s.Id,
                    name = s.Name
                }).ToList();
                ViewData["etablissements"] = l;

                YearRepository prepo = new YearRepository(x);
                List<YearModel> lp = prepo.All().Select(s => new YearModel
                {
                    id = s.Id,
                    year = s.Year1
                }).ToList();
                ViewData["annees"] = lp;
                return View(c);
            }
        }

        [HttpPost]
        public ActionResult Edit(ClassroomModel cm)
        {
            using (var x = new Entities())
            {
                var repo = new ClassroomRepository(x);
                EstablishmentRepository er = new EstablishmentRepository(x);
                cm.userId = er.getById(cm.establishmentId).First().User_Id;
                Classroom o = repo.getById(cm.id).First();
                createClassroomToClassroomModel(o,cm);
                repo.Save();
                return RedirectToAction("Read", new { id = cm.id });

            }
        }

        public void createClassroomToClassroomModel(Classroom c, ClassroomModel m)
        {
            c.Establishment_Id = m.establishmentId;
            c.Id = m.id;
            c.Title = m.title;
            c.User_Id = m.userId;
            c.Year_Id = m.yearId;
        }

    }
}
