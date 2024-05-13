namespace Laborator10.Models;

public class StireModel
{
    public int Id { get; set; }
    public string Titlu { get; set; }
    public string Lead { get; set; }
    public string Continut { get; set; }
    public string Autor { get; set; }
    public DateTime Data { get; set; }
    public int CategorieId { get; set; }
    public CategorieModel? Categorie { get; set; }
}