using AGL.Entities;
using System.Threading.Tasks;

namespace AGL.Repository
{
    /// <summary>
    /// Interface IPetsRepository
    /// </summary>
    public interface IPetsRepository
    {
        Task<Person[]> GetPersonAndPets();
    }
}
