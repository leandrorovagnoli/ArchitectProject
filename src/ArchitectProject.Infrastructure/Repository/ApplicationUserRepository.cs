using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.Infrastructure.Repository
{
    public class ApplicationUserRepository : EFRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(APContext context) : base(context) 
        {
            
        }

        public ApplicationUser GetById(string id)
        {
            return _dbContext.Set<ApplicationUser>().AsNoTracking().Single(x => x.Id == id);
        }

        public override IEnumerable<ApplicationUser> GetAll()
        {
            return _dbContext.Set<ApplicationUser>().AsNoTracking();
        }
    }
}
