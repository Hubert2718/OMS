using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Email {  get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public int NumberOfOrders { get; set; }
    }
}
