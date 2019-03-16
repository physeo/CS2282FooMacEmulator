/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Allows a user to load, write or run
 * programs for the FooMac emulator.
 ****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BryceGrahamProject6a
{
    public partial class FooMac : Form
    {
        public FooMac()
        {
            InitializeComponent();
        }

        Emulator FooMacEmulator;

        // Opens a dialog for the user to select a file
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                FooMacEmulator = new Emulator(file);
                updateDisplays();
                stepButton.Enabled = true;
                runButton.Enabled = true;
                resetButton.Enabled = true;
                resetButton_Click(sender, e);
            }
        }

        // Opens a dialog for the user to create and save their program
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramEditor editor = new ProgramEditor();
            editor.ShowDialog();
        }

        // Steps through the program one instruction at a time
        private void stepButton_Click(object sender, EventArgs e)
        {
            stepOnce();
        }

        // Runs the program from the current instruction
        private async void runButton_Click(object sender, EventArgs e)
        {
            int instructionCode = int.Parse(FooMacEmulator.Mem.MemArray[FooMacEmulator.CPU.Execute.PC.PC].Substring(0, 2));
            int time;
            int timeDelay;
            if (int.TryParse(timeTextBox.Text.Trim(), out time))
                timeDelay = time;
            else timeDelay = 0;
            while (FooMacEmulator.CPU.Execute.Output != "end")
            {
                stepOnce();
                await Task.Delay(timeDelay);
            }
        }

        // Resets memory and register values to default and reloads the program file
        private void resetButton_Click(object sender, EventArgs e)
        {
            programDisplayListBox.Items.Clear();
            memDumpDisplay.Clear();
            outputTextBox.Clear();
            timeTextBox.Text = "0";
            FooMacEmulator = FooMacEmulator.reset();
            updateDisplays();
        }

        // Updates the displays on the form to reflect the memory values.
        private void updateDisplays()
        {
            programDisplayListBox.Items.Clear();
            int index = 0;
            programDisplayListBox.Items.Add("Memory\tInstruction");
            foreach (string s in FooMacEmulator.Mem.MemArray)
            {
                programDisplayListBox.Items.Add(index.ToString("00") + "\t" + s);
                index++;
            }
            programDisplayListBox.SelectedItem = programDisplayListBox.Items[FooMacEmulator.CPU.Execute.PC.PC];
            memDumpDisplay.Text += FooMacEmulator.Mem.MemDump.DumpText;
            memDumpDisplay.Text += "Registers:\r\n";
            int index2 = 0;
            foreach (int value in FooMacEmulator.CPU.Registers.RegArray)
            {
                memDumpDisplay.Text += index2.ToString("00") + "\t" + value.ToString("000000") + "\r\n";
                index2++;
            }
            PCTextBox.Text = FooMacEmulator.CPU.Execute.PC.PC.ToString("00");
            registerTextBox1.Text = FooMacEmulator.CPU.Registers.RegArray[0].ToString("000000");
            registerTextBox2.Text = FooMacEmulator.CPU.Registers.RegArray[1].ToString("000000");
            registerTextBox3.Text = FooMacEmulator.CPU.Registers.RegArray[2].ToString("000000");
            registerTextBox4.Text = FooMacEmulator.CPU.Registers.RegArray[3].ToString("000000");
            registerTextBox5.Text = FooMacEmulator.CPU.Registers.RegArray[4].ToString("000000");
            registerTextBox6.Text = FooMacEmulator.CPU.Registers.RegArray[5].ToString("000000");
            registerTextBox7.Text = FooMacEmulator.CPU.Registers.RegArray[6].ToString("000000");
            registerTextBox8.Text = FooMacEmulator.CPU.Registers.RegArray[7].ToString("000000");
        }

        // Places the user input value into the CPU where the program can use it
        private void userInput(int instructionCode)
        {
            inputBox input = new inputBox();
            input.ShowDialog();
            input.Activate();
            FooMacEmulator.CPU.Execute.Input = input.UserInput;
        }

        private void stepOnce()
        {
            int instructionCode = int.Parse(FooMacEmulator.Mem.MemArray[FooMacEmulator.CPU.Execute.PC.PC].Substring(0, 2));
            if (instructionCode == 40)
                userInput(instructionCode);
            FooMacEmulator.step();
            if (instructionCode == 41)
                outputTextBox.Text = FooMacEmulator.CPU.Execute.Output;
            if (instructionCode != 23)
                updateDisplays();
        }
    }
}
