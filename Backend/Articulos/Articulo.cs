using System.ComponentModel.DataAnnotations;

namespace Articulos_Backend.Articulos
{
    public class Articulo
    {
        public int id {  get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public String nombre { get; set; }
        public decimal precio { get; set; }

        public String categoria { get; set; }

        public Articulo(int id, String nombre, decimal precio, String categoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }
    }
}
