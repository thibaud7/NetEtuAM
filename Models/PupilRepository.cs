﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class PupilRepository
    {
        private Entities context;

        public PupilRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Pupil> All() {
            return  context.Pupils;
        }

        public IQueryable<Pupil> getByClassroomId(Guid id)
        {
            return context.Pupils.Where(s => s.Classroom_Id == id);
        }

        public IQueryable<Pupil> getByTutorId(Guid id)
        {
            return context.Pupils.Where(s => s.Tutor_Id == id);
        }

        public IQueryable<Pupil> getByLevelId(Guid id)
        {
            return context.Pupils.Where(s => s.Level_Id == id);
        }

        public IQueryable<Pupil> getById(Guid id)
        {
            return context.Pupils.Where(s => s.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Pupil s)
        {
            context.Pupils.Add(s);
        }

        public IQueryable<Pupil> Search(String[] mots)
        {
            IQueryable<Pupil> pupil = context.Pupils;
            if (mots[0] != "")
            {
                pupil = pupil.Where(p => mots.Contains(p.FirstName)
                                    || mots.Contains(p.LastName));
            }
            return pupil;
        }

    }
}