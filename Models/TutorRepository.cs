﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class TutorRepository
    {
        private Entities context;

        public TutorRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Tutor> All() {
            return  context.Tutors;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Tutor s)
        {
            context.Tutors.Add(s);
            
        }

        public IQueryable<Tutor> getById(System.Guid id)
        {
            return context.Tutors.Where(s => s.Id == id);
        }

        public IQueryable<Tutor> Search(String[] mots)
        {
            IQueryable<Tutor> tutor = context.Tutors;
            if (mots[0] != "")
            {
                tutor = tutor.Where(t => mots.Contains(t.FirstName)
                                    || mots.Contains(t.LastName));
            }
            return tutor;
        }

    }
}