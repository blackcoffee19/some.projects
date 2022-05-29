using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RazorZoo.Pages.Zoo
{   
    public class IndexModel : PageModel
    {
        private readonly ZooContext _context;
        public IndexModel(ZooContext context){
            _context = context;
        }
        public List<Animal> Animals {get;set;}
        public async Task OnGetAsync()
        {
            //Truy xuất dữ liệu database và gán cho Animals
            Animals = await _context.Animals.ToListAsync();    
        }
        public async Task<IActionResult> OnPostAsync(int id){
            if(id == null){
                return NotFound();
            };
            Animal Animal = await _context.Animals.FindAsync(id);
            /*other way call LINQ related to .FindAsync():
                Animal = await _context.Animals.FirstOrDefaultAsync(m => m.ID == id);
            */
            if(Animal != null){
                _context.Animals.Remove(Animal);
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}