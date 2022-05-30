using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace RazorZoo.Pages.Zoo
{
    public class EditModel:PageModel 
    {
        private readonly ZooContext _context;
        public EditModel(ZooContext context){
            _context = context;
        }
        [BindProperty]
        public Animal? Animal1 {get;set;}
        //Select List
        public SelectList SelectAnimals {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null){
                Animal1 = new Animal();
            } else {
                Animal1 = await _context.Animals.FindAsync(id);
                SelectAnimals = new SelectList(_context.Animals, nameof(Animal.TypeAnimal));
                if(Animal1 == null){
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
                _context.Animals.Add(Animal1).State = EntityState.Modified;
            } else {
                _context.Attach(Animal1).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}