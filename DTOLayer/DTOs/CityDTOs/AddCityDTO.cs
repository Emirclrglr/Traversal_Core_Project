using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CityDTOs
{
    public class AddCityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
    }
}
