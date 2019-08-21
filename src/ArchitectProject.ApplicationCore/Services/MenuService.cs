using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _customerRepository;

        public MenuService(IMenuRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Menu Add(Menu customer)
        {
            return _customerRepository.Add(customer);
        }

        public void Delete(Menu customer)
        {
            _customerRepository.Delete(customer);
        }

        public IEnumerable<Menu> Find(Expression<Func<Menu, bool>> predicate)
        {
            return _customerRepository.Find(predicate);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Menu GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void Update(Menu customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
