using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class for searching all files with input extension and printing them to Console.
    /// </summary>
    class FileSearcher
    {
        List<string> filesPaths = new List<string>();

        private string startPath;
        private string extension;

        public string StartPath
        {
            get
            {
                return startPath;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new FormatException("Start directory can't be empty.");
                }
                else
                {
                    startPath = value;
                }
            }
        }

        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                if (value == string.Empty)
                {
                    extension = "*";
                }
                else
                {
                    extension = "*." + value;
                }
            }
        }

        public FileSearcher(string startPath, string extension)
        {
            StartPath = startPath;
            Extension = extension;
        }

        /// <summary>
        /// Searches for files and adds paths to list
        /// </summary>
        public void SearchFiles()
        {
            try
            {
                filesPaths = Directory.GetFiles(StartPath, Extension, SearchOption.AllDirectories).ToList<string>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PrintFilesPaths()
        {
            if (filesPaths.Count == 0)
            {
                Console.WriteLine($"No such files in input directory.");
            }
            else
            {
                foreach (string file in filesPaths)
                {
                    Console.WriteLine(file);
                }
            }
        }
    }
}
