using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PetrovDA.Utils.Saver
{
    public static class Serializer
    {
        private static string path;
        public static string Path { get => path; set => path = value; }

        public static void Serialize(object data)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>()
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var data = formatter.Deserialize(stream);
                return (T) data;
            }
        }
    }
}
