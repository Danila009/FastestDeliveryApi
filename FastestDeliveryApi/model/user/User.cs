using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.model.user
{
    public class User
    {
        [key]
        public Int32 Id { get; set; }

        [Required]
        public String FIO { get; set; }

        [Required]
        public Int32 Phone { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
