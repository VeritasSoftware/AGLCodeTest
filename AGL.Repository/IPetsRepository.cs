using AGL.Entities;
using System.Threading.Tasks;

namespace AGL.Repository
{
    public interface IPetsRepository
    {
        Task<Person[]> GetPersonAndPets();
    }
}
