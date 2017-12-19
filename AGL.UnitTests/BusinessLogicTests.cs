using AGL.Application;
using AGL.Entities;
using AGL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace AGL.UnitTests
{
    /// <summary>
    /// Test business logic. Using NSubstitute for mocking the repository.
    /// </summary>
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void Test_GetPetsByPersonGender()
        {            
            var personAndPets = new Person[] 
            {
                new Person
                {
                    name = "Bob",
                    gender = Gender.Male,
                    age = 23,
                    pets = new List<Pet>
                    {
                        new Pet
                        {
                            name = "Garfield",
                            type = PetType.Cat
                        },
                        new Pet
                        {
                            name = "Fido",
                            type = PetType.Dog
                        }
                    }
                },
                new Person
                {
                    name = "Jennifer",
                    gender = Gender.Female,
                    age = 18,
                    pets = new List<Pet>
                    {
                        new Pet
                        {
                            name = "Garfield",
                            type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    name = "Steve",
                    gender = Gender.Male,
                    age = 45,
                    pets = null
                },
                new Person
                {
                    name = "Fred",
                    gender = Gender.Male,
                    age = 40,
                    pets = new List<Pet>
                    {
                        new Pet
                        {
                            name = "Tom",
                            type = PetType.Cat
                        },
                        new Pet
                        {
                            name = "Max",
                            type = PetType.Cat
                        },
                        new Pet
                        {
                            name = "Sam",
                            type = PetType.Dog
                        },
                        new Pet
                        {
                            name = "Jim",
                            type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    name = "Samantha",
                    gender = Gender.Female,
                    age = 40,
                    pets = new List<Pet>
                    {
                        new Pet
                        {
                            name = "Tabby",
                            type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    name = "Alice",
                    gender = Gender.Female,
                    age = 64,
                    pets = new List<Pet>
                    {
                        new Pet
                        {
                            name = "Simba",
                            type = PetType.Cat
                        },
                        new Pet
                        {
                            name = "Nemo",
                            type = PetType.Fish
                        }
                    }
                },
            };

            //Use NSubstitue to mock the repository layer
            var petsRepository = Substitute.For<IPetsRepository>();
            petsRepository.GetPersonAndPets().Returns(personAndPets);

            //Create PetsManager instance
            IPetsManager petsManager = new PetsManager(petsRepository);

            //Call method to be tested. This method contains the business logic.
            var catsByPersonGender = petsManager.GetPetsByPersonGender(PetType.Cat).Result;            

            //Check that there are 2 genders in the collection
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Count == 2);

            //Check Cats belonging to Male persons
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Gender == Gender.Male);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Pets.Count() == 4);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.name == "Garfield") == 1);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.name == "Tom") == 1);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.name == "Max") == 1);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.First().Pets.Count(p => p.name == "Jim") == 1);

            //Check Cats belonging to Female persons
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Last().Gender == Gender.Female);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Last().Pets.Count() == 3);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.name == "Garfield") == 1);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.name == "Simba") == 1);
            Assert.IsTrue(catsByPersonGender.PetsByPersonGender.Last().Pets.Count(p => p.name == "Tabby") == 1);
        }
    }
}
