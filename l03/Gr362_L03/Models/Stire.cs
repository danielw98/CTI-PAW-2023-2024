namespace Gr362_L03.Models;

public class Stire
{
    public int Id { get; set; }
    public string Titlu { get; set; }
    public string Lead { get; set; }
    public string Autor { get; set; }
    public DateTime DataAdaugare { get; set; }

    public Stire(int id, string titlu, string lead, string autor, DateTime dataAdaugare)
    {
        Id = id;
        Titlu = titlu;
        Lead = lead;
        Autor = autor;
        DataAdaugare = dataAdaugare;
    }
}
