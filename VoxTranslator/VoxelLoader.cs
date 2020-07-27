using CsharpVoxReader;
using CsharpVoxReader.Chunks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VoxTranslator
{
    class VoxelLoader : IVoxLoader
    {
        private string rootPath;
        private string fileName;

        public VoxelLoader(string rootPath, string fileName)
        {
            this.fileName = fileName;
            this.rootPath = rootPath;
        }

        public void LoadModel(int sizeX, int sizeY, int sizeZ, byte[,,] data)
        {
            Console.WriteLine($"({sizeX},{sizeY},{sizeZ})");
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    for (int z = 0; z < data.GetLength(2); z++)
                    {
                        Console.Write($"{data[x, y, z]},");
                    }
                }
            }
            var path = Path.Combine(rootPath, $"{Path.GetFileNameWithoutExtension(fileName)}.dat");

            // Delete old file, if it exists
            if (File.Exists(path))
            {
                Console.WriteLine($"Deleting old file:{path}");
                File.Delete(path);
            }

            FileStream stream = File.Create(path);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public void LoadPalette(uint[] palette)
        {
        }

        public void NewGroupNode(int id, Dictionary<string, byte[]> attributes, int[] childrenIds)
        {
        }

        public void NewLayer(int id, Dictionary<string, byte[]> attributes)
        {
        }

        public void NewMaterial(int id, Dictionary<string, byte[]> attributes)
        {
        }

        public void NewShapeNode(int id, Dictionary<string, byte[]> attributes, int[] modelIds, Dictionary<string, byte[]>[] modelsAttributes)
        {
        }

        public void NewTransformNode(int id, int childNodeId, int layerId, Dictionary<string, byte[]>[] framesAttributes)
        {
        }

        public void SetMaterialOld(int paletteId, MaterialOld.MaterialTypes type, float weight, MaterialOld.PropertyBits property, float normalized)
        {
        }

        public void SetModelCount(int count)
        {
        }
    }
}
