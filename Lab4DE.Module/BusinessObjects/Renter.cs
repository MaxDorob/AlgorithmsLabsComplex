using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.Collections.Generic;

namespace Lab4DE.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Renter: BaseObject
    {
        public Renter(Session session) : base(session) { }
        private string name;

        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }
        [Association("OffersToOwner")]
        public XPCollection<Offer> Offers => GetCollection<Offer>("Offers");
    }
}