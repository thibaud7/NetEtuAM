﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class AcademyRepository
    {
        private Entities context;

        public AcademyRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Academy> All()
        {
            return context.Academies;
        }

        public IQueryable<Academy> getById(System.Guid id)
        {
            return context.Academies.Where(s => s.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Academy a)
        {
            context.Academies.Add(a);
        }

        public IQueryable<Academy> Search(String[] champs)
        {
            IQueryable<Academy> academies = context.Academies;
            if (champs[0] != "")
            {
                academies = academies.Where(a => champs.Contains(a.Name));
            }
            return academies;
        }
    }
}