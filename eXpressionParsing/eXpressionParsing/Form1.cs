using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eXpressionParsing
{
    public partial class Form1 : Form
    {
        Parser expressionParser;

        public Form1()
        {
            InitializeComponent();
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            string expression = expressionTbx.Text;
            if (expression == string.Empty)
            {
                MessageBox.Show("Please enter an expression to parse.");
            }
            else
            {
                expressionParser = new Parser(expression);
                expressionParser.Parse();
                humanReadableLbl.Text = expressionParser.ToString();
            }
        }
    }
}
