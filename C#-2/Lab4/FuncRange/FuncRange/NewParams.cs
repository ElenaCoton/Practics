using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuncRange
{
    public partial class NewParams : Form
    {
        public NewParams()
        {
            InitializeComponent();
        }
        public double XFrom
        { 
            get {return double.Parse(textBoxFrom.Text);}
            set { textBoxFrom.Text = value.ToString(); }
        }

        public double XTo
        {
            get { return double.Parse(textBoxTo.Text); }
            set { textBoxTo.Text = value.ToString(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
