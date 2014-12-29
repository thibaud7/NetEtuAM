using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class PeriodRepository
    {
        private Entities context;

        public PeriodRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Period> All() {
            return  context.Periods;
        }

        public IQueryable<Period> getById(System.Guid id)
        {
            return context.Periods.Where(s => s.Id == id);
        }

        public IQueryable<Period> getByYearId(System.Guid id)
        {
            return context.Periods.Where(s => s.Year_Id == id);
        }
    }
}