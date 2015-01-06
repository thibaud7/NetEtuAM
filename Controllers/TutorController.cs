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
    public class TutorController : Controller
    {
        //
        // GET: /Tutor/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new TutorRepository(x);
                List<TutorModel> list = repo.All().Select(s => new TutorModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    address = s.Address,
                    postCode = s.PostCode,
                    town = s.Town,
                    tel = s.Tel,
                    mail = s.Mail,
                    comment = s.Comment
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            TutorModel s = new TutorModel();
            return View(s);
        }

        [HttpPost]
        public ActionResult Create(TutorModel s)
        {
            s.id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    var repo = new TutorRepository(new Entities());
                    Tutor p = createTutorToTutorModel(s);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Views/Tutor/Read.cshtml", s);
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
                var repo = new TutorRepository(x);
                TutorModel sm = repo.getById(id).Select(s => new TutorModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    address = s.Address,
                    postCode = s.PostCode,
                    town = s.Town,
                    tel = s.Tel,
                    mail = s.Mail,
                    comment = s.Comment
                }).First();
                return View(sm);
            }
         }

        [HttpPost]
        public ActionResult Edit(TutorModel sm)
        {
            using (var x = new Entities())
            {
                TutorRepository repo = new TutorRepository(x);
                Tutor s = repo.getById(sm.id).First();
                createTutorToTutorModel(s,sm);
                repo.Save();
                return RedirectToAction("Read", new { id = sm.id });

            }
        }

        private void createTutorToTutorModel(Tutor p, TutorModel m)
        {
            p.Address = m.address;
            p.Comment = m.comment;
            p.FirstName = m.firstName;
            p.LastName = m.lastName;
            p.Mail = m.mail;
            p.PostCode = m.postCode;
            p.Tel = m.tel;
            p.Town = m.town;
            p.Id = m.id;
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoPupil = new PupilRepository(x);
                List<PupilModel> l = repoPupil.getByTutorId(id).Select(s => new PupilModel
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
                
                var repoTutor = new TutorRepository(x);
                TutorModel tutor = repoTutor.getById(id).Select(s => new TutorModel
                {
                    id = s.Id,
                    address = s.Address,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    postCode = s.PostCode,
                    tel = s.Tel,
                    town = s.Town,
                    mail = s.Mail,
                    comment = s.Comment
                }).First();

                tutor.pupils = l;
                return View(tutor);
            }

        }

        public ActionResult ExportToExcel()
        {
            using (var x = new Entities())
            {
                var repo = new TutorRepository(x);
                List<TutorModel> list = repo.All().Select(s => new TutorModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    address = s.Address,
                    postCode = s.PostCode,
                    town = s.Town,
                    tel = s.Tel,
                    mail = s.Mail,
                    comment = s.Comment
                }).ToList();



                var products = new System.Data.DataTable("teste");
                products.Columns.Add("col1", typeof(string));
                products.Columns.Add("col2", typeof(string));
                foreach (TutorModel t in list)
                {
                    products.Rows.Add(t.firstName, t.lastName);
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

                return View("~/Views/Tutor/Index.cshtml");
            }
        }

        public Tutor createTutorToTutorModel(TutorModel m)
        {
            Tutor p = new Tutor();
            p.Address = m.address;
            p.Comment = m.comment;
            p.FirstName = m.firstName;
            p.LastName = m.lastName;
            p.Mail = m.mail;
            p.PostCode = m.postCode;
            p.Tel = m.tel;
            p.Town = m.town;
            p.Id = m.id;
            return p;
        }

        [HttpPost]
        public ActionResult Search(string recherche)
        {
            using (var x = new Entities())
            {
                String[] mots = recherche.Split(new Char[] { ' ' });
                TutorRepository repo = new TutorRepository(x);
                List<TutorModel> tutors = repo.Search(mots).Select(t => new TutorModel
                {
                    id = t.Id,
                    address = t.Address,
                    firstName = t.FirstName,
                    lastName = t.LastName,
                    postCode = t.PostCode,
                    tel = t.Tel,
                    town = t.Town,
                    mail = t.Mail,
                    comment = t.Comment
                }).ToList();

                return View("~/Views/Tutor/Index.cshtml", tutors);
            }
        }

    }
}
