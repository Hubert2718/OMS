using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } =string .Empty;
        public string Producer { get; set; } = string.Empty;
    }
}
