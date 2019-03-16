/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * The available instructions for the
 * emulator.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    static class InstructionSet
    {
        public const int READ = 40;
        public const int WRITE = 41;
        public const int LOAD = 70;
        public const int STORE = 71;
        public const int ADD = 60;
        public const int SUBTRACT = 61;
        public const int BRANCH = 20;
        public const int BRANCH_NEGATIVE = 21;
        public const int BRANCH_ZERO = 22;
        public const int HALT = 23;
    }
}
