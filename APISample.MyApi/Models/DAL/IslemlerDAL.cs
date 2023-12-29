using APISample.MyApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.DAL
{
    public class IslemlerDAL
    {
        MyContext _db;
        
        public IslemlerDAL(MyContext db)
        {
            _db = db;
        }

        public decimal CiroHesapla()
        {

            return _db.Order_Detail.Sum(a => (a.UnitPrice * a.Quantity * (1 - a.Discount)));
            
        }
    }
}
