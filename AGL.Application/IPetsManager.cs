using AGL.Entities;
using System;
using System.Threading.Tasks;

namespace AGL.Application
{
    public interface IPetsManager : IDisposable
    {
        string Url { get; set; }

        Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType);
    }
}
