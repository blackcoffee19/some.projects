using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace RazorZoo.Pages.Zoo
{   

    public class IndexModel : PageModel
    {
        private readonly ZooContext _context;
        public IndexModel(ZooContext context){
            _context = context;
        }
        //property for Search bar
        [BindProperty(SupportsGet = true)]
        public string? SearchString {get;set;}
        
        //property for sort
        [BindProperty(SupportsGet = true)]
        public string? SortField {get;set;}

        //property for Select list
        [BindProperty(SupportsGet = true)]
        public string SelectAnimal {get;set;}
        public SelectList selectType {get;set;}
        public List<Animal>? Animals {get;set;}

        public async Task OnGetAsync()
        {
            var animals = from ani in _context.Animals
                select ani;
            //for SelectBox
            switch(SortField){
                case "ID":
                    animals = animals.OrderBy(c => c.ID);
                    break;
                case "Name":
                    animals = animals.OrderBy(x => x.Name);
                    break;
                case "Type":
                    animals = animals.OrderBy(x => x.TypeAnimal);
                    break;
            };
            //for Sreach bar
            if(!string.IsNullOrEmpty(SearchString)){
                animals = animals.Where(c => c.Name.Contains(SearchString));
            };
            //for Select box
            if(!string.IsNullOrEmpty(SelectAnimal)){
                animals = animals.Where(c => c.TypeAnimal == SelectAnimal);
            };
            IQueryable<string> animalQuery = from c in _context.Animals
                orderby c.TypeAnimal
                select c.TypeAnimal;
            selectType = new SelectList(await animalQuery.ToListAsync());
            //Truy xuất dữ liệu database và gán cho Animals
            Animals = await animals.ToListAsync();    
        }
        public async Task<IActionResult> OnPostAsync(int? id){
            if(id == null){
                return NotFound();
            };
            //Animal Animal = await _context.Animals.FirstOrDefaultAsync(m => m.ID == id);
            Animal Animal = await _context.Animals.FindAsync(id);
            /*other way call LINQ related to .FindAsync():
            */
            if(Animal != null){
                _context.Animals.Remove(Animal);
            };
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}