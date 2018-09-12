using ReactDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Domain
{
    public interface IComanyDomain
    {
        Task<IList<DataLayout>> GetCompaniesAsync();
    }
}
