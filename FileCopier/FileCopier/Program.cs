using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string sourceFolder = @"D:\Test\Areas";
            string destFolder = @"D:\Test\DestAreas";
            string csvFile = @"D:\Test\a.txt";
            Console.WriteLine("Parameters: source Folder, Dest Folder , Csv File Path");
            if (args.Length > 0)
            {
                sourceFolder = args[0];
                destFolder = args[1];
                csvFile = args[2];
            }

            var files = File.ReadAllLines(csvFile);
            foreach (var file in files)
            {
                var sourceFiles = Directory.GetFiles(sourceFolder, file, SearchOption.AllDirectories);
                if (sourceFiles.Length < 1)
                {
                    Console.WriteLine(string.Format("Could not find {0}.",file));
                }
                else
                {
                    foreach (var sourceFile in sourceFiles)
                    {
                        string s = sourceFile.Replace(sourceFolder, "");
                        var destFile = destFolder + s;
                        Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                        File.Copy(sourceFile, destFile,true);
                        count++;
                    }
                }
            }
            Console.WriteLine(string.Format("Copied {0} files",count));
            Console.ReadLine();

        }
    }
}
