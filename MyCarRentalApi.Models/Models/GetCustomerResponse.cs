using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Models.Models
{
    public class GetCustomerResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
