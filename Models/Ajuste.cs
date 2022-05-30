namespace Back_End_App.Models
{
    public class Ajuste
    {
        public int AjusteId { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; } = new Clientes();
        public double MontoTotal { get; set; }
        public double Adeudo { get; set; }
    }
}
