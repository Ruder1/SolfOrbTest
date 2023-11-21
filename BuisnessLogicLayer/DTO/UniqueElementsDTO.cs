using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DTO
{
    public class UniqueElementsDTO
    {
        public List<string>? Orders { get; init; }

        public List<string>? Items { get; init; }

        public List<string>? Providers { get; init; }

        public List<string>? Units { get; init; }
    }
}
