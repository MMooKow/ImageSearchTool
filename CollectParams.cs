using System.Text.RegularExpressions;

namespace ImageSearchTool
{
    internal class CollectParams
    {
        /// <summary>
        /// This method collects and validates user input that will be passed on to SearchPfdOrJpg() method as parameters.
        /// </summary>
        internal static void CollectParameters()
        {
            string directoryToSearch = "";
            string outputDirectory = "";
            bool subSearchFlag = false;
            
            //Get input for first parameter. Value is the directory to be read from.
            bool inputFlag = false;
            while (!inputFlag)
            {
                Console.WriteLine("Enter a file path to search through: ");
                Console.WriteLine("Ex: C:\\MyFiles \n");
                directoryToSearch = Console.ReadLine();
                bool validatePath = Path.IsPathFullyQualified(directoryToSearch);
                if (validatePath)
                {
                    Console.WriteLine(directoryToSearch);
                    inputFlag = true;
                }
                else
                {
                    Console.WriteLine("Invalid path entered");
                    Console.WriteLine(directoryToSearch);
                }
            }

            // Get input for second paramerter. Value is the output directory for your CSV file.
            bool outputFlag = false;
            while (!outputFlag)
            {
                Console.WriteLine("Enter a file path to output CSV result to including file name and extension: ");
                Console.WriteLine("Ex: C:\\MyFiles\\MoreFiles\\output.csv \n");
                outputDirectory = Console.ReadLine();
                bool validatePathQual = Path.IsPathFullyQualified(outputDirectory);
                Regex reExt = new Regex("^.*.(csv)$", RegexOptions.IgnoreCase);
                bool validatePathExt = reExt.IsMatch(outputDirectory);
                if (validatePathQual && validatePathExt)
                {
                    Console.WriteLine(outputDirectory + " Success");
                    Console.WriteLine();
                    outputFlag = true;
                }
                else
                {
                    Console.WriteLine("Invalid path entered. Make sure file extension is .csv");
                    Console.WriteLine(outputDirectory);
                    Console.WriteLine();
                }
            }

            //Get input for third parameter. Value is either true or false to search subdirectories.
            wrongInput:
            Console.WriteLine("Would you like to search subDirectories? (y/n)");
            switch (Console.ReadLine())
            {
                case "y":
                    subSearchFlag = true;
                    Console.WriteLine("Subsearch activated");
                    break;
                case "n":
                    Console.WriteLine("Subsearch not activated");
                    break;
                default:
                    Console.WriteLine("Enter 'y' or 'n'");
                    goto wrongInput;
            }

            // Search through directories and validate files as JPG or PDF
            List<string[]> returnedFiles = GetSearchDirs.GetDirectories(directoryToSearch, outputDirectory, subSearchFlag);

            // Write to file
            WriteOutputFile.WriteOutFile(returnedFiles, outputDirectory);
            
           

        }
    }
}
