using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ReactDemo.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "CustomerId")]
        public string CustomerId { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "Surname")]
        public string Surname { get; set; }
    }
}
