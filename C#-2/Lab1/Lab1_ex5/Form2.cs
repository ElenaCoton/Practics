using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_ex5
{
    public partial class Form2 : Form
    {
        Form3 myF3;
        Form4 myF4;
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            myF3 = new Form3();
            myF4 = new Form4();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myF3.Show();
                myF3.Activate();
            }   
            catch (ObjectDisposedException ex) 
            {
                myF3 = new Form3();
                myF3.Show();
                myF3.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                myF4.Show();
                myF4.Activate();
            }
            catch (ObjectDisposedException ex)
            {
                myF4 = new Form4();
                myF4.Show();
                myF4.Activate();
            }
        }
    }
}
