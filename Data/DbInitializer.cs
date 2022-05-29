using RazorZoo.Models;
using System.Linq;
using System;

namespace RazorZoo.Data
{
    public static class DbInitializer 
    {
        public static void Initialize (ZooContext context)
        {
            context.Database.EnsureCreated();
            if(context.Cages.Any()){
                return;
            }

            var Cages = new Cage[]
            {
                new Cage{ID=1,TypeAnimal="Tiger",Name="Yang"},
                new Cage{ID=2,TypeAnimal="Wolf",Name="DiDi"},
                new Cage{ID=3,TypeAnimal="Monkey",Name="Lith"},
                new Cage{ID=4,TypeAnimal="Panda",Name="LeeMei"},
                new Cage{ID=5,TypeAnimal="Lion",Name="Siba"},
                new Cage{ID=6,TypeAnimal="Crocodie",Name="Draco"},
                new Cage{ID=7,TypeAnimal="Elephant",Name="Mamba"},
                new Cage{ID=8,TypeAnimal="Leopard",Name="Berme"}
            };
            foreach ( Cage s in Cages)
            {
                context.Cages.Add(s);
            };
            context.SaveChanges();

            var Animals = new Animal[]
            {
                new Animal{ID=10100,TypeAnimal="Tiger",Name="Yang",Age=4,Gender="female"},
                new Animal{ID=10101,TypeAnimal="Tiger",Name="Ming",Age=3,Gender="male"},
                new Animal{ID=10110,TypeAnimal="Wolf",Name="DiDi",Age=2,Gender="female"},
                new Animal{ID=10111,TypeAnimal="Wolf",Name="Mei",Age=2,Gender="female"},
                new Animal{ID=10200,TypeAnimal="Monkey",Name="Lith",Age=5,Gender="male"},
                new Animal{ID=10230,TypeAnimal="Panda",Name="LeeMei",Age=5,Gender="female"},
                new Animal{ID=12500,TypeAnimal="Lion",Name="Siba",Age=4,Gender="male"},
                new Animal{ID=12501,TypeAnimal="Lion",Name="Lisa",Age=3,Gender="female"},
                new Animal{ID=12502,TypeAnimal="Lion",Name="Lily",Age=3,Gender="female"},
                new Animal{ID=12503,TypeAnimal="Lion",Name="Drake",Age=4,Gender="male"},
                new Animal{ID=20021,TypeAnimal="Crocodie",Name="Draco",Age=7,Gender="female"},
                new Animal{ID=20022,TypeAnimal="Crocodie",Name="Mema",Age=4,Gender="male"},
                new Animal{ID=20023,TypeAnimal="Crocodie",Name="Sino",Age=4,Gender="female"},
                new Animal{ID=20024,TypeAnimal="Crocodie",Name="Hia",Age=5,Gender="male"},
                new Animal{ID=20203,TypeAnimal="Elephant",Name="Mamba",Age=5,Gender="female"},
                new Animal{ID=20204,TypeAnimal="Elephant",Name="Boma",Age=6,Gender="male"},
                new Animal{ID=20205,TypeAnimal="Elephant",Name="Sim",Age=1,Gender="female"},
                new Animal{ID=10220,TypeAnimal="Leopard",Name="Leo",Age=4,Gender="male"},
                new Animal{ID=10221,TypeAnimal="Leopard",Name="Baloon",Age=2,Gender="female"},
                new Animal{ID=10222,TypeAnimal="Leopard",Name="Sia",Age=2,Gender="female"},
            };
            foreach(Animal x in Animals){
                context.Animals.Add(x);
            };
            context.SaveChanges();
            
        }
    }
}
