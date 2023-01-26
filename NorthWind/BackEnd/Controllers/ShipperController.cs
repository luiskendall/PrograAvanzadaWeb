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

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDAL.GetAll();

            return new JsonResult(shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);

            return new JsonResult(shipper);
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] Shipper ship)
        {
            shipperDAL.Add(ship);

            return new JsonResult(ship);

        }
        #endregion

        #region Actualizar
        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Shipper ship)
        {
            shipperDAL.Update(ship);

            return new JsonResult(ship);

        }
        #endregion

        #region Eliminar
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Shipper ship = new Shipper { ShipperId = id };

            shipperDAL.Remove(ship);

            return new JsonResult(ship);
        }
        #endregion
    }
}
