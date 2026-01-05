namespace ApiVersioning.Sample.Models;

public class BlogV3
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
}