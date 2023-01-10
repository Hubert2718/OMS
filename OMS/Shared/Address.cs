using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string Street { get; set; } = String.Empty;
        [Required]
        public string City { get; set; } = String.Empty;
        [Required]
        public int BuildingNumber { get; set; }
        public int ApartmentNumer { get; set; }
        [Required]
        public string PostalCode { get; set; } = String.Empty;
        [Required]
        public string Country { get; set; } = String.Empty;
    }
}
