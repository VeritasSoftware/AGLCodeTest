using AGL.Entities;
using System;
using System.Threading.Tasks;

namespace AGL.Application
{
    /// <summary>
    /// Interface IPetsManager
    /// </summary>
    public interface IPetsManager : IDisposable
    {
        Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType);
    }
}
