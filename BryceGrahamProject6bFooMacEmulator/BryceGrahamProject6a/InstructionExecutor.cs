/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Performs the action associated with
 * a particular instruction and then
 * updates the program counter accordingly.
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceGrahamProject6a
{
    class InstructionExecutor
    {
        ProgramCounter pc;
        int instructionCode;
        int input;
        string output;
        public InstructionExecutor()
        {
            pc = new ProgramCounter();
        }

        public int InstructionCode
        {
            get { return instructionCode; }
        }

        public int Input
        {
            get { return input; }
            set
            {
                if (value <= 999999 && value >= -999999)
                    input = value;
            }
        }

        public string Output
        {
            get { return output; }
            set { output = value; }
        }

        public ProgramCounter PC
        {
            get { return pc; }
        }

        // Runs the proper code for any of the computer's functions
        public void doOneInstruction(Memory mem, Register reg)
        {
            instructionCode = int.Parse(mem.MemArray[pc.PC].Substring(0, 2));
            switch (instructionCode)
            {
                case InstructionSet.READ:
                    read(mem);
                    break;
                case InstructionSet.WRITE:
                    write(mem);
                    break;
                case InstructionSet.LOAD:
                    load(mem, reg);
                    break;
                case InstructionSet.STORE:
                    store(mem, reg);
                    break;
                case InstructionSet.ADD:
                    add(mem, reg);
                    break;
                case InstructionSet.SUBTRACT:
                    subtract(mem, reg);
                    break;
                case InstructionSet.BRANCH:
                    branch(mem);
                    break;
                case InstructionSet.BRANCH_NEGATIVE:
                    branchNegative(mem, reg);
                    break;
                case InstructionSet.BRANCH_ZERO:
                    branchZero(mem, reg);
                    break;
                case InstructionSet.HALT:
                    halt();
                    break;
                default:
                    incrementPC();
                    break;
            }
        }

        // Simply increments the programCounter.
        public void incrementPC()
        {
            pc.PC = pc.PC + 1;
        }

        // Places an input into the memory location indicated by 
        // the destination digits in the instruction.
        public void read(Memory mem)
        {
            mem.addValueToMemory(destinationDigits(mem.MemArray[pc.PC]), input);
            incrementPC();
        }

        // Sets the output to whatever the value is indicated
        // by the source digits in the instruction.
        public void write(Memory mem)
        {
            output = mem.MemArray[sourceDigits(mem.MemArray[pc.PC])];
            incrementPC();
        }

        // Loads an integer from the memory location indicated by the source digits
        // into the register indicated by the destination digits in the instruction.
        public void load(Memory mem, Register reg)
        {
            int register = destinationDigits(mem.MemArray[pc.PC]);
            int value = int.Parse(mem.MemArray[sourceDigits(mem.MemArray[pc.PC])]);
            reg.addValueToRegister(register, value);
            incrementPC();
        }

        // Stores an integer from the register indicated by the destination digits
        // into the memory location indicated by the source digits.
        public void store(Memory mem, Register reg)
        {
            int location = sourceDigits(mem.MemArray[pc.PC]);
            int value = reg.RegArray[destinationDigits(mem.MemArray[pc.PC])];
            mem.addValueToMemory(location, value);
            incrementPC();
        }

        // Adds the integer in the source register to the integer in the destination 
        // register placing the results into the destination register.
        public void add(Memory mem, Register reg)
        {
            int register1 = reg.RegArray[sourceDigits(mem.MemArray[pc.PC])];
            int register2 = reg.RegArray[destinationDigits(mem.MemArray[pc.PC])];
            int sum = register1 + register2;
            if (sum <= 999999 && sum >= -999999)
                reg.addValueToRegister(sourceDigits(mem.MemArray[pc.PC]), sum);
            else throw new OverflowException("Memory overflow");
            incrementPC();
        }

        // Subtracts the integer in the source register from the integer in the destination 
        // register placing the results into the destination register.
        public void subtract(Memory mem, Register reg)
        {
            int register1 = reg.RegArray[sourceDigits(mem.MemArray[pc.PC])];
            int register2 = reg.RegArray[destinationDigits(mem.MemArray[pc.PC])];
            int difference = register2 - register1;
            if(difference >= -999999 && difference <= 999999)
                reg.addValueToRegister(sourceDigits(mem.MemArray[pc.PC]), difference);
            else throw new OverflowException("Memory overflow");
            incrementPC();
        }

        // Sets the program counter to the destination digits.
        public void branch(Memory mem)
        {
            if (destinationDigits(mem.MemArray[pc.PC]) < 0 || destinationDigits(mem.MemArray[pc.PC]) > 99)
                pc.PC = destinationDigits(mem.MemArray[pc.PC]);
            else throw new OutOfMemoryException("Location out of memory");
        }

        // Sets the program counter to the destination digits
        // if the value in the memory location indicated by the
        // source digits is negative.
        public void branchNegative(Memory mem, Register reg)
        {
            int register = reg.RegArray[sourceDigits(mem.MemArray[pc.PC])];
            if (register < 0)
            {
                if (destinationDigits(mem.MemArray[pc.PC]) < 0 || destinationDigits(mem.MemArray[pc.PC]) > 99)
                    pc.PC = destinationDigits(mem.MemArray[pc.PC]);
                else throw new OutOfMemoryException("Location out of memory");
            }
            else incrementPC();
        }

        // Sets the program counter to the destination digits
        // if the value in the memory location indicated by the
        // source digits is zero.
        public void branchZero(Memory mem, Register reg)
        {
            int register = reg.RegArray[sourceDigits(mem.MemArray[pc.PC])];
            if (register == 0)
            {
                if (destinationDigits(mem.MemArray[pc.PC]) < 0 || destinationDigits(mem.MemArray[pc.PC]) > 99)
                    pc.PC = destinationDigits(mem.MemArray[pc.PC]);
                else throw new OutOfMemoryException("Location out of memory");
            }
            else incrementPC();
        }

        // Halts the program.
        public void halt()
        {
            output = "end";
        }

        // Extracts the destination digits (last two) from an instruction.
        private int destinationDigits(string instruction)
        {
            return int.Parse(instruction.Substring(4, 2));
        }

        // Extracts the source digits (middle two) from an instruction.
        private int sourceDigits(string instruction)
        {
            return int.Parse(instruction.Substring(2, 2));
        }
    }
}
