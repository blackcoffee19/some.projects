using System;
using System.ComponentModel.DataAnnotations;
namespace RazorZoo.Models
{
    public class Animal{
        [Required]
        //[RegularExpression(@"[0-9]+",ErrorMessage = "Only number")]
        //[Display(Name="Code")]
        public int ID {get;set;}
        [Required]
        //[RegularExpression(@"[A-Z]+", ErrorMessage ="Only character a-z")]
        public string TypeAnimal {get;set;}
        [Required]
        //[RegularExpression(@"[A-Z]+", ErrorMessage ="Only character a-z")]
        public string Name {get;set;}
        //[RegularExpression(@"[0-9]+",ErrorMessage = "Only number")]
        public int Age {get;set;}
        public string Gender {get;set;}
        public Cage Cage {get;set;}
    }
}