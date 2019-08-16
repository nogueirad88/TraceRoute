using Routing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Routing.Repository
{
    public class FileRepository: IFileRepository
    {
        public readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<string> ReadCsv()
        {
            var lines = new List<string>();

            var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using (var sr = new StreamReader(fs))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
