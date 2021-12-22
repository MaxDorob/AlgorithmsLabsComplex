using System.Collections.Generic;

namespace Lab4.BO
{
    public class Renter
    {
        public string Name { get; set; }
        public List<Offer> Offers{ get; set; }
    }
}