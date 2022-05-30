using Microsoft.EntityFrameworkCore;

namespace Back_End_App.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public long Phone { get; set; }
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public double MontoSolicitud { get; set; }
        public string Estatus { get; set; } = "";
        public string Aprobacion { get; set; } = "";
        public DateTime FechaAlta { get; set; }
        public ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();
        public ICollection<Ajuste> Ajustes { get; set; } = new List<Ajuste>();
    }
}
