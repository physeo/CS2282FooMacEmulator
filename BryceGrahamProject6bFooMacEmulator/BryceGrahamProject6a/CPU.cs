/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * The central processing unit of the
 * emulated machine contains the registers
 * and the program counter and handles the
 * execution of instructions.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class CPU
    {
        Register registers;
        InstructionExecutor execute;

        public CPU(Memory mem)
        {
            registers = new Register();
            execute = new InstructionExecutor(); 
        }
        
        public Register Registers
        {
            get { return registers; }
            set { registers = value; }
        }

        public InstructionExecutor Execute
        {
            get { return execute; }
        }
    }
}
