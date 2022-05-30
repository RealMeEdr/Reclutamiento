using Back_End_App.Models;
using Back_End_App.Controller;
using Newtonsoft.Json;

namespace Back_End_App.Pages

{
    partial class Clientes
    {
        private List<Models.Clientes> clientes = new List<Models.Clientes>();
        private List<Ajuste> ajustes = new List<Ajuste>();
        private List<Pagos> pagos = new List<Pagos>();
        private ResponseCodeModel response;
        private dbController funciones;
        MyDBContext context { get; set; }
        IConfiguration Configuration { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                funciones = new dbController(context);
                await ListaClientes();
                await ListaAjustes();
                await ListaPagos();
                StateHasChanged();
            }
        }
        private async Task<List<Models.Clientes>> ListaClientes()
        {
            
            ResponseCodeModel response = await funciones.ClientesList();
            if (response.Success)
            {
                 clientes = (List<Models.Clientes>)response.objectResponse;
                
            }
            else
            {
                Console.WriteLine(response.Error);
            }
            return clientes;
        }
        private async Task ListaAjustes()
        {
            ResponseCodeModel response = await funciones.AjustesList();
            if (response.Success)
            {
                ajustes = (List<Models.Ajuste>)response.objectResponse;
                
            }
            else
            {
                Console.WriteLine(response.Error);
            }
        }
        private async Task ListaPagos()
        {
            ResponseCodeModel response = await funciones.PagosList();
            if (response.Success)
            {
                pagos = (List<Pagos>)response.objectResponse;
                
            }
            else
            {
                Console.WriteLine(response.Error);
            }
        }
    }
}
