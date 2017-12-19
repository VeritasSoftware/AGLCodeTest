using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;

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
        {
            //JavaScriptSerializer ser = new JavaScriptSerializer(typeof(T[]));

            return JsonConvert.DeserializeObject<T[]>(data);

            //MemoryStream stream = new MemoryStream();
            //StreamWriter writer = new StreamWriter(stream);
            //writer.Write(data);
            //writer.Flush();
            //stream.Position = 0;

            //return (T[])ser.ReadObject(stream);
        }
    }
}
