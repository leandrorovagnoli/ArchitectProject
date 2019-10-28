using ArchitectProject.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Interfaces.Service
{
    public interface IApplicationUserService : IService<ApplicationUser>
    {
        ApplicationUser GetById(string id);
    }
}
