namespace study_together_api;

public class WeatherForecast
{
    private DateOnly dateOnly;
    private int v1;
    private string v2;

    public WeatherForecast(DateOnly dateOnly, int v1, string v2)
    {
        this.dateOnly = dateOnly;
        this.v1 = v1;
        this.v2 = v2;
    }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}