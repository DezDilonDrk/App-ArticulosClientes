using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades;

public class ArticuloUsuario
{
    public int ArticuloId { get; set; }
    public string UsuarioEmail { get; set; }

    public ArticuloUsuario() { }

    public ArticuloUsuario(int articuloId, string usuarioEmail)
    {
        this.ArticuloId = articuloId;
        this.UsuarioEmail = usuarioEmail;
    }
}
