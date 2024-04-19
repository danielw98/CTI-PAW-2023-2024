using Lab05_Gr362.ContextModels;
using Lab05_Gr362.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab06.Pages;

public class StergeStireModel : PageModel
{
    [BindProperty]
    public Stire Stire { get; set; } = default!;
    private readonly StiriContext _stiriContext;
    public StergeStireModel(StiriContext stiriContext)
    {
        _stiriContext = stiriContext;
    }
    public void OnGet(int stireId)
    {
        Stire = _stiriContext.Stire.FirstOrDefault(stire => stire.Id == stireId)!;
    }
    public IActionResult OnPost()
    {
        _stiriContext.Stire.Remove(Stire);
        _stiriContext.SaveChanges();
        return RedirectToPage("Index");
    }
}

