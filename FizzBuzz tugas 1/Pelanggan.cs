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
    public partial class Pelanggan : Form
    {
        public Pelanggan()
        {
            InitializeComponent();
        }
        private void Pelanggan_Load(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }
        private void lblHome_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }
        private void lblPesanan_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(5);
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

        private void btnSelanjutnya_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabControl.SelectedIndex + 1);
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabControl.SelectedIndex - 1);
        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
        }
    }
}
