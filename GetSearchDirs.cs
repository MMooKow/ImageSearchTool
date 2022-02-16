
using System.Text;

namespace ImageSearchTool
{
    internal class GetSearchDirs
    {
        /// <summary>
        /// This method uses parameters from CollectParams.cs to search a directory for PDF and JPG files and outputs those as a CSV file
        /// containing the path to the file, actual file type, and MD5 hash of the contents.
        /// This method takes three parameters
        /// 1. Directory to search
        /// 2. Output directory
        /// 3. True or false (defualt) flag of whether or not to seach subdirectories.
        /// </summary>
        /// <param name="directoryToSearch">Directory to search for PDF and JPG files.</param>
        /// <param name="outputDirectory">Output directory for CSV file containing results.</param>
        /// <param name="subSearchFlag">Flag (true/false(default)) to search subdirectories or not.</param>
        internal static List<string[]> GetDirectories(string directoryToSearch, string outputDirectory, bool subSearchFlag)
        {
            List<String[]> allOutputArr = new List<String[]>();
            if (subSearchFlag)
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(directoryToSearch));
                dirs.Insert(0, directoryToSearch);
                foreach (string dir in dirs)
                {
                    string directory = Path.GetFullPath(dir);
                    var files = GetSearchFiles.GetFiles(dir);

                    var validatedFiles = GetSearchFiles.FileToHex(files);

                    foreach (string val in validatedFiles)
                    {
                        string hash = Md5Hash.CreateMD5(val);
                        Console.WriteLine($"{directory}  |  {val}  |  {hash}");
                        string[] outPutArr = { $"{directory}", $"{val}", $"{hash}" };
                        allOutputArr.Add(outPutArr);

                    }

                }
                return allOutputArr;
            }
            else
            {
                var files = GetSearchFiles.GetFiles(directoryToSearch);
                foreach (string file in files)
                {
                    string directory = Path.GetFullPath(directoryToSearch);
                    
                    var validatedFiles = GetSearchFiles.FileToHex(files);

                    foreach (string val in validatedFiles)
                    {
                        string hash = Md5Hash.CreateMD5(file);
                        Console.WriteLine($"{directory}  |  {val}  |  {hash}");
                        string[] outPutArr = { $"{directory}", $"{val}", $"{hash}" };
                        allOutputArr.Add(outPutArr);
                    }
                }
                return allOutputArr;

            }

        }
    }
}
