using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FizzBuzz_tugas_1
{
    public partial class Pegawai : Form
    {
        public Pegawai()
        {
            InitializeComponent();
        }

        private void Pegawai_Load(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            string message = "Keluar dari aplikasi?";
            string title = "Keluar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login frm = new Login();
                frm.ShowDialog();
                this.Close();
            }

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 1;
        }
    }
}

