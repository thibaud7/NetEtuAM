using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class CycleRepository
    {
        private Entities context;

        public CycleRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Cycle> All() {
            return  context.Cycles;
        }

        public IQueryable<Cycle> getById(System.Guid id)
        {
           return  context.Cycles.Where(s => s.Id == id);
        }



        public IQueryable<Cycle> AllByTitle(String title)
        {
            IQueryable<Cycle> cycles =
                context.Cycles.Where(s => s.Title == title);
            return cycles;
        }

    }
}