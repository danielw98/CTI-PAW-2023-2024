using Laborator03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laborator03.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Random _random;
    private int current;
    private int numItems;
    private readonly List<Stire> _stiri;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _random = new Random();
        _stiri = new List<Stire>();
        current = 1;
        numItems = 5;
        Console.WriteLine("Constructor Apelat");
    }
    public void OnGet()
    {
        for (int i = current; i < current + numItems; i++)
        {
            int year = _random.Next(2020, 2025);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, 29);
            _stiri.Add(new Stire(i, $"Titlu{i}", $"Autor{i}", new DateTime(year, month, day)));
        }
    }

    public List<Stire> GetStiri() { return _stiri; }
}


