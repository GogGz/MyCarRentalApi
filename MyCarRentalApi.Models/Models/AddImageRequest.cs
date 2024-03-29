using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Models.Models
{
    public class AddImageRequest
    {
        //public string FileName { get; set; }

        public IFormFile File { get; set; }
    }
}
