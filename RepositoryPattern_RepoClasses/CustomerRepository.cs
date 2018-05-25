using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RepositoryPattern_RepoInterfaces;
using Repository_Database;

namespace RepositoryPattern_RepoClasses
{

    public class CustomerRepository : ICustomerRepository
    {
        INorthwind_DBEntities NorthwindContext;

        public CustomerRepository(INorthwind_DBEntities dbContext)
        {
            NorthwindContext = dbContext;            
        }
        public IEnumerable<Customer> SelectAll()
        {
         return NorthwindContext.Customers.ToList();
        }

        public Customer SelectByID(string id)
        {
        return NorthwindContext.Customers.Find(id);
        }

        public bool Insert(Customer obj)
        {
            NorthwindContext.Customers.Add(obj);
            return true;
        }
        public void Delete(string id)
        {
            var value = NorthwindContext.Customers.Where(i => i.CustomerID == id).FirstOrDefault();
            NorthwindContext.Customers.Remove(value);
        }
        public void Save()
        {
            NorthwindContext.SaveChanges();
        }
    }
}
