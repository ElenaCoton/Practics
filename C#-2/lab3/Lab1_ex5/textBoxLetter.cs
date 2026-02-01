using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3_ex4
{
    public class textBoxLetter: System.Windows.Forms.TextBox
    {
        public string MyFIO 
        { get { return this.Text.ToUpper(); }
          set { this.Text = value; }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //недопустимыми значениями будут цифры
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
    }
}
