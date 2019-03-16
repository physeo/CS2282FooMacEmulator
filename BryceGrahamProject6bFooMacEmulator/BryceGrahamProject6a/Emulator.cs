/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * An emulated computer that can run
 * programs created from its instruction
 * set.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class Emulator
    {
        Memory mem;
        CPU cpu;
        TextFile program;
        private string programFile;

        public Emulator(string _programFile)
        {
            programFile = _programFile;
            program = new TextFile(programFile);
            mem = new Memory(program.ProgramLines);
            cpu = new CPU(mem);
        }

        public TextFile Program
        {
            get { return program; }
        }

        public Memory Mem
        {
            get { return mem; }
        }

        public CPU CPU
        {
            get { return cpu; }
        }

        // Steps through the program.
        public void step()
        {
            cpu.Execute.doOneInstruction(mem, cpu.Registers);
        }

        // Resets the emulator to its original state.
        public Emulator reset()
        {
            Emulator newEmulator = new Emulator(programFile);
            return newEmulator;
        }
    }
}
