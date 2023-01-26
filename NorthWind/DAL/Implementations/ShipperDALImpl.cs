using DAL.Interfaces;
using Entities;
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
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int id)
        {
            Shipper shipper;
            using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
            {
                shipper = unidad.genericDAL.Get(id);
            }
            return shipper;
        }

        public IEnumerable<Shipper> GetAll()
        {
            try
            {
                IEnumerable<Shipper> shipper;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shipper = unidad.genericDAL.GetAll();
                }
                return shipper;
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
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
    }
}
