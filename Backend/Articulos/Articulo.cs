using System.ComponentModel.DataAnnotations;

namespace Articulos_Backend.Articulos
{
    public class Articulo
    {
        public int id {  get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public String nombre { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        public double precio { get; set; }

        public String categoria { get; set; }

        public Articulo(int id, String nombre, double precio, String categoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }
    }
}
