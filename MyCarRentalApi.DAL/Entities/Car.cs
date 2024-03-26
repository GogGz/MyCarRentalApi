﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Entities
{
    public class Car : BaseEntity
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

    }
}
