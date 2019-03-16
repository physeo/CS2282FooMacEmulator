/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * A special type of memory block that can
 * have instructions performed on it.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class Register
    {
        int[] regArray;

        public Register()
        {
            regArray = new int[8];
            for (int i = 0; i < 8; i++)
                regArray[i] = 000000;
        }

        public int[] RegArray
        {
            get { return regArray; }
        }

        // Adds a value into a memory location
        public void addValueToRegister(int register, int value)
        {
            if ((register <= 7 && register >= 0) && (value <= 999999 && value >= -999999))
            {
                regArray[register] = value;
            }
        }

        // Resets a memory cell to 000000
        public void ClearRegister(int register)
        {
            if (register <= 7 && register >= 0)
                regArray[register] = 000000;
        }
    }
}
