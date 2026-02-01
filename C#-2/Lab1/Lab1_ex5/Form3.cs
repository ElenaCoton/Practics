using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_ex5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] points = {
            new Point(this.Width / 2, 0),    // Верх
            new Point(this.Width, this.Height / 2), // Справа
            new Point(this.Width / 2, this.Height), // Низ
            new Point(0, this.Height / 2)    // Слева
            };
            myPath.AddPolygon(points);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;

            this.BackColor =  Color.FromArgb(0, 255, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
