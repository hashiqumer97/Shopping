using AutoMapper;
using Shopping.BL.Interface;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using Shopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(CustomerBL customer)
        {
            try
            {
                var cust = mapper.Map<CustomerDL>(customer);
                unitOfWork.CustomerRepository.Create(cust);
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CustomerBL> GetCustomers()
        {
            try
            {
                var query = unitOfWork.CustomerRepository.Get();
                return mapper.Map<IEnumerable<CustomerBL>>(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
