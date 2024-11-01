﻿using AutoMapper;
using AutomapperDemo.Model;
using AutomapperDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //Create a variable to holder mapper instance
        private readonly IMapper _mapper;

        //Framework will inject the instance using Constructor
        public OrderController(IMapper mapper)
        {
            //Initialize the variable with the injected mapper instance
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrder(int id)
        {
            var order = new Order
            {
                OrderId = id,
                OrderDate = DateTime.Now,
                CustomerName = "Pranaya",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Product 1", Price = 100m, Quantity = 2 },
                    new OrderItem { ProductName = "Product 2", Price = 50m, Quantity = 1 },
                    // Add more items as needed
                }
            };

            //Map the Order with OrderDTO
            var orderDto = _mapper.Map<OrderDTO>(order);

            return Ok(orderDto);
        }
    }
}
