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
    public partial class Form1 : Form
    {
        List<string> its = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewParams newParams = new NewParams();
            if (newParams.ShowDialog() == DialogResult.OK) 
            {
                labelInfo.Text = "Интервал " + newParams.XFrom + " " + newParams.XTo;
                its.Add(Math.Sin(newParams.XFrom).ToString() + "  " + Math.Sin(newParams.XTo).ToString());
                StringBuilder sb = new StringBuilder();
                foreach (string item in its)
                {
                    sb.Append("\n" + item.ToString());
                }
                richTextBox1.Text = sb.ToString();

            }
        }
    }
}
