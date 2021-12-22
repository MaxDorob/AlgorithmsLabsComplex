using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DE.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Room : BaseObject
    {
        public Room(Session session) : base(session) { }

        private int floor;
        private int number;

        public int Floor { get => floor; set => SetPropertyValue(nameof(Floor), ref floor, value); }
        public int Number { get => number; set => SetPropertyValue(nameof(Number), ref number, value); }

        [Association("RoomsToOffer")]
        public XPCollection<Offer> Offers => GetCollection<Offer>("Offers");
    }
}
