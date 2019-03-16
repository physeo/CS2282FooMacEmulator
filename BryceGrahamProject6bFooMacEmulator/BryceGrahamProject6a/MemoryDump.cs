/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Contains a string of all the current memory
 * values.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class MemoryDump
    {
        string dumpText;

        public MemoryDump(Memory mem)
        {
            dumpText = createMemDump(mem);
        }

        public string DumpText
        {
            get { return dumpText; }
        }

        public string createMemDump(Memory mem)
        {
            StringBuilder builder = new StringBuilder();
            int ndx = 1;
            builder.Append("Memory Dump:");
            builder.AppendLine();
            builder.Append("\t00\t01\t02\t03\t04\t05\t06\t07\t08\t09\r\n");
            foreach(string s in mem.MemArray)
            {
                if (((ndx - 1) % 10) == 0)
                    builder.Append((ndx - 1).ToString("00") + "\t");
                builder.Append(s + "\t");
                if ((ndx % 10) == 0)
                    builder.AppendLine();
                ndx++;
            }
            return builder.ToString();
        }
    }
}
