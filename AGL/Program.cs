using AGL.Application;
using AGL.Entities;
using AGL.Repository;
using Autofac;
using System;
using System.Linq;

namespace AGL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var containerBuilder = new ContainerBuilder();

                containerBuilder.RegisterType<PetsRepository>().As<IPetsRepository>().WithProperty("Url", Properties.Settings.Default.ServiceUrl);
                containerBuilder.RegisterType<PetsManager>().As<IPetsManager>();

                var container = containerBuilder.Build();                

                using (IPetsManager petsManager = container.Resolve<IPetsManager>())
                {                    
                    //get cats by person gender
                    var catsByPersonGenderCollection = petsManager.GetPetsByPersonGender(PetType.Cat);

                    DisplayCatsByPersonGender(catsByPersonGenderCollection.Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured! " + ex.Message);
            }

            //Console.WriteLine("Please wait for results...");
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Display Cats by Person's gender
        /// </summary>
        /// <param name="petsByPersonGenderCollection">Cats by Owners gender list</param>
        static void DisplayCatsByPersonGender(PetsByPersonGenderCollection petsByPersonGenderCollection)
        {
            var catsByOwnerGender = petsByPersonGenderCollection.PetsByPersonGender;

            //Write output
            Console.WriteLine(catsByOwnerGender.ElementAt(0).Gender);

            catsByOwnerGender.ElementAt(0).Pets.Select(pet => pet.name).OrderBy(name => name).ToList().ForEach(catName =>
            {
                Console.WriteLine("\t" + catName);
            });

            Console.WriteLine(catsByOwnerGender.ElementAt(1).Gender);

            catsByOwnerGender.ElementAt(1).Pets.Select(pet => pet.name).OrderBy(name => name).ToList().ForEach(catName =>
            {
                Console.WriteLine("\t" + catName);
            });
        }
    }
}
