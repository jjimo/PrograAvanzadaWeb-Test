using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperDAL shipperDAL;

        public ShipperController()
        {
            shipperDAL = new ShipperDALImpl(new Entities.Entities.NORTHWINDContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDAL.GetAll();
            return new JsonResult(shippers);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper;
            shipper = shipperDAL.Get(id);
            return new JsonResult(shipper);
        }
        #endregion

        #region Agregar
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Shipper shipper)
        {
            shipperDAL.Add(shipper);
            return new JsonResult(shipper);
        }
        #endregion

        #region Modificar
        [HttpPut]
        public JsonResult Put([FromBody] Shipper shipper)
        {
            shipperDAL.Update(shipper);
            return new JsonResult(shipper);
        }
        #endregion

        #region Eliminar
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Shipper shipper = new Shipper { ShipperId = id };
            shipperDAL.Remove(shipper);
            return new JsonResult(shipper);
        }
        #endregion
    }
}

