using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class YearRepository
    {
        private Entities context;

        public YearRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Year> All() {
            return  context.Years;
        }

        public IQueryable<Year> getById(Guid id)
        {
            return context.Years.Where(s => s.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(Year s)
        {
            context.Years.Add(s);
        }
    
    }
}