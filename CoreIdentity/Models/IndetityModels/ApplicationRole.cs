using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Data.IndetityModels
{
    public class ApplicationRole:IdentityRole
    {
        [StringLength(128)]
        public string Description { get; set; }
    }
}

//enable- migration kullanmaya gerek yok. direkt add-migration yapabiliriz.
//