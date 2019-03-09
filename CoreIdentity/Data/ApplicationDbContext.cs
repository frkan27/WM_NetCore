using System;
using System.Collections.Generic;
using System.Text;
using CoreIdentity.Data.IndetityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Data
{
    //Identity nin kendi EntityFrameworkunu kullandığımız içn.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
