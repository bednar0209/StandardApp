using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StandardApp.Model.Entities
{
    public class Person : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }

    }
}
