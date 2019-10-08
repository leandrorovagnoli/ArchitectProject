using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return _customerRepository.Find(predicate);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void Update(Customer customer)
        {
            //var customerDb = _customerRepository.GetById(customer.Id);
            //customerDb.Name = customer.Name;
            //customerDb.LastName = customer.LastName;
            //customerDb.Email = customer.Email;
            //customerDb.Phone = customer.Phone;

            //_customerRepository.Update(customerDb);
            _customerRepository.Update(customer);
        }
    }
}
