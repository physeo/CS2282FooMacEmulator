/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Ensures that a program being loaded or
 * saved is in the correct format and
 * contains only the allowed characters.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BryceGrahamProject6a
{
    class ProgramAuthenticator
    {
        bool authentic;
        const int INSTRUCTION_LENGTH = 6;

        // Makes sure program is written with compatible code
        public ProgramAuthenticator(List<string> programLines)
        {
            if (checkForNonNumbers(programLines) && checkInstructionLengths(programLines))
                authentic = true;
            else authentic = false;
        }

        public bool Authentic
        {
            get { return authentic; }
        }

        // Checks the program for any non-integers
        private bool checkForNonNumbers(List<string> programLines)
        {
            foreach (string s in programLines)
            {
                Match match = Regex.Match(s, "^[0-9]*$");
                if (!match.Success)
                    return false;
            }
            return true;
        }

        // Checks the instructions to make sure they are 6 characters long
        private bool checkInstructionLengths(List<string> programLines)
        {
            foreach(string s in programLines)
                if (s.Length != INSTRUCTION_LENGTH)
                    return false;
            return true;
        }
    }
}
