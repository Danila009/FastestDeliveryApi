using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.model
{
    public class Food
    {
        [key]
        public String Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Int32 Price { get; set; }

        [Required]
        public String Discription { get; set; }

        [Required]
        public String Category { get; set; }
    }
}
