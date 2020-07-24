using CsharpVoxReader;
using CsharpVoxReader.Chunks;
using System;
using System.Collections.Generic;

namespace VoxTranslator
{
    class VoxelLoader : IVoxLoader
    {
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
