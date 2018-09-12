using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Models
{
    public class DataLayout
    {
        public DataLayout()
        {
            Customers = new List<Customer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
