namespace Articulos_Backend
{
    public class Articulo
    {
        public int id {  get; set; }

        public String nombre { get; set; }

        public double precio { get; set; }

        public String categoria { get; set; }

        public Articulo(String nombre, double precio, String categoria)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }
    }
}
