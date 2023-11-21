using BuisnessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IFilterService
    {
        public UniqueElementsDTO GetUniqueElements();

        public List<OrderDTO> GetFilteredElements(DataToFilterDTO elements);
    }
}
