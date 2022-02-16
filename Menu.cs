
namespace ImageSearchTool
{
    /// <summary>
    /// This class is responsible for keeping the console app running and providing options to users.
    /// Options should include:
    /// 1. Seach a directroy for PDF or JPG files.
    /// 2. Exit program
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// This method begins the main menu and offers two options. 1: Search directory for PDF and JPG files and 2: Exit program
        /// </summary>
        internal static void MenuFunc()
        {
            bool endFlag = false;
            while (!endFlag)
            {
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("[1] Search a directory for PDF and JPG files.");
                Console.WriteLine("[2] Exit");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        CollectParams.CollectParameters();
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("Confirm exit program: y/n");
                        string confirmQuit = Console.ReadLine();
                        if (confirmQuit == "y")
                        {
                            Console.WriteLine("Quitting program");
                            Console.WriteLine("");
                            Environment.Exit(0);
                        }
                        else if (confirmQuit == "n")
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Input not recognized. Try again");
                            Console.WriteLine("");
                        }

                        break;
                    default:
                        Console.WriteLine("Input not recognized. Please try again");
                        Console.WriteLine("");
                        break;
                }

                
            }
        }

    }
}
