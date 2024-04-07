using Lab05_Gr362.ContextModels;
using Lab05_Gr362.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Gr362.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly StiriContext _stiriContext;
    public Stire[] Stire { get; set; }
    public IndexModel(ILogger<IndexModel> logger, StiriContext stiriContext)
    {
        _logger = logger;
        _stiriContext = stiriContext;
        Stire = Array.Empty<Stire>();
    }

    public void OnGet()
    {
        Stire = _stiriContext.Stire.Include(stire => stire.Categorie).ToArray();
    }
}
