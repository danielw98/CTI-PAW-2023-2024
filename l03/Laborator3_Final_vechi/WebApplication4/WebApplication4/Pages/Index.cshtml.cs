using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Stire[] stiri = new Stire[]
        {
            new Stire("test1","test1","autorT1"),
            new Stire("test2","test2","autorT2"),
            new Stire("test3","test3","autorT3")
        };
        public void OnGet()
        {

        }
    }
    public class Stire
    {
        public string titlu { get; set; }
        public string lead { get; set; }
        public string autor { get; set; }
        public DateTime Date { get; set; }

        public Stire(string titlu, string lead, string autor)
        {
            this.titlu = titlu;
            this.lead = lead;
            this.autor = autor;
            Date = DateTime.Now;
        }
    }
}