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
            Companies = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public List<string> Companies { get; set; }
    }
}
