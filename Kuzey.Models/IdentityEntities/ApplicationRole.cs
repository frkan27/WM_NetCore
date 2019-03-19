using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kuzey.Models.IdentityEntities
{
   public  class ApplicationRole:IdentityRole
    {
        [StringLength(128)]
        public string Description { get; set; }
    }
}
