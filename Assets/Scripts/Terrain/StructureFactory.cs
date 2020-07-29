using System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Terrain
{
    internal class StructureFactory
    {
        private Dictionary<Type, Structure> type2Structure = new Dictionary<Type, Structure>();
        public StructureFactory()
        {
            var folderPath = System.IO.Path.Combine(Application.streamingAssetsPath, "StructureData");
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Structure)) && !type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type);
                    var dataDrivenStructure = instance as DataDrivenStructure;
                    if (dataDrivenStructure != null)
                    {
                        var formatter = new BinaryFormatter();
                        var path = System.IO.Path.Combine(folderPath, $"{type.Name}.dat");
                        var stream = File.OpenRead(path);
                        var data = formatter.Deserialize(stream) as byte[,,];
                        dataDrivenStructure.InitilazeData(data);
                    }
                    type2Structure.Add(type, instance as Structure);
                }
            }
        }

        internal T GetStructure<T>() where T : Structure
        {
            return (T)type2Structure[typeof(T)];
        }
    }

}
