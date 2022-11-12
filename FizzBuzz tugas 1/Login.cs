using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_FizzBuzz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLoginCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pelanggan frm = new Pelanggan();
            frm.ShowDialog();
            this.Close();
        }
        private void btnLoginPegawai_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pegawai frm = new Pegawai();
            frm.ShowDialog();
            this.Close();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            btnLoginCustomer.Enabled = false;
            btnLoginPegawai.Enabled = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginCustomer.Enabled = true;
                btnLoginPegawai.Enabled = true;
            }
            else
            {
                btnLoginCustomer.Enabled = false;
                btnLoginPegawai.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginCustomer.Enabled = true;
                btnLoginPegawai.Enabled = true;
            }
            else
            {
                btnLoginCustomer.Enabled = false;
                btnLoginPegawai.Enabled = false;
            }
        }
    }
}
