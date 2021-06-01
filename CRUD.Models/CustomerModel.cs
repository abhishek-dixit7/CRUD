using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }
        public int? addressId { get; set; }

        public AddressModel Address { get; set; }
    }
}
