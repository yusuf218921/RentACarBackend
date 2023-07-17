﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int RentalID { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public string RentDate { get; set; }
        public string? ReturnDate { get; set; }
    }
}
