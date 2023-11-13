using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SolforbUI.Models;

namespace SolforbUI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        private readonly ILogger<ProviderController> _logger;

        private readonly IMapper _mapper;

        public ProviderController(IProviderService providerService, ILogger<ProviderController> logger, IMapper mapper)
        {
            _providerService = providerService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Providers()
        {
            var providerList = _providerService.GetProviders().ToList();

            var result = _mapper.Map<List<ProviderDTO>, List<ProviderViewModel>>(providerList);

            return Ok(result);
        }
    }
}
