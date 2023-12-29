using APISample.MyApi.Models.Context;
using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.Entities;
using APISample.MyApi.Models.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.DAL
{
    public class ShipperDAL:IShipperDAL
    {
        MyContext _db;
        public ShipperDAL(MyContext db)
        {
            _db = db;
        }

        public int AddShipper(ShipperDTO addShipper)
        {
            //validation
            _db.Shippers.Add(new Shippers {CompanyName=addShipper.CompanyName,Phone=addShipper.Phone });
            return _db.SaveChanges();
        }

        public int DeleteShipper(int id)
        {
            _db.Shippers.Remove(_db.Shippers.Find(id));
            return _db.SaveChanges();
        }

        public int DeleteShipper(ShipperDTO addShipper)
        {
            throw new NotImplementedException();
        }

        public List<ShipperDTO> GetShippersAll()
        {
            return _db.Shippers.Select(a => new ShipperDTO { CompanyName = a.CompanyName, Phone = a.Phone, ShipperID = a.ShipperID }).ToList();
        }

        public int UpdateShipper(ShipperDTO addShipper)
        {
            throw new NotImplementedException();
        }

        public ShipperDTO GetShipperById(int id)
        {
            return _db.Shippers.Select(x=> new ShipperDTO() { CompanyName=x.CompanyName , Phone=x.Phone,ShipperID=x.ShipperID}).FirstOrDefault(s => s.ShipperID == id);
        }

    }
}
