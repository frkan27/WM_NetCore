﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGiris.Models
{
    [Table("Urunler")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(50), Column("Urun Adı")]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public virtual Category  Category { get; set; }
    }
}
