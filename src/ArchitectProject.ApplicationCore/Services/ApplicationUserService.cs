using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public ApplicationUser Add(ApplicationUser applicationUser)
        {
            return _applicationUserRepository.Add(applicationUser);
        }

        public void Delete(ApplicationUser applicationUser)
        {
            _applicationUserRepository.Delete(applicationUser);
        }

        public IEnumerable<ApplicationUser> Find(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return _applicationUserRepository.Find(predicate);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _applicationUserRepository.GetAll();
        }

        public ApplicationUser GetById(int id)
        {
            return _applicationUserRepository.GetById(id);
        }

        public ApplicationUser GetById(string id)
        {
            return _applicationUserRepository.GetById(id);
        }

        public void Update(ApplicationUser applicationUser)
        {
            var applicationUserDb = _applicationUserRepository.GetById(applicationUser.Id);
            applicationUserDb.FirstName = applicationUser.FirstName;
            applicationUserDb.LastName = applicationUser.LastName;
            applicationUserDb.Email = applicationUser.Email;
            applicationUserDb.Street = applicationUser.Street;
            applicationUserDb.State = applicationUser.State;
            applicationUserDb.PostalCode = applicationUser.PostalCode;
            applicationUserDb.PhoneNumber = applicationUser.PhoneNumber;
            applicationUserDb.PasswordHash= applicationUser.PasswordHash;
            applicationUserDb.Country = applicationUser.Country;
            applicationUserDb.City = applicationUser.City;
            applicationUserDb.AvatarImage = applicationUser.AvatarImage;

            _applicationUserRepository.Update(applicationUserDb);
            //_applicationUserRepository.Update(applicationUser);
        }
    }
}
