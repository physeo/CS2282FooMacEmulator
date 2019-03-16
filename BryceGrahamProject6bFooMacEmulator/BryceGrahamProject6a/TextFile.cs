/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Reads or writes text files containing
 * FooMac programs.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BryceGrahamProject6a
{
    class TextFile
    {
        ProgramAuthenticator authenticator;
        string programFile;
        List<string> programLines;

        public TextFile()
        { }

        public TextFile(string _fileName)
        {
            programFile = readFile(_fileName);
            newTextFile(programFile);
        }

        public List<string> ProgramLines
        {
            get { return programLines; }
        }

        public string ProgramFile
        {
            get { return programFile; }
        }

        // Reads a file into a string
        protected string readFile(string filename)
        {
            Int32 _bufferSize;
            StringBuilder stringBuilder = new StringBuilder();
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            // set buffer size to file length
            _bufferSize = Convert.ToInt32(fileStream.Length);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");
                while (charsRead > 0)
                {
                    stringBuilder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
            }

            fileStream.Close();
            return stringBuilder.ToString();
        }

        // Puts each line of the program into a list
        public List<string> splitProgram(string _programFile)
        {
            List<string> lineList = new List<string>();
            char[] delimiters = new char[] { '\r', '\n' };
            lineList = _programFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return lineList;
        }

        // Allows the creation of a textfile from a string created within the program.
        public void newTextFile(string newProgram)
        {
            programFile = newProgram;
            authenticator = new ProgramAuthenticator(splitProgram(programFile));
            if (authenticator.Authentic)
            {
                programLines = splitProgram(programFile);
            }
            else
            {
                programLines = new List<string>();
                programLines.Add("incompatable program");
            }
        }
    }
}
