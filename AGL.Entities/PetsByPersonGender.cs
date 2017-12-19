using System.Collections.Generic;

namespace AGL.Entities
{
    /// <summary>
    /// Class Pets By Person Gender
    /// </summary>
    public class PetsByPersonGender
    {
        public Gender Gender { get; set; }

        public IEnumerable<Pet> Pets { get; set; }
    }
}
