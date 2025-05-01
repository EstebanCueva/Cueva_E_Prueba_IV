using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cueva_E_Prueba.Models;

namespace Cueva_E_Prueba.Data
{
    public class Cueva_E_PruebaContext : DbContext
    {
        public Cueva_E_PruebaContext (DbContextOptions<Cueva_E_PruebaContext> options)
            : base(options)
        {
        }

        public DbSet<Cueva_E_Prueba.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<Cueva_E_Prueba.Models.Pet> Pet { get; set; } = default!;
    }
}
