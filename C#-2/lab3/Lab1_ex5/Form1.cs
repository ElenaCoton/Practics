using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_ex4
{
    public partial class Form1 : Form
    {
        List<string> its = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            its.Add(textBoxLetter1.MyFIO + " --->  " + textBoxNum1.MyPhone);
            textBoxLetter1.MyFIO = "";
            textBoxNum1.MyPhone = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox1.Text = sb.ToString();
        }
    }
}
