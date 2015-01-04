using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class ResultRepository
    {
        private Entities context;

        public ResultRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Result> All()
        {
            return context.Results;
        }

        public IQueryable<Result> getByPupilId(Guid id)
        {
            return context.Results.Where(s => s.Pupil_Id == id);
        }

        public IQueryable<Result> getByEvaluationId(Guid id)
        {
            return context.Results.Where(s => s.Evaluation_Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public void Add(Result s)
        {
            context.Results.Add(s);
        }
    }
}