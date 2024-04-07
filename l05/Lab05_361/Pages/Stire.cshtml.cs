using Lab05_Gr361.ContextModels;
using Lab05_Gr361.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Gr361.Pages;

public class StireModel : PageModel
{
    private readonly ILogger<PageModel> _logger;
    private readonly StiriContext _stiriContext;
    public Stire? Stire { get; set; }
    public StireModel(ILogger<PageModel> logger, StiriContext stiriContext)
    {
        _logger = logger;
        _stiriContext = stiriContext;
        Stire = new Stire();
    }
    public IActionResult OnGet(int stireId)
    {
        Stire = _stiriContext.Stire.Where(stire => stire.Id == stireId).Include(stire => stire.Categorie).FirstOrDefault();
        if (Stire == null)
            return RedirectToPage("Error");
        return Page();
    }
}
