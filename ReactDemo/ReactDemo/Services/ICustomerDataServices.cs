using ReactDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Services
{
    public interface ICustomerDataServices
    {
        Task<IEnumerable<Customer>> GetCompaniesAsync();
        List<DataLayout> ProcessData(IList<Customer> companyList);
    }
}
