using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;


namespace Articulos_Frontend.Client;

public class PedidoApiClient
{
    private TokenHelper tokenHelper = new TokenHelper();
    UserSession mySession;
    private EnsureFunctions ensureFunctions = new EnsureFunctions();
    public PedidoApiClient(UserSession session){
        this.mySession = session;
    }
    public async Task InitAsync(string currentServer)
    {
        /*this.mySession = new UserSession(currentServer, mySession.CargarToken());
        mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");*/
    }
    public UserSession GetSession()
    {
        return this.mySession;
    }
    public async Task<List<Pedido>> ObtenerPedidos()
    {
        try
        {
            await checkTokenExpiration();
            return await this.mySession.GetClient().GetFromJsonAsync<List<Pedido>>("/pedidos");
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Pedido> BuscarPorIdPedido(string id)
    {
        try
        {
            await checkTokenExpiration();
            return await this.mySession.GetClient().GetFromJsonAsync<Pedido>($"/pedidos/{id}");
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<Pedido>?> ObtenerPorDniCliente(string dni)
    {
        try
        {
            await checkTokenExpiration();
            List<Pedido> pedidos = await this.mySession.GetClient().GetFromJsonAsync<List<Pedido>>($"/pedidos/cliente?dni={dni}");
            return pedidos;
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Crear(Pedido pedido)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PostAsJsonAsync("/pedidos", pedido);
            string contenido = await response.Content.ReadAsStringAsync();
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<bool> Actualizar(string id, Pedido pedido)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/pedidos/{id}", pedido);
            ensureFunctions.ensureGet(response);
            return response.IsSuccessStatusCode;
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Eliminar(string id)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().DeleteAsync($"/pedidos/{id}");
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task AgregarArticulos(List<PedidoArticulos> articulos)
    {
        try
        {
            await checkTokenExpiration();
            for (int i = 0; i < articulos.ToArray().Length; i++)
            {
                PedidoArticulos articulo = articulos[i];
                var response = await this.mySession.GetClient().PostAsJsonAsync("/pedidos/articulo", articulo);
                ensureFunctions.ensureGet(response);
            }
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<PedidoArticulos>> ObtenerArticulosDePedido(string idPedido)
    {
        try
        {
            await checkTokenExpiration();
            return await this.mySession.GetClient().GetFromJsonAsync<List<PedidoArticulos>>($"/pedidos/{idPedido}/articulos");
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<Pedido>> ObtenerPedidosPorNombreCliente(string nombre)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync($"/pedidos?Nombre={nombre}");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<Pedido>>() ?? new List<Pedido>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task checkTokenExpiration()
    {
        if (tokenHelper.checkRenovateToken(this.mySession.getToken().exp))
        {
            await mySession.GenerateToken();
        }
    }
}
