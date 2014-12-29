﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuvrayMonmertNetEdu.Models;

namespace AuvrayMonmertNetEdu.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index()
        {
            using (var x = new Entities())
            {
                var repo = new ResultRepository(x);
                List<ResultModel> list = repo.All().Select(s => new ResultModel
                {
                    id = s.Id,
                    evaluationId = s.Evaluation_Id,
                    pupilFirstName = s.Pupil.FirstName,
                    pupilLastName = s.Pupil.LastName,
                    note = s.Note
                }).ToList();
                return View(list);
            }
        }

    }
}
