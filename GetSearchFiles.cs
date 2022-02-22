using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageSearchTool
{
    internal class GetSearchFiles
    {
        /// <summary>
        /// Method that collects files to be validated as JPG or PDF.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPatternExpression"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>

        internal static IEnumerable<string> GetFiles(string path,
                    string searchPatternExpression = ".jpg|.pdf",
                    SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            try
            {
                Regex reSearchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);
                return Directory.EnumerateFiles(path, "*", searchOption)
                                .Where(file =>
                                         reSearchPattern.IsMatch(Path.GetExtension(file)));
            }
            catch (System.UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<string>();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<string>();
            }
        }
            /// <summary>
            /// Method to validate hexidecimal string of file signature as JPG. Returns true or false as bool and type "JPG" as string.
            /// </summary>
            /// <param name="hexStr">Hexidecimal string to be validated as JPG.</param>
            /// <param name="type">Output value of "JPG" as string type.</param>
            /// <returns></returns>
            internal static bool ValidateJpg(string hexStr, out string type)
            {
                Regex reSearchPatternJpg = new Regex(@"(FFD8)", RegexOptions.Singleline);
                type = "JPG";
                return reSearchPatternJpg.IsMatch(hexStr);
            }
            /// <summary>
            /// Method to validate hexidecimal string of file signature as PDF. Returns true or false as bool and type "PDF" as string.
            /// </summary>
            /// <param name="hexStr">Hexidecimal string to be validated as PDF.</param>
            /// <param name="type">Output value of "PDF" as string type.</param>
            /// <returns></returns>
            internal static bool ValidatePdf(string hexStr, out string type)
            {
                Regex reSearchPatternPdf = new Regex(@"(^25504446)", RegexOptions.IgnoreCase);
                type = "PDF";
                return reSearchPatternPdf.IsMatch(hexStr);
            }

            internal static IEnumerable<string> FileToHex(IEnumerable<string> files)
            {
                string type; 
                List<string> typeList = new List<string>();               
                foreach (var file in files)
                {
                    // Get hexidecimal value at beginning of file
                    using BinaryReader br = new BinaryReader(File.OpenRead(file));
                    string hex = "";

                    for (int i = 0x00000000; i <= 0x00000008; i++)
                    {
                        br.BaseStream.Position = i;
                        hex += br.ReadByte().ToString("X2");
                    }
                    //validate hexidecimal value
                    if (ValidateJpg(hex, out type) == true || ValidatePdf(hex, out type) == true)
                    {
                        typeList.Add(type);
                    }

                }
                return typeList;
            }

        }
    }



