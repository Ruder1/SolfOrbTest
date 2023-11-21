using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SolforbUI.Models;

namespace SolforbUI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class FilterController : Controller
    {

        private readonly IFilterService _filterService;

        private readonly ILogger<ProviderController> _logger;

        private readonly IMapper _mapper;

        public FilterController(IFilterService filterService, ILogger<ProviderController> logger, IMapper mapper)
        {
            _filterService = filterService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UniqueElements()
        {
            var tempDTO = _filterService.GetUniqueElements();

            var result = _mapper.Map<UniqueElementsDTO, UniqueElementsViewModel>(tempDTO);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult FilterData(DataToFilterViewModel elements)
        {
            var data = _mapper.Map<DataToFilterViewModel, DataToFilterDTO>(elements);

            var temp = _filterService.GetFilteredElements(data);

            var result = _mapper.Map<List<OrderDTO>, List<OrderViewModel>>(temp);
            
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Test(DataToFilterViewModel test)
        {
            return Ok(test);
        }
    }
}
