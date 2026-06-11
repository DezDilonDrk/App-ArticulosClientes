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
    UserSession mySession;
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
            var response = await this.mySession.GetClient().PostAsJsonAsync("/pedidos", pedido);
            string contenido = await response.Content.ReadAsStringAsync();
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<bool> Actualizar(string id, Pedido pedido)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/pedidos/{id}", pedido);
            ensureGet(response);
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
            var response = await this.mySession.GetClient().DeleteAsync($"/pedidos/{id}");
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task AgregarArticulos(List<PedidoArticulos> articulos)
    {
        try
        {
            for (int i = 0; i < articulos.ToArray().Length; i++)
            {
                PedidoArticulos articulo = articulos[i];
                var response = await this.mySession.GetClient().PostAsJsonAsync("/pedidos/articulo", articulo);
                ensureGet(response);
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
            var response = await this.mySession.GetClient().GetAsync($"/pedidos?Nombre={nombre}");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<Pedido>>() ?? new List<Pedido>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    private void ensureGet(HttpResponseMessage response, [CallerMemberName] string methodName = "")
    {
        if (!response.IsSuccessStatusCode)
        {
            Log.Error($"Error en {methodName}: {response.Content}");
            throw new Exception($"Error con {methodName}: {response.StatusCode}");
        }
    }
}
