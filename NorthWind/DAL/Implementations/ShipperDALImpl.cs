using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : IShipperDAL
    {

        NorthWindContext context;

        public ShipperDALImpl(NorthWindContext _Context)
        {
            context = _Context;

        }
        public bool Add(Shipper entity)
        {
            try
            {
                /*Forma codigo
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }

                return true;
                */

                //SP
                string sql = "exec [dbo].[SP_AddShipper] @CompanyName, @Phone";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@CompanyName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.CompanyName
                        },
                        new SqlParameter() {
                            ParameterName = "@Phone",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Phone
                        }
                };

                int resultado = context.Database.ExecuteSqlRaw(sql, param);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Shipper Get(int id)
        {

            /*Forma codigo
            using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
            {
                shipper = unidad.genericDAL.Get(id);
            }
            */

            //SP
            string sql = "exec [dbo].[SP_GetShipper] @ShipperID";
            var param = new SqlParameter()
            {
                ParameterName = "@ShipperID",
                SqlDbType = System.Data.SqlDbType.Int,
                //Size = 10,
                Direction = System.Data.ParameterDirection.Input,
                Value = id
            };
            var item = context.Shippers.FromSqlRaw(sql, param).ToList().FirstOrDefault();

            return item;
        }

        public IEnumerable<Shipper> GetAll()
        {
            try
            {
                /*Forma codigo
                IEnumerable<Shipper> shipper;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shipper = unidad.genericDAL.GetAll();
                }
                return shipper;
                */

                //SP
                List<Shipper> shippers = new List<Shipper>();
                List<SP_GetAllShippers_Result> result;
                string sql = "[dbo].[SP_GetAllShippers]";
                result = context.SP_GetAllShippers_Results
                .FromSqlRaw(sql)
                .ToList();

                foreach (var item in result)
                {
                    shippers.Add(
                        new Shipper
                        {
                            ShipperId = item.ShipperId,
                            CompanyName = item.CompanyName,
                            Phone = item.Phone,
                        }
                        );
                }

                return shippers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Shipper entity)
        {
            bool result = false;
            try
            {
                //Forma codigo
                /*
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
                */

                //SP
                string sql = "exec [dbo].[SP_DeleteShipper] @ShipperID";

                var param = new SqlParameter()
                {
                    ParameterName = "@ShipperID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    //Size = 10,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = entity.ShipperId
                };

                int resultado = context.Database.ExecuteSqlRaw(sql, param);

            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        public bool Update(Shipper entity)
        {
            bool result = false;
            try
            {
                //Forma codigo
                /*
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
                */

                //SP
                string sql = "exec [dbo].[SP_UpdateShipper] @ShipperID, @CompanyName ,@Phone";

                var param = new SqlParameter[] {
                     new SqlParameter() {
                            ParameterName = "@ShipperID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.ShipperId
                        },
                        new SqlParameter() {
                            ParameterName = "@CompanyName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.CompanyName
                        },
                        new SqlParameter() {
                            ParameterName = "@Phone",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Phone
                        }
                };

                int resultado = context.Database.ExecuteSqlRaw(sql, param);
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        #region Not Implemented
        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
