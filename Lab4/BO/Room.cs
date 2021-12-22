using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.BO
{
    public class Room
    {
        public int Floor { get; set; }
        public int Number { get; set; }
        
        public Offer CurrentContract { get; set; }
        public List<Offer> PerviousContracts { get; set; }
    }
}
