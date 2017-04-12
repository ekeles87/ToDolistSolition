using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ToDolist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string path = Application.StartupPath + @"/yap.xml";

        private List<Yapılacak> YapList = new List<Yapılacak>();
        private xmlAktarOku serializer = new xmlAktarOku();
        private void yapılacakKaydet()
        {
            serializer.Serialize<List<Yapılacak>>(path, this.YapList);
        }

        private void yapılacakOku()
        {
            this.YapList = serializer.Deserialize<List<Yapılacak>>(path);
        }
        private void listdoldur()
        {
            this.chckdListBox.Items.Clear();
            foreach (Yapılacak notlar in YapList)
            {
                if(notlar.durum== false)
                this.chckdListBox.Items.Add(notlar);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(path))
            this.yapılacakOku();

            this.listdoldur();
        }

        private void kydbtn_Click(object sender, EventArgs e)
        {
            Yapılacak yap = new Yapılacak()
            {
                not = textBox.Text,
                iszaman = Convert.ToDateTime(dateTimePicker1.Value.ToString()),
                durum = false

            };
            this.YapList.Add(yap);
            this.listdoldur();
            this.yapılacakKaydet();
            this.textBox.Clear();
            this.dateTimePicker1.Value = DateTime.Now;

           
        }

        private void dznbtn_Click(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            Yapılacak sec = (Yapılacak)chckdListBox.SelectedItem;

            sec.not = textBox.Text;
            sec.iszaman = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            this.listdoldur();
            this.yapılacakKaydet();
            this.textBox.Clear();
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            this.YapList.Remove((Yapılacak)chckdListBox.SelectedItem);
            this.listdoldur();
            this.yapılacakKaydet();
            this.textBox.Clear();
        }

        private void chckdListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chckdListBox.SelectedIndex == -1)
                return;
            Yapılacak sec = (Yapılacak)chckdListBox.SelectedItem;
            textBox.Text = sec.not;
        }

        private void chckdListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                Yapılacak sec = (Yapılacak)chckdListBox.SelectedItem;
                sec.durum = true;
                sec.tamtarih = DateTime.Now;
                yapılacakKaydet();
            }

            if (chckdListBox.CheckedItems.Count > 0)
                this.listdoldur();

                     this.textBox.Clear();
        }

  
        private void EskiGstrBtn_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.ShowDialog();
        }
    }
}
