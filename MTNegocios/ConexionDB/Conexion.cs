namespace MTNegocios.ConexionDB
{
    public class Conexion
    {
        public string conexionString;
        public Conexion()
        {
            this.conexionString = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;"; 
        }
    }
}
