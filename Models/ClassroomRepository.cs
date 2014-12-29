using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class ClassroomRepository
    {
        private Entities context;

        public ClassroomRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Classroom> All() {
            return  context.Classrooms;
        }

        public IQueryable<Classroom> getByEstablishmentId(Guid id)
        {
            return context.Classrooms.Where(s => s.Establishment_Id == id);
        }

        public IQueryable<Classroom> getByYearId(Guid id)
        {
            return context.Classrooms.Where(s => s.Year_Id == id);
        }

        public IQueryable<Classroom> getById(Guid id)
        {
            return context.Classrooms.Where(s => s.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Classroom s)
        {
            context.Classrooms.Add(s);

        }
    }
}