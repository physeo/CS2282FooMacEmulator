using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BryceGrahamProject6a
{
    public partial class inputBox : Form
    {
        public inputBox()
        {
            InitializeComponent();
        }

        int userInput;

        public int UserInput
        {
            get { return userInput; }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            int validInt;
            if (int.TryParse(inputTextBox.Text.Trim(), out validInt) && (validInt >= -999999 && validInt <= 999999))
            {
                userInput = validInt;
            }
            else MessageBox.Show("invalid input");
            this.Close();
        }
    }
}
