namespace Articulos_Backend.Articulos
{
    public class Articulo
    {
        public int id {  get; set; }

        public String nombre { get; set; }

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
