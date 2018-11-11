using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eXpressions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void parseExpressionBtn_Click(object sender, EventArgs e)
        {
            string expression = expressionTbx.Text;

            if (expression != string.Empty)
            {
                // Create a parser object with the inserted expression.

                // Parse the expression into a tree data structure.

                // Plot the given expression.

                // Show the tree as a picture.

            }
            else
            {
                MessageBox.Show("Please enter a valid expression.");
            }
        }
    }
}
