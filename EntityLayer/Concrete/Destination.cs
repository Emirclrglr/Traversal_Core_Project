using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? LengthOfStay { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string? CoverImage { get; set; }
        public string? Details1 { get; set; }
        public string? Details2 { get; set; }
        public string? Image2 { get; set; }
        public string? Details1Heading { get; set; }
        public string? Details2Heading { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }  
        public virtual ICollection<Reservation> Reservations { get; set; }
        public int? GuideId { get; set; }
        public Guide? Guide { get; set; }
    }
}
