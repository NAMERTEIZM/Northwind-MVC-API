using APISample.MyApi.Models.Context;
using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.Entities;
using APISample.MyApi.Models.IDAL;
using APISample.MyApi.Models.Mappers;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.DAL
{
	public class ProductDal :IProductDal
	{
		MyContext _db;
        IDbConnection _connection; 
        Mapper _mapper;
		private bool disposedValue;

		public ProductDal(MyContext db,Mapper mapper,IDbConnection connection)
		{
            _db = db;
            _mapper = mapper;
            _connection = connection;
            //_connection.Open();
		}

        public List<Products> SelectAllProductWithInclude(Expression<Func<Products, bool>> filter, params string[] includes)
        {
            var query = _db.Set<Products>().AsQueryable().Where(filter);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }

		//public List<Products> SelectAllWithInclude(params string[] includes)
		//      {
		//          var query = _db.Set<Products>().AsQueryable();
		//          query = includes.Aggregate(query, (current, inc) => current.Include(inc));
		//          return query.ToList();
		//      }

		public List<ProductSelectDTO> GetAllProducts()
		{
            var sqlQuery = @"
         select p.ProductID , p.ProductName,p.QuantityPerUnit,p.UnitPrice,p.UnitsInStock,p.UnitsOnOrder,p.ReorderLevel,p.Discontinued,c.CategoryID,c.CategoryName,s.SupplierID,s.CompanyName FROM Products p inner join Categories c on p.CategoryID = c.CategoryID
         inner join Suppliers s on s.SupplierID = p.SupplierID ";
            List<ProductSelectDTO> products = _connection.Query<ProductSelectDTO>(sqlQuery).ToList();
            //var product=_mapper.Map<List<Products>, List<ProductSelectDTO>>(products);
            //select
            return products; 
		}
        public ProductUpdateDTO GetProductsByID(int id)
        {
            var sqlQuery = $"Select * from Products where ProductID = @ProductID";

            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id, DbType.String);

          //todo mapper yapilirss
            var entity = _connection.QueryFirstOrDefault<ProductUpdateDTO>(sqlQuery, parameters);

            return entity;
        }


        public int AddProduct(ProductInsertDTO addProduct)
		{
            var mapped = _mapper.Map<ProductInsertDTO, Products>(addProduct);
            var sqlQuery = @"
        INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, 
                              UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
        VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, 
                @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", addProduct.ProductName, DbType.String);
            parameters.Add("@SupplierID", addProduct.SupplierID, DbType.Int32);
            parameters.Add("@CategoryID", addProduct.CategoryID, DbType.Int32);
            parameters.Add("@QuantityPerUnit", addProduct.QuantityPerUnit, DbType.String);
            parameters.Add("@UnitPrice", addProduct.UnitPrice, DbType.Double);
            parameters.Add("@UnitsInStock", addProduct.UnitsInStock, DbType.Int16);
            parameters.Add("@UnitsOnOrder", addProduct.UnitsOnOrder, DbType.Int16);
            parameters.Add("@ReorderLevel", addProduct.ReorderLevel, DbType.Int16);
            parameters.Add("@Discontinued", addProduct.Discontinued, DbType.Boolean);
            return _connection.Execute(sqlQuery, parameters);
		}

        public int UpdateProduct(ProductUpdateDTO updateProduct)
        {
            var query = "UPDATE Products SET ProductName=@ProductName, SupplierID=@SupplierID, CategoryID=@CategoryID, UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,UnitsOnOrder=@UnitsOnOrder,QuantityPerUnit=@QuantityPerUnit,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued WHERE ProductID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", updateProduct.ProductID, DbType.Int32);
            parameters.Add("@ProductName", updateProduct.ProductName, DbType.String);
            parameters.Add("@SupplierID", updateProduct.SupplierID, DbType.Int32);
            parameters.Add("@CategoryID", updateProduct.CategoryID, DbType.Int32);
            parameters.Add("@UnitPrice", updateProduct.UnitPrice, DbType.Int32);
            parameters.Add("@UnitsInStock", updateProduct.UnitsInStock, DbType.Int32);
            parameters.Add("@UnitsOnOrder", updateProduct.UnitsOnOrder, DbType.Int32);
            parameters.Add("@QuantityPerUnit", updateProduct.QuantityPerUnit, DbType.String);
            parameters.Add("@ReorderLevel", updateProduct.ReorderLevel, DbType.Int32);
            parameters.Add("@Discontinued", updateProduct.Discontinued, DbType.Boolean);


            var rowaffected = _connection.Execute(query, parameters);

            return rowaffected;
        }

        public int DeleteProduct(int ID)
        {
            var query = "Delete from Products where ProductID=@ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID, DbType.Int32);
            var rowsAffected = _connection.Execute(query, parameters);
            return rowsAffected;
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
		// ~ProductDal()
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
