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
            var animal = from a in _context.Animals
                where a.ID == id
                select new Animal {
                    ID = a.ID,
                    TypeAnimal = a.TypeAnimal,
                    Name = a.Name,
                    Age = a.Age,
                    Gender = a.Gender
                };
            Animal = await animal.SingleOrDefaultAsync();
            if(Animal ==null){
                return NotFound();
            };
            return Page();

        }
        public async Task<IActionResult> OnPost(){
            return RedirectToPage("./Index");
        }
    }
}