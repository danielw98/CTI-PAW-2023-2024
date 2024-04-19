using Lab05_Gr362.ContextModels;
using Lab05_Gr362.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab06.Pages;

public class AdaugaStireModel : PageModel
{
    [BindProperty]
    public Stire Stire { get; set; } = default!;
    public List<SelectListItem> Categorii { get; set; }
    private readonly StiriContext _stiriContext;
    public AdaugaStireModel(StiriContext stiriContext)
    {
        _stiriContext = stiriContext;
        Categorii = _stiriContext.Categorie
            .Select(categorie => new SelectListItem { Text = categorie.Nume, Value = categorie.Id.ToString() }).ToList();
    }
    public void OnGet()
    {
        Stire = new Stire();
    }
    public IActionResult OnPost()
    {
        _stiriContext.Stire.Add(Stire);
        _stiriContext.SaveChanges();
        return RedirectToPage("Index");
    }
}
