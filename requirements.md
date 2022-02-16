# SearchDirectory: Searches for PDF and JPg files and outpus a list of files to specified directory. Can search for files in subdirectories if flag is provided.

# Requirements:
## 1. Takes two inputs and a flag
- a. Directory that contains files to be analyzed
- b. Path for the output file (including file name and extension)
- c. A flag to dertermine whether or not to include subdirectories of the input directory.
## 2. Process each of the files in the directory (and subdirectories if flag == true)
## 3. Determine using a file signature if a given file is a PFD or JPG
- a. JPG files start with 0xFFD8
- b. PDF files start with 0x25504446
## 4. For each file that is a PDF or JPG, creates an entry in the output CSV containing
- a. Full path to the file
- b. Actual file type (PDF or JPG)
- c. The MD5 hash of the file contents

# Program Flow:
## Program.cs -> Menu.cs -> CollectParams.cs 
##									|
##                                  V
##							GetSearchDirs.cs -> GetSearchFiles.cs -> Md5Hash.cs
##									|
##									V
##							WriteOutputFile.cs