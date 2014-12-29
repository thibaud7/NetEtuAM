using AuvrayMonmertNetEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new UserRepository(x);
                List<UserModel> list = repo.All().Select(s => new UserModel
                {
                    id = s.Id,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    userName = s.UserName,
                    mail = s.Mail,
                }).ToList();
                return View(list);
            }
        }

    }
}
