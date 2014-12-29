using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Models
{
    public class UserRepository
    {
        private Entities context;

        public UserRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<User> All() {
            return  context.Users;
        }

        public IQueryable<User> getById(Guid id)
        {
            return context.Users.Where(s => s.Id == id);
        }

    }
}
