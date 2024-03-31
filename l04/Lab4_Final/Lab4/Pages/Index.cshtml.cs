using Lab4.ContextModels;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StiriContext _stiriContext;
        public Stire[] Stiri { get; set; }
        public IndexModel(ILogger<IndexModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public void OnGet()
        {
            Stiri = _stiriContext.Stire.Include(stire => stire.Categorie).ToArray();
        }
    }
}