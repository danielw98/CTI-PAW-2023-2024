using Laborator10.ContextModels;
using Laborator10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator10.Controllers;

public class SearchController : Controller
{
    private readonly StiriContext _context;

    public SearchController(StiriContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult SearchPortal()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SearchPortal(string? titluStire, DateTime? dataInf, DateTime? dataSup)
    {
        IQueryable<StireModel> stiri = _context.Stire;
        
        if (titluStire != null) {
            stiri = stiri.Where(stire => stire.Titlu.ToLower().Contains(titluStire.ToLower()));
        }
        if (dataInf != null) {
            stiri = stiri.Where(stire => stire.Data >= dataInf);
        }
        if (dataSup != null) {
            stiri = stiri.Where(stire => stire.Data <= dataSup);
        }

        ViewBag.TitluStire = titluStire;
        ViewBag.DataInf = dataInf;
        ViewBag.DataSup = dataSup;
        return View(stiri.ToList());
    }
}
