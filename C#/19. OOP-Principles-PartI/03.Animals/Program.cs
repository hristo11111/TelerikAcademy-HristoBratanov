using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Kitten kitten = new Kitten();
        kitten.Sound();
        Dog dog = new Dog();
        dog.Sound();
        dog.Age = 15;
        Console.WriteLine(dog.Age);
        kitten.Name = "pesho";
        Console.WriteLine(kitten.Name);

        Console.WriteLine(kitten.Sex);

        kitten.Sound();

        Tomcat tomcat = new Tomcat();
        tomcat.Sound();

        Animal[] animals = {
                               new Dog("Krisko", 44, Sex.male),
                               new Dog("Dido", 14, Sex.male),
                               new Dog("Mila", 15, Sex.female),
                               new Frog("Jaburana", 31, Sex.female)
                           };
        Tomcat[] tomcats = {
                               new Tomcat("Pesho", 24),
                               new Tomcat("Gogo", 14)
                           };
        Kitten[] kittens = {
                               new Kitten("Lisa", 25),
                               new Kitten("Gabi", 5),
                               new Kitten("Djudju", 12)
                           };
        List<Dog> dogs = new List<Dog>() {
                         new Dog("Krisko", 44, Sex.male),
                         new Dog("Dido", 14, Sex.male),
                         new Dog("Mila", 15, Sex.female),
                     };
        Frog[] frogs = {
                           new Frog("Jaburana", 31, Sex.female),
                           new Frog("Kwachka", 12, Sex.female),
                       };
        

        Console.WriteLine(frogs.AverageAge());
        Console.WriteLine(dogs.AverageAge());

        //foreach (var item in animals)
        //{
        //    Console.WriteLine(item);
        //}
    }
}
