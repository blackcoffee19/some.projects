using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;


namespace RazorZoo.Pages.AnimalsSick;

public class IndexModel : PageModel
{
    private readonly ZooContext _context;

    public IndexModel(ZooContext context)
    {
        _context = context;
    }
    public List<Cage> Cages {get;set;}
    
    public async Task OnGetAsync()
    {
        Cages = await _context.Cages.ToListAsync();
    }
    public async Task<IActionResult> OnPostAsync(string id){
        if (id == null){
            return NotFound();
        }

        Cage? Cage =  await _context.Cages.FindAsync(id);
        if(Cage != null){
            _context.Cages.Remove(Cage);
        }
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
