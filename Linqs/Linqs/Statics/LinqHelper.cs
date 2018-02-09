using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linqs.Statics
{
    public static class LinqHelper
    {

        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        public static void JoinEx1()
        {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };
            Person jin = new Person { Name = "jin" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };
            Pet daisy_test = new Pet { Name = "Daisysss", Owner = null };

            List<Person> people = new List<Person> { magnus, terry, charlotte, jin };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy, daisy_test };

            // Create a list of Person-Pet pairs where 
            // each element is an anonymous type that contains a
            // Pet's name and the name of the Person that owns the Pet.
            var query =
                people.Join(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, pet) =>
                                new { OwnerName = person.Name, Pet = pet.Name });

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.OwnerName,
                    obj.Pet);
            }
        }
    }
}
