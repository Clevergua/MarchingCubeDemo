using CsharpVoxReader;
using System;
using System.IO;

namespace VoxTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootPath = Directory.GetCurrentDirectory();
            Console.WriteLine(rootPath);

            DirectoryInfo dirInfo = new DirectoryInfo(rootPath);

            foreach (var file in dirInfo.GetFiles("*.vox"))
            {
                Console.WriteLine(file.FullName);
                var loader = new VoxelLoader(rootPath, file.FullName);
                VoxReader reader = new VoxReader(file.FullName, loader);
                reader.Read();
            }

            Console.ReadLine();
        }
    }
}
