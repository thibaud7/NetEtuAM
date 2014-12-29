using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class EstablishmentRepository
    {
        private Entities context;

        public EstablishmentRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Establishment> All()
        {
            return context.Establishments;
        }

        public IQueryable<Establishment> getById(Guid id)
        {
            return context.Establishments.Where(s => s.Id == id);
        }

        public IQueryable<Establishment> getByAcademyId(System.Guid id)
        {
            return context.Establishments.Where(s => s.Academie_Id == id);
        }


    }
}