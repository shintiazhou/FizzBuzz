using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FizzBuzz_tugas_1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLoginPelanggan_Click(object sender, EventArgs e)
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
            btnLoginPelanggan.Enabled = false;
            btnLoginPegawai.Enabled = false;
            noticeSnackbar.Show(this, "Notice: Jika terdapat build error\nsilahkan coba hapus file licenses.licx dalam folder properties pada project anda.\nTerima kasih!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 5000);
           

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginPelanggan.Enabled = true;
                btnLoginPegawai.Enabled = true;
            }
            else
            {
                btnLoginPelanggan.Enabled = false;
                btnLoginPegawai.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginPelanggan.Enabled = true;
                btnLoginPegawai.Enabled = true;
            }
            else
            {
                btnLoginPelanggan.Enabled = false;
                btnLoginPegawai.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAkunBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            AkunBaru frm = new AkunBaru();
            frm.ShowDialog();
            this.Close();
        }
    }
}
