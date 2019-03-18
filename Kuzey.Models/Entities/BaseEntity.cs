using System;
using System.Collections.Generic;
using System.Text;

namespace Kuzey.Models.Entities
{
   public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
