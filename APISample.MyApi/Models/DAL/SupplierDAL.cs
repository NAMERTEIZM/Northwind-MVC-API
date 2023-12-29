﻿using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.IDAL;
using APISample.MyApi.Models.Mappers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.DAL
{
	public class SupplierDAL:ISupplierDAL
	{
		IDbConnection _connection;
		Mapper _mapper;
		private bool disposedValue;

		public SupplierDAL(IDbConnection connection, Mapper mapper)
		{
			_connection = connection;
			_mapper = mapper;
			//_connection.Open();
		}
		public List<SupplierSelectDTO> getAllSuppliers()
		{
			var query = "select * from Suppliers";
			var categories = _connection.Query<SupplierSelectDTO>(query).ToList();
			//var mapped = _mapper.Map< List<Category>,List<CategorySelectDTO>>(categories);
			return categories;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_connection.Dispose();
					_connection = null;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~CategoryDAL()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}

