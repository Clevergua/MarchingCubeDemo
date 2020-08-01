using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Terrain;
using UnityEngine;

namespace Terrain
{
    internal abstract class DataDrivenStructure : Structure
    {
        public DataDrivenStructure()
        {
            var fileName = $"{GetType().Name}.dat";
            var formatter = new BinaryFormatter();
            var path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
            var stream = File.OpenRead(path);
            data = formatter.Deserialize(stream) as byte[,,];
        }
    }
}
