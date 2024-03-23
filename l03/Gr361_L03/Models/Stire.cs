namespace Gr361_L03.Models;

public class Stire
{
    public int Id { get; set; }
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public DateTime Data { get; set; }

    public Stire(int id, string titlu, string autor, DateTime data)
    {
        Id = id;
        Titlu = titlu;
        Autor = autor;
        Data = data;
    }
}
