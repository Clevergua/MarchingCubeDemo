using CsharpVoxReader;
using System;
using System.IO;

namespace VoxTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Directory.GetCurrentDirectory();
            Console.WriteLine(rootPath);

            DirectoryInfo dirInfo = new DirectoryInfo(rootPath);
            var loader = new VoxelLoader();

            foreach (var file in dirInfo.GetFiles("*.vox"))
            {
                Console.WriteLine(file.FullName);
                VoxReader reader = new VoxReader(file.FullName, loader);
                reader.Read();
            }

            Console.ReadLine();
           
        }
    }
}
