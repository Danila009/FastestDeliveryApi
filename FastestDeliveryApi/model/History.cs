using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.model
{
    public class History
    {
        [key]
        public Int32 Id { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public String Price { get; set; }

        [Required]
        public virtual List<HistoryFood> Foods { get; set; }

        public History()
        {
            Foods = new List<HistoryFood>();
        }
    }
}
