using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;
using System.Collections.Generic;


namespace RazorZoo.Pages.Zoo
{
    public class DetailModel : PageModel
    {
        private readonly ZooContext _context;
        public DetailModel(ZooContext context){
            _context = context;
        }
        [BindProperty]
        public Animal Animal{get;set;}
        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null){
                return NotFound();
            } else{
                Animal = await _context.Animals.FindAsync(id);
                if( Animal == null){
                    return NotFound();
                }
            };
            return Page();

        }
        public async Task<IActionResult> OnPost(){
            return RedirectToPage("./Index");
        }
    }
}