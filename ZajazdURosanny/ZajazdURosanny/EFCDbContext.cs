using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZajazdURosanny
{
    public class EFCDbContext : IdentityDbContext
    {
        public EFCDbContext(DbContextOptions<EFCDbContext> options): base(options)
        {

        }
    }
}
