﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Entities
{
    public class BaseEntity
    {

        public BaseEntity() {
            CreationDate= DateTime.Now;
            ModifiedDate= DateTime.Now;
        }
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

       
        public DateTime ModifiedDate { get; set; }

    }
}
