namespace Articulos_Backend;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public String? Summary { get; set; }

    public WeatherForecast(DateOnly fecha, int temperatura, String resumen)
    {
        this.Date = fecha;
        this.TemperatureC = temperatura;
        this.Summary = resumen;
    }
}
