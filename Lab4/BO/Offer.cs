using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.BO
{
    public class Offer
    {
        public DateTime RendStart { get; set; }
        public TimeSpan RendSpan { get; set; }
        public Renter Owner { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
