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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string path = Application.StartupPath + @"/yap.xml";
        private List<Yapılacak> YapList = new List<Yapılacak>();
        private xmlAktarOku serializer = new xmlAktarOku();

        private void yapılacakOku()
        {
            this.YapList = serializer.Deserialize<List<Yapılacak>>(path);
        }

        private void listdoldur()
        {
            this.listBox1.Items.Clear();
            foreach (Yapılacak notlar in YapList)
            {
                if (notlar.durum == true)
                    this.listBox1.Items.Add(notlar);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(path))
                this.yapılacakOku();

            this.listdoldur();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }     
}
