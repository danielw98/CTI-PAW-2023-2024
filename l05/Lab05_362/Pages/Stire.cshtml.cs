using Lab05_Gr362.ContextModels;
using Lab05_Gr362.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Gr362.Pages;

public class StireModel : PageModel
{
    private readonly ILogger<StireModel> _logger;
    private readonly StiriContext _stiriContext;
    public Stire? Stire { get; set; }
    public StireModel(ILogger<StireModel> logger, StiriContext stiriContext)
    {
        _logger = logger;
        _stiriContext = stiriContext;
    }
    public IActionResult OnGet(int stireId)
    {
        Stire = _stiriContext.Stire.Where(stire => stire.Id == stireId).Include(stire => stire.Categorie).FirstOrDefault();
        if(Stire == null)
        {
            return RedirectToPage("Error");
        }
        return Page();
    }
}
