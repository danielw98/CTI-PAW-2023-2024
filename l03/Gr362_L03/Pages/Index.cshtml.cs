using Gr362_L03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gr362_L03.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Random _random;
    private readonly int _numarStiri;
    public List<Stire> Stiri { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        Console.WriteLine("Constructor");
        _logger = logger;
        _random = new Random();
        Stiri = new List<Stire>();
        _numarStiri = 5;
    }

    public void OnGet()
    {
        Console.WriteLine("OnGet()");
        for(int id = 1; id <= _numarStiri; id++)
        {
            int day = _random.Next(1, 29);
            int month = _random.Next(1, 13);
            int year = _random.Next(2020, 2024);
            DateTime date = new DateTime(year, month, day); // Obs: DateOnly
            Stiri.Add(new Stire(id, $"titlu{id}", $"lead{id}", $"autor{id}", date));
        }
        //throw new Exception("Test");
    }
}
