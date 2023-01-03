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
        string name;
        private void Pelanggan_Load(object sender, EventArgs e)
        {

        }
        private void validatePesanan()
        {
            //validasi pesanan , button buat pesanan menjadi enabled 
        }
        private void Pelanggan_FormClosing(object sender, FormClosingEventArgs e)
        {

            string file = Application.StartupPath.Replace("\bin\\Debug", "\\Properties\\licenses.licx");

            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        private void btnPilihanLaundry_Click(object sender, EventArgs e)
        {
            tpPesanan.PageIndex = 1;

            var button = sender as Button;
             name = button.Name.Remove(0, 9).Replace('_', ' ');

            if (button.Name.Contains("Kiloan"))
            {
                lblPilihanLaundry.Text = $"{name} Kiloan";
                lblPakaian.Text = "Berat Pakaian";
                lblJumlahLaundry.Text = "1 Kg";
            }
            else
            {
                lblPilihanLaundry.Text = $"Cuci {name}";
                lblPakaian.Text = $"Jumlah {name}";
                lblJumlahLaundry.Text = "1 Pcs";
            }
                
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {
            snackBarBuatPesanan.Show(this, "Pesanan berhasil dibuat");
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
    }
}
