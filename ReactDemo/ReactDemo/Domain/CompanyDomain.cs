using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactDemo.Models;
using ReactDemo.Services.WebService;
using ReactDemo.Services;

namespace ReactDemo.Domain
{
    public class CompanyDomain : IComanyDomain
    {
        //Dependecy Injection
        public ICustomerDataServices CustomerDataServices { get; set; }
        public CompanyDomain(ICustomerDataServices customerDataServices)
        {
            CustomerDataServices = customerDataServices;
        }
        public async Task<IList<DataLayout>> GetCompaniesAsync()
        {
            IEnumerable<Customer> customers = await CustomerDataServices.GetCompaniesAsync();
            IList<DataLayout> customerProcessedData = CustomerDataServices.ProcessData(customers.ToList());
            
            return customerProcessedData;
        }
    }
}
