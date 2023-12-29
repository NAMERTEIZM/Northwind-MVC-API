using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Dtos
{
    public class CiroShipperListeDTO
    {
        public List<ShipperDTO> KargoListe { get; set; }
        public decimal Ciro { get; set; }
    }
}
