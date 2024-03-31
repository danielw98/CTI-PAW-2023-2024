using Lab04.ContextModels;
using Lab04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StiriContext _stiriContext;
        public Stire[] Stiri { get; set; }
        public IndexModel(ILogger<IndexModel> logger, StiriContext context)
        {
            _logger = logger;
            _stiriContext = context;
            Stiri = Array.Empty<Stire>();
        }

        public void OnGet()
        {
            Stiri = _stiriContext.Stiri.Include(stire => stire.Categorie).ToArray();
        }
    }
}
