using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactDemo.Models;

namespace ReactDemo.Services.WebService
{
    public partial class ApiClient
    {
        public async Task<List<Customer>> GetCustomer()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"Customer"));
            return await GetAsync<List<Customer>>(requestUrl);
        }
        

    }
}
