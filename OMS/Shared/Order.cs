using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
        public Status? Status { get; set; }
        public int StatusId { get; set; }
        public Address? Address { get; set; }  
        public int AddressId { get; set; }  
        public List<OrderProducts> OrderProducts { get; set; } = new List<OrderProducts>();
        public int OrderValue { get; set; }
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
