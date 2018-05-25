using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Database;

namespace RepositoryPattern_RepoInterfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> SelectAll();
        Customer SelectByID(string id);
        bool Insert(Customer obj);
        void Delete(string id);
        void Save();
    }
}
