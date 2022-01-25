using System.IO;
using UnityEngine;

namespace PetrovDA.Utils.Saver
{
    public abstract class StoredStructHandler<T> where T : new()
    {
        protected virtual string PathToFile { get; }
        public virtual T GetStructure() 
        {
            T structure;
            string path = Path.Combine(Application.dataPath, PathToFile);
            if (File.Exists(path))
            {
                Serializer.Path = path;
                structure = Serializer.Deserialize<T>();
            }
            else
            {
                structure = new T();
            }

            return CheckStructure(structure);
        }

        public void SaveStructure(T structure)
        {
            Serializer.Path = Path.Combine(Application.dataPath, PathToFile);
            Serializer.Serialize(structure);
        }

        protected abstract T CheckStructure(T structureToCheck);

    }
}
