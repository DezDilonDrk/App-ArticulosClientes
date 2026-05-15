namespace MTNegocios.ConexionDB
{
    public class Conexion
    {
        public string conexionString;
        public Conexion()
        {
            this.conexionString = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
