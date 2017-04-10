using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDolist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Yapılacak> YapList = new List<Yapılacak>();
        private void listdoldur()
        {
            this.chckdListBox.Items.Clear();
            foreach (Yapılacak notlar in YapList)
            {
                this.chckdListBox.Items.Add(notlar);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kydbtn_Click(object sender, EventArgs e)
        {
            Yapılacak yap = new Yapılacak()
            {
                not = textBox.Text,
                //iszaman = dateTimePicker1
                durum = false

            };
            this.YapList.Add(yap);
            this.listdoldur();
            this.textBox.Clear();
           
        }

        private void dznbtn_Click(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            Yapılacak sec = (Yapılacak)chckdListBox.SelectedItem;
            sec.not = textBox.Text;
            this.listdoldur();
            this.textBox.Clear();
        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            this.YapList.Remove((Yapılacak)chckdListBox.SelectedItem);
            this.listdoldur();
            this.textBox.Clear();
        }

        private void chckdListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            Yapılacak sec = (Yapılacak)chckdListBox.SelectedItem;
            textBox.Text = sec.not;
        }
    }
}
