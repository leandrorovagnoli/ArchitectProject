using ArchitectProject.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.ApplicationCore.Interfaces.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);
    }
}
