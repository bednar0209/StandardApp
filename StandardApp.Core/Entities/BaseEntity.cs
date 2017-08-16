/*****************
* This abstract class need for creating derived Entities 
* Example class ProductEntity : BaseEntity
*
*****************/
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.CodeFirst.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
