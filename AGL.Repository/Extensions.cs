using Newtonsoft.Json;

namespace AGL.Repository
{
    public static class Extensions
    {
        /// <summary>
        /// Deserialize Array
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="data">The data</param>
        /// <returns><see cref="T[]"/></returns>
        public static T[] DeserializeArray<T>(this string data)
            where T: class
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T[]>(data);            
        }
    }
}
