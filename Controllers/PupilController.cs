using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class PupilController : Controller
    {
        //
        // GET: /Pupil/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new PupilRepository(x);
                List<PupilModel> list = repo.All().Select(s => new PupilModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    sex = s.Sex,
                    birthdayDate = s.BirthdayDate,
                    state  = s.State,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,
                    levelTitle = s.Level.Title,
                    classroomId = s.Classroom_Id,
                    tutorId = s.Tutor_Id
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
            PupilModel ss = new PupilModel();
            
                
                ClassroomRepository prepo = new ClassroomRepository(x);
                List<ClassroomModel> lp = prepo.All().Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                ViewData["classes"] = lp;

                LevelRepository lrepo = new LevelRepository(x);
                List<LevelModel> ll = lrepo.All().Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                ViewData["levels"] = ll;

                TutorRepository erepo = new TutorRepository(x);
                List<TutorModel> l = erepo.All().Select(s => new TutorModel
                {
                    id = s.Id,
                    firstName = s.FirstName,// Pour affichage Prénom Nom dans la vue 
                }).ToList();
                ViewData["tutors"] = l;


                return View(ss);
            }
        }

        [HttpPost]
        public ActionResult Create(PupilModel s)
        {
            s.id = Guid.NewGuid();
            s.state = 1;

            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    ClassroomRepository rp = new ClassroomRepository(x);
                    s.classroomTitle = rp.getById(s.classroomId).First().Title;
                    
                    LevelRepository lp = new LevelRepository(x);
                    s.levelTitle = lp.getById(s.levelId).First().Title;

                    TutorRepository tr = new TutorRepository(x);
                    s.tutorLastName = tr.getById(s.tutorId).First().FirstName + " " + tr.getById(s.tutorId).First().LastName;

                    var repo = new PupilRepository(x);
                    Pupil p = createPupilToPupilModel(s);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Views/Pupil/Read.cshtml", s);
                }
            }
            else
            {
                return View(s);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var x = new Entities())
            {
                ClassroomRepository prepo = new ClassroomRepository(x);
                List<ClassroomModel> lp = prepo.All().Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                ViewData["classes"] = lp;

                LevelRepository lrepo = new LevelRepository(x);
                List<LevelModel> ll = lrepo.All().Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                ViewData["levels"] = ll;

                TutorRepository erepo = new TutorRepository(x);
                List<TutorModel> l = erepo.All().Select(s => new TutorModel
                {
                    id = s.Id,
                    firstName = s.FirstName,// Pour affichage Prénom Nom dans la vue 
                }).ToList();
                ViewData["tutors"] = l;
                
                var repo = new PupilRepository(x);
                PupilModel pupil = repo.getById(id).Select(s => new PupilModel
                {
                    id = s.Id,
                    lastName = s.LastName,
                    firstName = s.FirstName,
                    levelTitle = s.Level.Title,
                    sex = s.Sex,
                    birthdayDate = s.BirthdayDate,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,
                    levelId = s.Level_Id,
                    tutorId = s.Tutor_Id,
                    classroomId = s.Classroom_Id
                }).First();

                return View(pupil);
            }
        }

        [HttpPost]
        public ActionResult Edit(PupilModel sm)
        {
            using (var x = new Entities())
            {
                var repo = new PupilRepository(x);
                PupilModel pupil = repo.getById(sm.id).Select(s => new PupilModel
                {
                    levelTitle = s.Level.Title,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,

                }).First();

                sm.classroomTitle = pupil.classroomTitle;
                sm.levelTitle = pupil.levelTitle;
                sm.tutorLastName = pupil.tutorLastName;
                Pupil o = repo.getById(sm.id).First();
                createPupilToPupilModel(o,sm);
                repo.Save();
                Pupil oo = repo.getById(sm.id).First();
                return RedirectToAction("Read", new { id = sm.id });

            }
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoResults = new ResultRepository(x);
                List<ResultModel> listResults = repoResults.getByPupilId(id).Select(s => new ResultModel
                {
                    id = s.Id,
                    evaluationId = s.Evaluation_Id,
                    note = s.Note,
                    totalNote = s.Evaluation.TotalPoint,
                }).ToList();


                var repo = new PupilRepository(x);
                PupilModel pupil = repo.getById(id).Select(s => new PupilModel
                {
                    id = s.Id,
                    lastName = s.LastName,
                    firstName = s.FirstName,
                    levelTitle = s.Level.Title,
                    sex = s.Sex,
                    birthdayDate = s.BirthdayDate,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,
                    levelId = s.Level_Id,
                    tutorId = s.Tutor_Id,
                    classroomId = s.Classroom_Id
                }).First();
                pupil.results = listResults;

                return View(pupil);
            }

        }

        public ActionResult ExportToExcel()
        {
            using (var x = new Entities())
            {
                var repo = new PupilRepository(x);
                List<PupilModel> pupils = repo.All().Select(s => new PupilModel
                {
                    lastName = s.LastName,
                    firstName = s.FirstName,
                    levelTitle = s.Level.Title,
                    sex = s.Sex,
                    birthdayDate = s.BirthdayDate,
                    tutorLastName = s.Tutor.LastName,
                    classroomTitle = s.Classroom.Title,
                    levelId = s.Level_Id,
                    tutorId = s.Tutor_Id,
                    classroomId = s.Classroom_Id
                }).ToList();

                var products = new System.Data.DataTable("Pupils");
                products.Columns.Add("Last Name", typeof(string));
                products.Columns.Add("First Name", typeof(string));
                products.Columns.Add("Level", typeof(string));
                products.Columns.Add("Sex", typeof(short));
                products.Columns.Add("Birthday Date", typeof(DateTime));
                products.Columns.Add("Tutor", typeof(string));
                products.Columns.Add("Classroom", typeof(string));
                foreach (PupilModel p in pupils)
                {
                    products.Rows.Add(
                        p.lastName,
                        p.firstName,
                        p.levelTitle,
                        p.sex,
                        p.birthdayDate,
                        p.tutorLastName,
                        p.classroomTitle
                    );
                }
                var grid = new GridView();
                grid.DataSource = products;
                grid.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
                Response.ContentType = "application/ms-excel";

                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

                return View("~/Views/Pupil/Index.cshtml");
            }
        }

        public Pupil createPupilToPupilModel(PupilModel m)
        {
            Pupil p = new Pupil();
            p.BirthdayDate = m.birthdayDate;
            p.Id = m.id;
            p.LastName = m.lastName;
            p.Level_Id = m.levelId;
            p.Sex = m.sex;
            p.State = 1;
            p.FirstName = m.firstName;
            p.Tutor_Id = m.tutorId;
            p.Classroom_Id = m.classroomId;
            return p;
        }

        public void createPupilToPupilModel(Pupil p, PupilModel m)
        {
            p.BirthdayDate = m.birthdayDate;
            p.Id = m.id;
            p.LastName = m.lastName;
            p.Level_Id = m.levelId;
            p.Sex = m.sex;
            p.State = 1;
            p.FirstName = m.firstName;
            p.Tutor_Id = m.tutorId;
            p.Classroom_Id = m.classroomId;
        }

        [HttpPost]
        public ActionResult Search(string recherche)
        {
            using (var x = new Entities())
            {
                String[] mots = recherche.Split(new Char[] { ' ' });
                PupilRepository repo = new PupilRepository(x);
                List<PupilModel> pupils = repo.Search(mots).Select(p => new PupilModel
                {
                    id = p.Id,
                    lastName = p.LastName,
                    firstName = p.FirstName,
                    levelTitle = p.Level.Title,
                    sex = p.Sex,
                    birthdayDate = p.BirthdayDate,
                    tutorLastName = p.Tutor.LastName,
                    classroomTitle = p.Classroom.Title,
                    levelId = p.Level_Id,
                    tutorId = p.Tutor_Id,
                    classroomId = p.Classroom_Id
                }).ToList();

                return View("~/Views/Pupil/Index.cshtml", pupils);
            }
        }
    }
}
