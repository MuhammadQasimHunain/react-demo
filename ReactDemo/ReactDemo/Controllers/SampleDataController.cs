using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Domain;
using ReactDemo.Models;

namespace ReactDemo.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public IComanyDomain  CompanyDomain{ get; set; }
        public SampleDataController(IComanyDomain comanyDomain)
        {
            CompanyDomain = comanyDomain;
        }
        
        [HttpGet("[action]")]
        public async Task<IEnumerable<DataLayout>> GetCompaniesData()
        {
            return await CompanyDomain.GetCompaniesAsync();
        }

        
    }
}
