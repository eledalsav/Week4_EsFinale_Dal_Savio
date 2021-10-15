using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMainBL mainBusinessLayer;

        public OrderController(IMainBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }

        //Implementare le action -> chiamano metodi del business layer

        //Esempio nella GetOrders

        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = mainBusinessLayer.FetchOrders();
            return Ok(orders);
        
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

           Order order =mainBusinessLayer.GetOrderById(id);

            if (order== null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }

        // POST api/order
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Dati ordine non validi");

            bool isAdded = mainBusinessLayer.CreateOrder(order);

            if (!isAdded)
                return StatusCode(500, "Book could not be saved");

            return CreatedAtAction("CreateOrder", order);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            throw new NotImplementedException();
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");
            Order orderToDelete = mainBusinessLayer.GetOrderById(id);
            bool isDeleted =mainBusinessLayer.DeleteOrder(orderToDelete);

            if (!isDeleted)
                return StatusCode(500, "Order could not be deleted");

            return Ok();
        }
    }
}
