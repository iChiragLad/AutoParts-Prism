﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.AutoParts.DataAccess
{
    public class Parts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime Dop { get; set; }
        public int ImageID { get; set; }
    }
}
