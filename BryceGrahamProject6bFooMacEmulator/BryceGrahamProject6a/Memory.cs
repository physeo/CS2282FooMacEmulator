/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Contains all of the memory cells for the
 * emulated computer.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class Memory
    {
        MemoryDump memDump;
        string[] memArray;

        public Memory(List<string> program)
        {
            memArray = new string[100];
            for (int i = 0; i < 100; i++)
                memArray[i] = "000000";
            addProgramToMem(program);
            memDump = new MemoryDump(this);
        }

        // Places the program in memory starting from location 00
        public void addProgramToMem(List<string> program)
        {
            int i = 0;
            foreach(string s in program)
            {
                memArray[i] = s;
                i++;
            }
        }

        public string[] MemArray
        {
            get { return memArray; }
        }

        public MemoryDump MemDump
        {
            get { return memDump; }
        }

        // Adds a value into a memory location
        public void addValueToMemory(int location, int value)
        {
            if((location <= 99 && location >= 0) && (value <= 999999 && value >= -999999))
            {
                memArray[location] = value.ToString("000000");
            }
            memDump = new MemoryDump(this);
        }

        // Resets a memory cell to 000000
        public void ClearMemoryCell(int location)
        {
            if (location <= 99 && location >= 0)
                memArray[location] = "000000";
            memDump = new MemoryDump(this);
        }
    }
}
