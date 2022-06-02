using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RazorZoo.Models 
{
    public class Cage{
        [Required]
        [RegularExpression(@"[0-9]+",ErrorMessage = "Only number")]

        public int CageID { get;set; }
        [Required]
        [RegularExpression(@"[A-Z]+", ErrorMessage ="Only character a-z")]
        public string? TypeAnimal {get;set;}
        [Required]
        [RegularExpression(@"[A-Z]+", ErrorMessage ="Only character a-z")]
        public string? Name { get;set; }
        public ICollection<Animal> Animals {get;set;}
    }
}