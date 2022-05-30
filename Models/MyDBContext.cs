using Microsoft.EntityFrameworkCore;
using System;
namespace Back_End_App.Models
{
    public class MyDBContext : DbContext
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

        }
        public DbSet<Clientes> Cliente { get; set;}
        public DbSet<Ajuste> Ajustes { get; set;}
        public DbSet<Pagos> Pagos { get; set;}

    }
}
