using System;
using System.Collections.Generic;

namespace RazorZoo.Models 
{
    public class Cage{
        public int ID { get;set; }
        public string? TypeAnimal {get;set;}
        public string? Name { get;set; }
        public ICollection<Animal> Animals {get;set;}
    }
}