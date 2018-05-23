using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSE.GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            reslt.Hide();
        }

        private void search1_TextChanged(object sender, EventArgs e)
        {
            search1.Hide();
            lbl1.Hide();
            btn1.Hide();
            search2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reslt.Show();
            //Form2 forme = new Form2();
            //forme.Show();
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }
    }
}
