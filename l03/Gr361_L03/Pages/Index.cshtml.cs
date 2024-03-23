using Gr361_L03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gr361_L03.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Random _random;
    private readonly List<Stire> _stiri;
    private int nrStiri;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _random = new Random();
        _stiri = new List<Stire>();
        nrStiri = 5;
        Console.WriteLine("Apelam constructorul");
    }

    public void OnGet()
    {
        Console.WriteLine("Apelam OnGet()");
        for (int i = 1; i <= nrStiri; i++)
        {
            int year = _random.Next(2020, 2024);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, 28);
            DateTime data = new DateTime(year, month, day);
            _stiri.Add(new Stire(i, $"Titlu{i}", $"Autor{i}", data));
        }
    }

    public List<Stire> GetStiri() { return _stiri; }
}
