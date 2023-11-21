using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SolforbUI.Models;

namespace SolforbUI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly ILogger<ProviderController> _logger;

        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, ILogger<ProviderController> logger, IMapper mapper)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var order = _orderService.GetOrders().ToList();

            var result = _mapper.Map<List<OrderDTO>, List<OrderViewModel>>(order);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            var orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);

            if (_orderService.CheckOrderAndProvider(orderDTO))
            {
                _orderService.CreateOrder(orderDTO);
                return Ok();
            }
            else
            {
                return BadRequest("Number isn't unique");
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(OrderViewModel order)
        {
            var orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);

            _orderService.UpdateOrder(orderDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
