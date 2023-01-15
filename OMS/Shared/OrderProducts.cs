using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class OrderProducts
    {
        //[JsonIgnore]
        //public Order Order { get; set; }
        public int OrderId { get; set; } 
        public Product Product { get; set; }
        public int NumOfProducts { get; set; }
        public int ProductId { get; set; }  
    }
}
