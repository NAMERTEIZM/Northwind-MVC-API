using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.Entities;
using APISample.MyApi.Models.Helpers;
using APISample.MyApi.Models.IDAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.DAL
{
    public class ShipersDAL : IShipperDAL
    {
        private readonly ConnectionHelper _connectionHelper; 
        public ShipersDAL(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public int AddShipper(ShipperDTO addShipper)
        {
            var sqlQuery = $"INSERT INTO Shippers (CompanyName,Phone) values (@CompanyName,@Phone)";

            var parameters = new DynamicParameters();

            parameters.Add("@CompanyName", addShipper.CompanyName);
            parameters.Add("@Phone", addShipper.Phone);

            using var conn = _connectionHelper.CreateConnection();
            var rowsAffected = conn.Execute(sqlQuery, parameters);

            return rowsAffected;
        }

        public int DeleteShipper(ShipperDTO addShipper)
        {
            var sqlQuery = $"Delete from * Shippers where ShipperID = @ShipperID";

            var parameters = new DynamicParameters();

            parameters.Add("@ShipperID", addShipper.ShipperID);

            using var conn = _connectionHelper.CreateConnection();
            var rowsAffected = conn.Execute(sqlQuery, parameters);

            return rowsAffected;
        }

		public ShipperDTO GetShipperById(int id)
		{
			throw new NotImplementedException();
		}

		public List<ShipperDTO> GetShippersAll()
        {
            var sqlQuery = $"Select * from Shippers";

            using var conn = _connectionHelper.CreateConnection();
            var entity = conn.Query<ShipperDTO>(sqlQuery).ToList();

            return entity;
        }

        public int UpdateShipper(ShipperDTO addShipper)
        {
            var sqlQuery = $"UPDATE Shippers SET  CompanyName=@CompanyName, Phone=@Phone";

            var parameters = new DynamicParameters();

            parameters.Add("@CompanyName", addShipper.CompanyName);
            parameters.Add("@ShipperID", addShipper.ShipperID);
            parameters.Add("@Phone", addShipper.Phone);

            using var conn = _connectionHelper.CreateConnection();
            var rowsAffected = conn.Execute(sqlQuery, parameters);

            return rowsAffected;
        }
    }
}
