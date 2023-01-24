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
using System.Data.SqlClient;

namespace FizzBuzz_tugas_1
{
    public partial class Pelanggan : Form
    {
        public Pelanggan()
        {
            InitializeComponent();
        }
        string pilihanLaundry;

        SqlConnection con;
        string constr;
        SqlDataAdapter da;
        SqlCommand cmd;
        string query;
        DataSet ds;
        SqlCommandBuilder cb;
        DataRow dr;
        DataColumn[] dc = new DataColumn[1];

        private void koneksi()
        {
            try
            {
                constr = "Data Source = localhost; Initial Catalog = CleanLaundryPAB; Integrated Security = true";
                con = new SqlConnection(constr);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pelanggan_Load(object sender, EventArgs e)
        {
            koneksi();

            lblJumlahLaundry.Text = sliderJumlahLaundry.Value.ToString() + "Kg";

            dgvRiwayatPesanan.ColumnCount = 6;
            dgvRiwayatPesanan.Columns[0].HeaderText = "Jenis Laundry";
            dgvRiwayatPesanan.Columns[1].HeaderText = "Berat";
            dgvRiwayatPesanan.Columns[2].HeaderText = "Waktu Pengambilan";
            dgvRiwayatPesanan.Columns[3].HeaderText = "Waktu Pengiriman";
            dgvRiwayatPesanan.Columns[4].HeaderText = "Catatan Pesanan";
            dgvRiwayatPesanan.Columns[5].HeaderText = "Total Harga";
            dgvRiwayatPesanan.AllowUserToAddRows = false;
            dgvRiwayatPesanan.ReadOnly = true;
        }

        private void LoadData()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblCustomer";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblCustomer");
            dc[0] = ds.Tables["tblCustomer"].Columns[0];
            ds.Tables["tblCustomer"].PrimaryKey = dc;
        }
        private void UpdateData()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblCustomer"]);
        }
        private void Kosong()
        {
            lblCustID.Text = "";
            txtPassword.Text = "";
            txtNomorTelepon.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            chkShowPassword.Checked = false;
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

        private void HitungTotal()
        {
            int BeratPakaian = sliderJumlahLaundry.Value;
            int harga = BeratPakaian * 4000;

            lblHarga.Text = harga.ToString("Rp ##,000");
        }

        private void sliderJumlahLaundry_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblJumlahLaundry.Text = sliderJumlahLaundry.Value.ToString() + "Kg";
            HitungTotal();
        }

        private void rdoHariKerja_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {
            snackBarBuatPesanan.Show(this, "Pesanan berhasil dibuat", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            tabNavigasi.PageIndex = 1;


            //untuk carik data udah ada di dgvriwayat udah ada atau belum, aku enggak tau parameter yang mau dipakai apa, kalau di praktikum bapak kan "lblProductID" untuk mengetahui data ini udah pernah di "add" atau belum, kalau di sini aku nggak tau mau pake penentunya apa
            //atau kalian mau pakai parameternya itu user? 
            //untuk sementara penentu untuk hindari duplikasi data aku pake control date, yaa. kalau kalian udah ketemu, bisa bilang sama aku biar tak ganti 
            //bool cari = false;
            //for (int i = 0; i <= dgvRiwayatPesanan.Rows.Count - 1; i++)
            //{
            //    if ()
            //    {

            //    }
            //}
            dgvRiwayatPesanan.Rows.Add(lblPilihanLaundry.Text, lblJumlahLaundry.Text, datePengambilan.Value, rdoHariKerja.Text.ToString(), txtCatatanPesanan.Text, lblHarga.Text);
            HitungTotal();

            MessageBox.Show("Pesanan " + lblPilihanLaundry.Text + " has been added", " Detail Order.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KosongDetail();



            //untuk waktu pengirimannya aku nggak tau cara ambil text dari rdo-nya, jadi sementara pake yang rdoharikerja dulu
        }

        private void KosongDetail()
        {
            sliderJumlahLaundry.Value = 0;
            lblJumlahLaundry.Text = "0 Kg";
            datePengambilan.Value = DateTime.Today;
            txtCatatanPesanan.Text = "";
            lblHarga.Text = "Rp 0";
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

        private void tabProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();

            dr = ds.Tables["tblCustomer"].Rows.Find(lblCustID.Text);
            if (dr != null)
            {
                dr[1] = txtNama.Text;
                dr[2] = txtPassword.Text;
                dr[3] = txtAlamat.Text;
                dr[4] = txtNomorTelepon.Text;

                UpdateData();
                MessageBox.Show("Username " + lblCustID.Text + " has been edited.", "Edit Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Kosong();
            }
            else
            {
                MessageBox.Show("Username " + lblCustID.Text + " not exist in database, register your account.", "Edit Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

