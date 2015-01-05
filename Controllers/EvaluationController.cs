using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class EvaluationController : Controller
    {
        //
        // GET: /Evaluation/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new EvaluationRepository(x);
                List<EvaluationModel> list = repo.All().Select(s => new EvaluationModel
                {
                    id = s.Id,
                    classroomTitle = s.Classroom.Title,
                    userName = s.User.UserName,
                    periodBegin = s.Period.Begin,
                    periodEnd = s.Period.End,
                    date = s.Date,
                    totalPoint = s.TotalPoint,
                    idUser = s.User_Id,
                    idClassroom =s.Classroom_Id
                }).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoR = new ResultRepository(x);
                List<ResultModel> listResults = repoR.getByEvaluationId(id).Select(s => new ResultModel
                {
                    id = s.Id,
                    pupilFirstName = s.Pupil.FirstName,
                    pupilLastName = s.Pupil.LastName,
                    note = s.Note
                }).ToList();
                var repo = new EvaluationRepository(x);
                EvaluationModel eval = repo.getById(id).Select(s => new EvaluationModel
                {
                    id = s.Id,
                    periodBegin = s.Period.Begin,
                    periodEnd = s.Period.End,
                    classroomTitle = s.Classroom.Title,
                    date = s.Date,
                    userName = s.User.FirstName + " " + s.User.LastName,
                    idClassroom = s.Classroom_Id,
                    idPeriod = s.Period_Id,
                    idUser = s.User_Id,
                    totalPoint =s.TotalPoint,
                }).First();
                eval.resultats = listResults;
                return View(eval);
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            using (var x = new Entities())
            {
                EvaluationModel ss = new EvaluationModel();


                ClassroomRepository prepo = new ClassroomRepository(x);
                List<ClassroomModel> lp = prepo.All().Select(s => new ClassroomModel
                {
                    id = s.Id,
                    title = s.Title
                }).ToList();
                ViewData["classes"] = lp;

                PeriodRepository lrepo = new PeriodRepository(x);
                List<PeriodModel> ll = lrepo.All().Select(s => new PeriodModel
                {
                    id = s.Id,
                    begin = s.Begin,
                    end = s.End
                }).ToList();
                ViewData["periods"] = ll;

                UserRepository erepo = new UserRepository(x);
                List<UserModel> l = erepo.All().Select(s => new UserModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName
                }).ToList();
                ViewData["users"] = l;

                return View(ss);
            }
        }

        [HttpPost]
        public ActionResult Create(EvaluationModel s)
        {
            s.id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                using (var x = new Entities())
                {
                    ClassroomRepository rp = new ClassroomRepository(x);
                    s.classroomTitle = rp.getById(s.idClassroom).First().Title;

                    PeriodRepository lp = new PeriodRepository(x);
                    s.periodBegin = lp.getById(s.idPeriod).First().Begin;
                    s.periodEnd = lp.getById(s.idPeriod).First().End;

                    UserRepository tr = new UserRepository(x);
                    s.userName = tr.getById(s.idUser).First().FirstName + " " + tr.getById(s.idUser).First().LastName;



                    var repo = new EvaluationRepository(x);
                    Evaluation p = createEvaluationToEvaluationModel(s);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Views/Evaluation/Read.cshtml", s);
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

                PeriodRepository lrepo = new PeriodRepository(x);
                List<PeriodModel> ll = lrepo.All().Select(s => new PeriodModel
                {
                    id = s.Id,
                    begin = s.Begin,
                    end = s.End
                }).ToList();
                ViewData["periods"] = ll;

                UserRepository erepo = new UserRepository(x);
                List<UserModel> l = erepo.All().Select(s => new UserModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName
                }).ToList();
                ViewData["users"] = l;

                var repo = new EvaluationRepository(x);
                EvaluationModel eval = repo.getById(id).Select(s => new EvaluationModel
                {
                    id = s.Id,
                    periodBegin = s.Period.Begin,
                    periodEnd = s.Period.End,
                    classroomTitle = s.Classroom.Title,
                    date = s.Date,
                    userName = s.User.FirstName + " " + s.User.LastName,
                    idClassroom = s.Classroom_Id,
                    idPeriod = s.Period_Id,
                    idUser = s.User_Id,
                    totalPoint = s.TotalPoint,
                }).First();

                return View(eval);
            }
        }

        [HttpPost]
        public ActionResult Edit(EvaluationModel em)
        {
            using (var x = new Entities())
            {
                var repo = new EvaluationRepository(x);
                EvaluationModel eval = repo.getById(em.id).Select(s => new EvaluationModel
                {
                    classroomTitle = s.Classroom.Title,
                    userName = s.User.UserName,
                    periodBegin = s.Period.Begin,
                    periodEnd = s.Period.End
                }).First();

                em.classroomTitle = eval.classroomTitle;
                em.userName = eval.userName;
                em.periodBegin = eval.periodBegin;
                em.periodEnd = eval.periodEnd;
                Evaluation e = repo.getById(em.id).First();
                createEvaluationToEvaluationModel(e, em);
                repo.Save();
                return RedirectToAction("Read", new { id = em.id });
            }
        }

        public Evaluation createEvaluationToEvaluationModel(EvaluationModel s)
        {
            Evaluation e = new Evaluation();
            e.Id = s.id;
            e.Date = s.date;
            e.TotalPoint = s.totalPoint;
            e.User_Id = s.idUser;
            e.Period_Id = s.idPeriod;
            e.Classroom_Id = s.idClassroom;
            return e;
        }

        public void createEvaluationToEvaluationModel(Evaluation e, EvaluationModel s)
        {
            e.Id = s.id;
            e.Date = s.date;
            e.TotalPoint = s.totalPoint;
            e.User_Id = s.idUser;
            e.Period_Id = s.idPeriod;
            e.Classroom_Id = s.idClassroom;
        }



        [HttpGet]
        public ActionResult AddResults(Guid id)
        {
            using (var x = new Entities())
            {
                PupilRepository pupilRepo = new PupilRepository(x);
                EvaluationRepository evalRepo = new EvaluationRepository(x);
                EvaluationModel eval = evalRepo.getById(id).Select(e => new EvaluationModel
                {
                    id = e.Id,
                    
                    idClassroom = e.Classroom_Id,
                    classroomTitle = e.Classroom.Title,
                    idUser = e.User_Id,
                    userName = e.User.FirstName + " " + e.User.LastName,
                    idPeriod = e.Period_Id,
                    periodBegin = e.Period.Begin,
                    periodEnd = e.Period.End,
                    date = e.Date,
                    totalPoint = e.TotalPoint
                }).First();
                List<PupilModel> pupils = pupilRepo.getByClassroomId(eval.idClassroom).Select(p => new PupilModel
                {
                    id = p.Id,
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    sex = p.Sex,
                    birthdayDate = p.BirthdayDate,
                    state = p.State,
                    tutorId = p.Tutor_Id,
                    tutorLastName = p.Tutor.LastName,
                    classroomId = p.Classroom_Id,
                    classroomTitle = p.Classroom.Title,
                    levelId = p.Level_Id,
                    levelTitle = p.Level.Title
                }).ToList();
                ViewData["pupils"] = pupils;
                ViewData["evaluation"] = eval;
                List<ResultModel> results = new List<ResultModel>();
                foreach (var pupil in pupils)
                {
                    results.Add(new ResultModel());
                }
                return View(results);
            }
        }

        [HttpPost]
        public ActionResult AddResults(List<ResultModel> results)
        {
            using (var x = new Entities())
            {
                var resultRepo = new ResultRepository(x);
                foreach (var result in results)
                {
                    result.id = Guid.NewGuid();
                    Result r = createResultModelToResult(result);
                    resultRepo.Add(r);
                }
                resultRepo.Save();
                var repoE = new EvaluationRepository(x);
                EvaluationModel m = repoE.getById(results[0].evaluationId).Select(e => new EvaluationModel
                {
                    id = e.Id,
                    classroomTitle = e.Classroom.Title,
                    date = e.Date,
                    idClassroom = e.Classroom_Id,
                    idPeriod =e.Period_Id,
                    idUser = e.User_Id,
                    periodBegin = e.Period.Begin,
                    periodEnd = e.Period.End,
                    totalPoint = e.TotalPoint,
                    userName = e.User.LastName
                }).First();

                return View("~/Views/Evaluation/Read.cshtml", m);
            }
        }

        private Result createResultModelToResult(ResultModel result)
        {
            Result r = new Result();
            r.Evaluation_Id = result.evaluationId;
            r.Id = result.id;
            r.Note = result.note;
            r.Pupil_Id = result.pupilId;
            return r;
        }

    }
}
