using System.Collections.Generic;

namespace AGL.Entities
{
    /// <summary>
    /// Class Person
    /// </summary>
    public class Person
    {
        public string name { get; set; }
        public Gender gender { get; set; }
        public int age { get; set; }
        public ICollection<Pet> pets { get; set; }
    }
}
