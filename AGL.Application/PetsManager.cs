using AGL.Entities;
using AGL.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Application
{
    /// <summary>
    /// Class PetsManager
    /// </summary>
    public class PetsManager : IPetsManager
    {
        private readonly IPetsRepository _petsRepository;        

        public PetsManager(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository ?? throw new ArgumentNullException(nameof(petsRepository));
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Get Pets by Person's gender
        /// </summary>
        /// <param name="petType">The Pet type</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns><see cref="Task{PetsByPersonGenderCollection}"/></returns>
        public async Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType)
        {
            var persons = await _petsRepository.GetPersonAndPets();

            if (persons == null)
            {
                return null;
            }

            //LINQ Query to get Pets by Person's gender and Pet type
            return new PetsByPersonGenderCollection()
            {
                PetsByPersonGender = persons.ToList()
                                            .Where(person => person.pets != null)
                                            .GroupBy(person => person.gender)
                                            .Select(g => new PetsByPersonGender
                                            {
                                                Gender = g.Key,
                                                Pets = g.SelectMany(person => person.pets.Where(pet => pet.type == petType))
                                            }).ToList()
            };
        }
    }
}
