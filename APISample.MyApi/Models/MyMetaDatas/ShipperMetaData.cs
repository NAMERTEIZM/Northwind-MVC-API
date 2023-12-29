using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.MyMetaDatas
{
    [ModelMetadataType(typeof(ShipperMetaData))]
    public class ShipperMetaData
    {
        public int ShipperID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
    }
}
