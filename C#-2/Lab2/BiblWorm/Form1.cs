using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblWorm
{
    public partial class Form1 : Form
    {
        public string Author // автор
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Title // Название
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string PublishHouse // Издательство
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public int Page // Количество страниц
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        public int Year // Год издания
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }
        public int InvNumber // Инвентарный номер
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }
        public bool Existence // Наличие
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool SortInvNumber // Сортировка по инвентарному номеру
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }
        public bool ReturnTime // Возвращение в срок
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value; }
        }
        public int PeriodUse // Инвентарный номер
        {
            get { return (int)numericUpDown4.Value; }
            set { numericUpDown4.Value = value; }
        }
        // Журналы
        public string TitleMag // Название журнала
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string Tom // Том
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public int NumberMag //  номер журнала
        {
            get { return (int)numericUpDown5.Value; }
            set { numericUpDown5.Value = value; }
        }

        public int YearMag // Год журнала
        {
            get { return (int)numericUpDown6.Value; }
            set { numericUpDown6.Value = value; }
        }

        public int PeriodUseMag // Инвентарный номер журнала
        {
            get { return (int)numericUpDown7.Value; }
            set { numericUpDown7.Value = value; }
        }

        public bool ExistenceMag // Наличие журнала
        {
            get { return checkBox4.Checked; }
            set { checkBox4.Checked = value; }
        }

        public bool SortInvNumberMag // Сортировка по инвентарному номеру
        {
            get { return checkBox5.Checked; }
            set { checkBox5.Checked = value; }
        }

        public bool Subs // Оформлена подписка
        {
            get { return checkBox6.Checked; }
            set { checkBox6.Checked = value; }
        }

        List<Item> its = new List<Item>();
        List<Item> mag = new List<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book(Author, Title, PublishHouse, Page, Year, InvNumber, Existence);
            //проверку возврата книги в срок:
            if (ReturnTime)
                b.ReturnSrok();
            //расчет стоимости с учетом срока пользования книгой:
            b.PriceBook(PeriodUse);
            //добавьте книгу в список:
            its.Add(b);
            Author = Title = PublishHouse = "";
            Page = InvNumber = PeriodUse = 0;
            Year = 2020;
            Existence = ReturnTime =  false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SortInvNumber)
                its.Sort();
            //Для вывода информации создайте строку класса StringBuilder и с
            //помощью цикла постройте строку с информацией о единице хранения:
            StringBuilder sb = new StringBuilder();
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            //После построения строки выведете ее в элемент richTextBox1:
            richTextBox1.Text = sb.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(SortInvNumberMag)
                mag.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (Item item in mag)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox2.Text = sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Magazine m = new Magazine(Tom, NumberMag, TitleMag, YearMag, PeriodUseMag, ExistenceMag);
            if (Subs)
                m.IfSubs=true;
            mag.Add(m);
            NumberMag = PeriodUseMag = 1;
            Tom = TitleMag = " ";
            ExistenceMag = Subs = false;
            Year = 1900;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
