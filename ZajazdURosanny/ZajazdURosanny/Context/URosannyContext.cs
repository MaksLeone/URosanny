using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZajazdURosanny.Models.Db;

namespace ZajazdURosanny.Context
{
    public class URosannyContext : DbContext
    {
        public URosannyContext(DbContextOptions<URosannyContext> options) : base(options)
        {

        }
    }
}
