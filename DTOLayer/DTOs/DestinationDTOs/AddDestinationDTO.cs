using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DestinationDTOs
{
    public class AddDestinationDTO
    {
        public string City { get; set; }
        public string LengthOfStay { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
