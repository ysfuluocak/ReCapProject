﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetails : IDto
    {
        public int RentalId { get; set; }
        public string CompanyName { get; set; }
        public string MyProperty { get; set; }
        public string CarName { get; set; }
    }
}