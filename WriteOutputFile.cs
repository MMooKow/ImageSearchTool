using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearchTool
{
    internal class WriteOutputFile
    {
        /// <summary>
        /// Method that takes in four parameters and writes an output file.
        /// </summary>
        /// <param name="filePath">Path to the file(s) searched and validated. Provided by GetSearchFiles.GetFiles()</param>
        /// <param name="fileType">Actual file type(PDF or JPG). Provided by GetSearchFiles.Validate(JPG/PDF)()</param>
        /// <param name="Md5Hash">MD5 hash of the searched file(s). Provided by Md5Hash.CreateMd5()</param>
        /// <param name="outPutName">Name of the outpue file. Provided by CollectParams.CollectParameters()</param>
        internal static async void WriteOutFile(List<string[]> returnedVals, string outPutName)
        {
            if (File.Exists(outPutName))
            {
                File.Delete(outPutName);
            }
            List<string> lines = new List<string>();
            foreach (string[] val in returnedVals)
            {
                lines.Add($"{val[0]}, {val[1]}, {val[2]}");
            }


            await File.WriteAllLinesAsync($"{outPutName}", lines);
        }
    }
}
