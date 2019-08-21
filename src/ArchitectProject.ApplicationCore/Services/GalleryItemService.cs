using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Services
{
    public class GalleryItemService : IGalleryItemService
    {
        private readonly IGalleryItemRepository _customerRepository;

        public GalleryItemService(IGalleryItemRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public GalleryItem Add(GalleryItem customer)
        {
            return _customerRepository.Add(customer);
        }

        public void Delete(GalleryItem customer)
        {
            _customerRepository.Delete(customer);
        }

        public IEnumerable<GalleryItem> Find(Expression<Func<GalleryItem, bool>> predicate)
        {
            return _customerRepository.Find(predicate);
        }

        public IEnumerable<GalleryItem> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public GalleryItem GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void Update(GalleryItem customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
