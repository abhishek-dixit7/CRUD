using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class AddressModel
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string addressline { get; set; }
    }
}
