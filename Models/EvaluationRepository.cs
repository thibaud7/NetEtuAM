using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class EvaluationRepository
    {
        private Entities context;

        public EvaluationRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Evaluation> All()
        {
            return context.Evaluations;
        }

        public IQueryable<Evaluation> getById(Guid id)
        {
            return context.Evaluations.Where(s => s.Id == id);
        }

        public IQueryable<Evaluation> getByClassroomId(Guid id)
        {
            return context.Evaluations.Where(s => s.Classroom_Id == id);
        }

        public IQueryable<Evaluation> getByPeriodId(Guid id)
        {
            return context.Evaluations.Where(s => s.Period_Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Evaluation s)
        {
            context.Evaluations.Add(s);
        }
    }
}