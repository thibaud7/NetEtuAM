using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class LevelRepository
    {
        private Entities context;

        public LevelRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Level> All() {
            return  context.Levels;
        }

        public IQueryable<Level> getByCycleId(System.Guid id)
        {
            return context.Levels.Where(s => s.Cycle_Id == id);
        }

        public IQueryable<Level> getById(System.Guid id)
        {
            return context.Levels.Where(s => s.Id == id);
        }
    }
}