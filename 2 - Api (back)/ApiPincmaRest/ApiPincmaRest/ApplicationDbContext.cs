using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiPincmaRest
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CryptoXBilletera>().HasKey(table => new {
                table.idCrypto,
                table.idBilletera
            });
        }

        public DbSet<Billetera> Billetera { get; set; }
        public DbSet<Crypto> Crypto { get; set; }
        public DbSet<CryptoXBilletera> cryptoXBilletera { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Domicilio> Domicilio { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Operacion> Operacion { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PrecioCompra> PrecioCompra { get; set; }
        public DbSet<PrecioVenta> PrecioVenta { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<RegistroIngresos> RegistroIngresos { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoOperacion> TipoOperacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


    }
}
