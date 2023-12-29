using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.IDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KargoController : ControllerBase
    {
        private readonly IShipperDAL _dal; 
        private readonly IIslemlerDAL _islemlerDAL; 
        public KargoController(IShipperDAL dal, IIslemlerDAL islemlerDAL)
        {
            _dal = dal;
            _islemlerDAL = islemlerDAL;
        }

        [HttpGet("~/api/kargolarigetir")]
        public List<ShipperDTO> KargolariGetir()
        {
            return _dal.GetShippersAll();
        }

        [HttpGet("~/api/kargolarTumCiro")]
        public CiroShipperListeDTO KargolariTumCiroGetir()
        {
            //to do
            // return Ok();
            // apideyken dbye iki defa gidilmeli mi
            return new CiroShipperListeDTO()
            {
                KargoListe = _dal.GetShippersAll(),
                Ciro = _islemlerDAL.CiroHesapla()
            };

        }


        [HttpPost("~/api/kargoekle")]
        public ActionResult POST([FromBody] ShipperDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (_dal.AddShipper(dto) > 0)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpGet("{id:int}")]
        public ActionResult GetShipper(int id)
        {
            var a = _dal.GetShipperById(id);


            return Ok();
        }


        [HttpPost("~/api/kargosil")]
        public ActionResult Silme([FromBody] ShipperDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (_dal.DeleteShipper(dto) > 0)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpPut("~/api/Guncelle")]
        public ActionResult PUT([FromBody] ShipperDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (_dal.UpdateShipper(dto) > 0)
            {
                return Ok();
            }



            return BadRequest();

        }

        [HttpDelete("{shipperID}")]
        public ActionResult Delete(int shipperID)
        {
            if (_dal.UpdateShipper(new ShipperDTO {ShipperID=shipperID }) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpHead("{shipperID}")]
        public ActionResult Head(int shipperID)
        {
            HttpContext.Response.Headers.Add("x-rate-limit", "50");
            // head de RateLimit tutuluyor


            return BadRequest();
        }

        [HttpOptions("{shipperID}")]
        public ActionResult Options(int shipperID)
        {
            // HTTP yöntemlerini ve diğer özelliklerini almak için kullanılır.
            HttpContext.Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
            return NoContent();
        }


        // kısmi güncelleme yapılır daha hızlı olabilir
        [HttpPatch]
        public ActionResult Patch(int id,string name)
        {
            if (_dal.UpdateShipper(new ShipperDTO { ShipperID = id, CompanyName = name }) > 0)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
