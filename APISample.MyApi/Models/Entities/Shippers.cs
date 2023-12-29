﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Entities
{
    public class Shippers
    {
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName{ get; set; }
        public string Phone{ get; set; }
    }
}
