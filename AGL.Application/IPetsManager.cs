using AGL.Entities;
using System;
using System.Threading.Tasks;

namespace AGL.Application
{
    public interface IPetsManager : IDisposable
    {
        Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType);
    }
}
