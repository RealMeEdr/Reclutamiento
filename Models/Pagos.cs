namespace Back_End_App.Models
{
    public class Pagos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; } = new Clientes();
        public double MontoPagado { get; set; }
        public int Aplicado { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
