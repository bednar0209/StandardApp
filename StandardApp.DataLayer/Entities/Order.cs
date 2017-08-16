using System;
using System.ComponentModel.DataAnnotations;

namespace StandardApp.Model.Entities
{

    public class Order : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(160)]
        public string Description { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }

}