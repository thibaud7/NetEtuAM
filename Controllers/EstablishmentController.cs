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
                    academyName = s.Academy.Name
                }).ToList();
                return View(list);
            }
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

    }
}
