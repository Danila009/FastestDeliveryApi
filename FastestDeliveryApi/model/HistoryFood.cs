using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.model
{
    public class HistoryFood
    {
        [key]
        public Int32 Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Int32 Price { get; set; }

        [Required]
        public Int32 Number { get; set; }
    }
}
