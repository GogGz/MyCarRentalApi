using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Models.Models
{
    public class GetAllCarsResponse
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
