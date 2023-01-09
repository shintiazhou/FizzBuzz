using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string pilihanLaundry;
        private void Pelanggan_Load(object sender, EventArgs e)
        {
        }

        private void btnPilihanLaundry_Click(object sender, EventArgs e)
        {
            tpPesanan.PageIndex = 1;

            var button = sender as Button;
            pilihanLaundry = button.Name.Remove(0, 9).Replace('_', ' ');

            if (button.Name.Contains("Kiloan"))
            {
                lblPilihanLaundry.Text = $"{pilihanLaundry} Kiloan";
                lblPakaian.Text = "Berat Pakaian";
                lblJumlahLaundry.Text = "1 Kg";
            }
            else
            {
                lblPilihanLaundry.Text = $"Cuci {pilihanLaundry}";
                lblPakaian.Text = $"Jumlah {pilihanLaundry}";
                lblJumlahLaundry.Text = "1 Pcs";
            }
                
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {
            snackBarBuatPesanan.Show(this, "Pesanan berhasil dibuat", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            tabNavigasi.PageIndex = 1;
        }

        private void btnPesananBaru_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 0;
        }

        private void btnRiwayatPesanan_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 1;
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
            tabNavigasi.PageIndex = 2;
        }
    }
}
