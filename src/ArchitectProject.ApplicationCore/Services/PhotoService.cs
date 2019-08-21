using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _customerRepository;

        public PhotoService(IPhotoRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Photo Add(Photo customer)
        {
            return _customerRepository.Add(customer);
        }

        public void Delete(Photo customer)
        {
            _customerRepository.Delete(customer);
        }

        public IEnumerable<Photo> Find(Expression<Func<Photo, bool>> predicate)
        {
            return _customerRepository.Find(predicate);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Photo GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void Update(Photo customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
