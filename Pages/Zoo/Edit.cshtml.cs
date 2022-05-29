using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;

namespace RazorZoo.Pages.Zoo
{
    public class EditModel:PageModel 
    {
        private readonly ZooContext _context;
        public EditModel(ZooContext context){
            _context = context;
        }
        [BindProperty]
        public Animal Animal {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null){
                Animal = new Animal();
            } else {
                Animal = await _context.Animals.FindAsync(id);
                if(Animal == null){
                    return NotFound();
                };
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id){
            if(ModelState.IsValid){
                return Page();
            };
            if(id == null){
                _context.Animals.Add(Animal).State = EntityState.Modified;
            } else {
                _context.Attach(Animal).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}