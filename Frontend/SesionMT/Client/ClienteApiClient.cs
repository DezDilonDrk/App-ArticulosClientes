using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Articulos_Frontend.Client
{
    public class ClienteApiClient
    {
        UserSession mySession;
        private EnsureFunctions ensureFunctions = new EnsureFunctions();
        public ClienteApiClient(UserSession session){
            this.mySession = session;
        }
        public async Task InitAsync(string currentServer)
        {
            this.mySession = new UserSession(currentServer);
            mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            try
            {
                return await this.mySession.GetClient().GetFromJsonAsync<List<Cliente>>("/clientes");
            } catch(Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            try
            {
                return await this.mySession.GetClient().GetFromJsonAsync<List<Cliente>>($"/clientes?nombre={nombre}");
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
        public async Task<Cliente?> ObtenerPorDni(string dni)
        {
            try
            {
                return await this.mySession.GetClient().GetFromJsonAsync<Cliente>($"/clientes/{dni}");
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
        public async Task Crear(Cliente cliente)
        {
            try
            {
                var response = await this.mySession.GetClient().PostAsJsonAsync("/clientes", cliente);
                ensureFunctions.ensureGet(response);
            } catch (Exception ex) {
                Log.Error(ex); 
                throw;
            }
        }
        public async Task<bool> Actualizar(string dni, Cliente cliente)
        {
            try
            {
                var response = await this.mySession.GetClient().PutAsJsonAsync($"/clientes/{dni}", cliente);
                ensureFunctions.ensureGet(response);
                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
        public async Task Eliminar(string dni)
        {
            try
            {
                var pedidos = await this.mySession.GetClient().GetFromJsonAsync<List<Pedido>>($"/pedidos/cliente?dni={dni}");
                if (pedidos != null && pedidos.Count > 0)
                {
                    Log.Warn($"No se puede eliminar el cliente con DNI {dni} porque tiene pedidos asociados.");
                    throw new Exception($"El cliente tiene pedidos asociados, por lo que no se ha realizado su eliminación");
                }
                var response = await this.mySession.GetClient().DeleteAsync($"/clientes/{dni}");
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
    }
}
