/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Keeps track of what the next instruction
 * to be executed is.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class ProgramCounter
    {
        int pc;

        public ProgramCounter()
        {
            pc = 0;
        }

        public int PC
        {
            get { return pc; }
            set
            {
                if (value <= 99 && value >= 0)
                    pc = value;
            }
        }
    }
}
