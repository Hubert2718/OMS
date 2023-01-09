using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public int BuildingNumber { get; set; }
        public int ApartmentNumer { get; set; }
        public string PostalCode { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
    }
}
