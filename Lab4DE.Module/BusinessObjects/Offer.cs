using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DE.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Offer : BaseObject
    {
        public Offer(Session session) : base(session) { }
        private DateTime rentStart;
        private TimeSpan rentSpan;
        private Renter owner;



        public DateTime RentStart   { get => rentStart; set => SetPropertyValue(nameof(RentStart), ref rentStart, value); }
        public TimeSpan RentSpan    { get => rentSpan;  set => SetPropertyValue(nameof(RentSpan), ref rentSpan, value); }
        [Association("OffersToOwner")]
        public Renter Owner         { get => owner;     set => SetPropertyValue(nameof(Owner), ref owner, value); }

        [Association("RoomsToOffer")]
        public XPCollection<Room> Rooms => GetCollection<Room>("Rooms");
    }
}
