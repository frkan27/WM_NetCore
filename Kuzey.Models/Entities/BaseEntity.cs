 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kuzey.Models.Entities
{
   public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(450)]
        public string CreatedUserId { get; set; }
    }
}
