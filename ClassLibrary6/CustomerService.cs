using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern_ServiceInterfaces;
using RepositoryPattern_RepoInterfaces;
using Repository_Database;

namespace RepositoryPattern_ServiceClasses
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _CustomerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _CustomerRepo = customerRepo;
        }
        public IEnumerable<Customer> SelectAll()
        {
            return _CustomerRepo.SelectAll();
        }

        public Customer SelectByID(string id)
        {
            return _CustomerRepo.SelectByID(id);
        }

        public bool Insert(Customer obj)
        {
            return _CustomerRepo.Insert(obj);            
        }
        public void Delete(string id)
        {
            _CustomerRepo.Delete(id);            
        }
        
    }
}
