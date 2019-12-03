using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZajazdURosanny.Models;
using ZajazdURosanny.ViewModel;

namespace ZajazdURosanny
{
    public class EFCDbContext : IdentityDbContext
    {
        public EFCDbContext(DbContextOptions<EFCDbContext> options): base(options)
        {
        }
        public DbSet<ZajazdURosanny.Models.MenuModel> MenuModel { get; set; }
        public DbSet<ZajazdURosanny.Models.NewsModel> NewsModel { get; set; }
        public DbSet<ZajazdURosanny.Models.RoleModel> RoleViewModel { get; set; }

    }
}
