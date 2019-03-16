/****************************************
 * Bryce Graham
 * CS 2282
 * Beard
 * Allows user to open, edit and save programs
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
    public partial class ProgramEditor : Form
    {
        public ProgramEditor()
        {
            InitializeComponent();    
        }

        // Authenticates the program and opens the save file dialog if
        // the program is in the correct format.
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextFile newProgram = new TextFile();
            newProgram.newTextFile(programRTB.Text.Trim());
            ProgramAuthenticator authenticator = new ProgramAuthenticator(newProgram.ProgramLines);
            if (authenticator.Authentic)
            {
                saveFileDialog1.ShowDialog();
            }
            else MessageBox.Show("invalid program");
        }

        // Saves the contents of the rich text box into a file.
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, programRTB.Text.Trim());
        }

        // Opens a program file into the rich text box.
        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextFile textFile;
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog2.FileName;
                textFile = new TextFile(file);
                programRTB.Text = textFile.ProgramFile;
            }
            
        }

        // Close the dialog when finished editing.
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
