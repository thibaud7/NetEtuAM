using AuvrayMonmertNetEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class LevelController : Controller
    {
        //
        // GET: /Level/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new LevelRepository(x);
                List<LevelModel> list = repo.All().Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title,
                    idCycle = s.Cycle.Id,
                    nomCycle = s.Cycle.Title
                }).ToList();
                return View(list);
            }

        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var x = new Entities())
            {
                var repoLevel = new PupilRepository(x);
                List<PupilModel> listPupils = repoLevel.getByLevelId(id).Select(s => new PupilModel
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
                var repo = new LevelRepository(x);
                LevelModel level = repo.getById(id).Select(s => new LevelModel
                {
                    id = s.Id,
                    title = s.Title,
                }).First();
                level.pupils = listPupils;
                return View(level);
            }

        }


    }
}
