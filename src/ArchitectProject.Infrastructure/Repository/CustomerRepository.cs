﻿using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.Infrastructure.Repository
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(APContext context) : base(context) 
        {

        }
    }
}
