using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;
using RazorZoo.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            /*var animals = from ani in _context.Animals
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
            //For Select box
            if(!string.IsNullOrEmpty(SelectCage)){
                animals = animals.Where(c => c.TypeAnimal == SelectCage);
            };
            IQueryable<string> cageQuery = from c in _context.Cages
                orderby c.TypeAnimal
                select c.TypeAnimal;
            Cages = new SelectList(await cageQuery.ToListAsync());
            //Truy xuất dữ liệu database và gán cho Animals*/
            Animals = await _context.Animals.ToListAsync();    
        }
        public async Task<IActionResult> OnPostAsync(int? id){
            if(id == null){
                return NotFound();
            };
            //Animal Animal = await _context.Animals.FirstOrDefaultAsync(m => m.ID == id);
            Animal? Animal = await _context.Animals.FindAsync(id);
            /*other way call LINQ related to .FindAsync():
            */
            if(Animal != null){
                _context.Animals.Remove(Animal);
            };
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
        [BindProperty(SupportsGet = true)]
        public string SearchString {get;set;}
        [BindProperty(SupportsGet = true)]
        public string SortField {get; set;} = "Name";
        public SelectList Cages {get;set;}
        [BindProperty(SupportsGet = true)]
        public string SelectCage {get;set;}
    }
}