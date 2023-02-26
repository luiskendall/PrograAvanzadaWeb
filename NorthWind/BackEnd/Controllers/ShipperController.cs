using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        private IShipperDAL shipperDAL;

        //Constructor
        public ShipperController()
        {
            shipperDAL = new ShipperDALImpl(new Entities.NorthWindContext());
        }

        #region Convetidores

        private ShipperModel ConvertShipperToModel(Shipper ship)
        {
            return new ShipperModel
            {
                ShipperId = ship.ShipperId,
                CompanyName = ship.CompanyName,
                Phone = ship.Phone
            };
        }

        private Shipper ConvertShipperToEntity(ShipperModel shipModel)
        {
            return new Shipper
            {
                ShipperId = shipModel.ShipperId,
                CompanyName = shipModel.CompanyName,
                Phone = shipModel.Phone,
            };
        }
        #endregion

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDAL.GetAll();
            List<ShipperModel> listShipper = new List<ShipperModel>();

            foreach (var shipper in shippers)
            {
                listShipper.Add(ConvertShipperToModel(shipper));
            }

            return new JsonResult(listShipper);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);

            return new JsonResult(ConvertShipperToModel(shipper));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShipperModel shipModel)
        {
            Shipper entity = ConvertShipperToEntity(shipModel);
            shipperDAL.Add(entity);

            return new JsonResult(ConvertShipperToModel(entity));

        }
        #endregion

        #region Actualizar
        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShipperModel shipModel)
        {
            shipperDAL.Update(ConvertShipperToEntity(shipModel));

            return new JsonResult(shipModel);

        }
        #endregion

        #region Eliminar
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Shipper ship = new Shipper { ShipperId = id };

            shipperDAL.Remove(ship);

            return new JsonResult(ConvertShipperToModel(ship));
        }
        #endregion
    }
}
