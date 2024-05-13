using Laborator10.ContextModels;
using Laborator10.Models;
using Laborator10.Models.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator10.Controllers;

[Route("api/stiri/")]
[ApiController]
public class StireAPIController : ControllerBase
{
    private readonly StiriContext _context;

    public StireAPIController(StiriContext context)
    {
        _context = context;
    }

    // GET - returneaza o stire dupa ID
    [HttpGet(Name = "{id}")]
    public IActionResult Get(int stireId)
    {
        StireModel? stireModel = _context.Stire.Where(stire => stire.Id == stireId).Include(stire => stire.Categorie).FirstOrDefault();

        if (stireModel == null)
        {
            return NotFound();
        }

        StireModelUI stireResponse = Program.AutoMapper.Map<StireModelUI>(stireModel);

        return Ok(stireResponse);
    }

    // GET /all - returneaza toate stirile
    [HttpGet("all")]
    public IActionResult Get()
    {
        List<StireModel> stiri = _context.Stire.Include(stire => stire.Categorie).ToList();

        List<StireModelUI> stiriResponse = new List<StireModelUI>();
        foreach (StireModel stire in stiri)
        {
            stiriResponse.Add(Program.AutoMapper.Map<StireModelUI>(stire));
        }

        return Ok(stiriResponse);
    }

    // DELETE - stergerea unei stiri
    [HttpDelete(Name = "{id}")]
    public IActionResult Delete(int stireId)
    {
        StireModel? stireModel = _context.Stire.Where(stire => stire.Id == stireId).FirstOrDefault();

        // stirea specificata nu exista
        if (stireModel == null)
        {
            return NotFound();
        }

        // actualizam baza de date
        _context.Stire.Remove(stireModel);
        _context.SaveChanges();
        return Ok();
    }

    // POST - crearea unei stiri
    [HttpPost()]
    public IActionResult Post(StireModelMutation data)
    {
        StireModel stireModel = Program.AutoMapper.Map<StireModel>(data);
        stireModel.Categorie = _context.Categorie.Where(categorie => categorie.Id == data.CategorieId).FirstOrDefault();

        // categoria data nu exista
        if (stireModel.Categorie == null)
        {
            return NotFound();
        }

        // actualizam baza de date
        _context.Stire.Add(stireModel);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut(Name = "{id}")]
    public IActionResult Put(int stireId, StireModelMutation data)
    {
        // cautam stirea specificata
        StireModel? stireModel = _context.Stire.FirstOrDefault(stire => stire.Id == stireId);

        // id inexistent
        if (stireModel == null)
        {
            return NotFound();
        }

        // actualizam modelul cu datele transmise
        Program.AutoMapper.Map(data, stireModel);

        // actualizam baza de date
        _context.Stire.Update(stireModel);
        _context.SaveChanges();

        return Ok();
    }

    // Variante async (la _context folosim varianta cu metodele care se termina in Async)
    /*[HttpGet(Name = "async/{id}")]
    public async Task<IActionResult> GetAsync(int stireId)
    {
        StireModel? stireModel = await _context.Stire.Where(stire => stire.Id == stireId).Include(stire => stire.Categorie).FirstOrDefaultAsync();

        if (stireModel == null)
        {
            return NotFound();
        }

        StireModelUI stireResponse = Program.AutoMapper.Map<StireModelUI>(stireModel);

        return Ok(stireResponse);
    }*/
}
