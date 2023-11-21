using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DTO
{
    public class DataToFilterDTO:UniqueElementsDTO
    {
        public DateOnly PreviousDate { get; set; }

        public DateOnly CurrentDate { get; set; }
    }
}
