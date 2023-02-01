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
        public int harga = 0, harga1;
        public int primarykey;

        Login Login;
        public Pelanggan(Login Login)
        {
            InitializeComponent();
            this.Login = Login;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
        AkunBaru AkunBaru;
        public Pelanggan(AkunBaru AkunBaru)
        {
            InitializeComponent();
            this.AkunBaru = AkunBaru;
        }
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
        private void HitungTotal()
        {
            int BeratPakaian = int.Parse(sliderJumlahLaundry.Value.ToString());
            harga = BeratPakaian * harga1;
            lblHarga.Text = harga.ToString("Rp ##,000");
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
                harga = 14000;
                harga1 = 14000;
            }
            else
            {
                lblPilihanLaundry.Text = $"Cuci {pilihanLaundry}";
                lblPakaian.Text = $"Jumlah {pilihanLaundry}";
                harga = 10000;
                harga1 = 10000;
            }

            lblHarga.Text = harga1.ToString("Rp ##,000");

        }


        // ----- load data
        private void LoadDataCustomer()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblCustomer";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblCustomer");
            dc[0] = ds.Tables["tblCustomer"].Columns[0];
            ds.Tables["tblCustomer"].PrimaryKey = dc;
        }
        private void LoadDataTrans()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblTransaction";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblTransaction");
            dc[0] = ds.Tables["tblTransaction"].Columns[0];
            ds.Tables["tblTransaction"].PrimaryKey = dc;
        }
        private void LoadDataDelivery()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblDelivery";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblDelivery");
            dc[0] = ds.Tables["tblDelivery"].Columns[0];
            ds.Tables["tblDelivery"].PrimaryKey = dc;
        }
        private void LoadDataRiwayat()
        {
            ds = new DataSet();
            if (rdoFilterSemua.Checked)
            {
                query = $"SELECT D.Transaction_Id, C.Category_Name, T.Total, T.Total_Price, D.Status, D.Pickup_Date, D.Delivery_Date FROM dbo.tblTransaction T INNER JOIN dbo.tblDelivery D ON T.Transaction_Id = D.Transaction_Id INNER JOIN dbo.tblCategory C ON T.Category_Id = C.Category_Id WHERE T.Customer_Id = '{lblCustID.Text}'";
            }
            else if (rdoFilterPending.Checked)
            {
                query = $"SELECT D.Transaction_Id, C.Category_Name, T.Total, T.Total_Price, D.Status, D.Pickup_Date, D.Delivery_Date FROM dbo.tblTransaction T INNER JOIN dbo.tblDelivery D ON T.Transaction_Id = D.Transaction_Id INNER JOIN dbo.tblCategory C ON T.Category_Id = C.Category_Id WHERE T.Customer_Id = '{lblCustID.Text}' AND D.Status = 'Pending'";
            }
            else if (rdoFilterDiproses.Checked)
            {
                query = $"SELECT D.Transaction_Id, C.Category_Name, T.Total, T.Total_Price, D.Status, D.Pickup_Date, D.Delivery_Date FROM dbo.tblTransaction T INNER JOIN dbo.tblDelivery D ON T.Transaction_Id = D.Transaction_Id INNER JOIN dbo.tblCategory C ON T.Category_Id = C.Category_Id WHERE T.Customer_Id = '{lblCustID.Text}' AND D.Status = 'Diproses'";
            }
            else if (rdoFilterDikirim.Checked)
            {
                query = $"SELECT D.Transaction_Id, C.Category_Name, T.Total, T.Total_Price, D.Status, D.Pickup_Date, D.Delivery_Date FROM dbo.tblTransaction T INNER JOIN dbo.tblDelivery D ON T.Transaction_Id = D.Transaction_Id INNER JOIN dbo.tblCategory C ON T.Category_Id = C.Category_Id WHERE T.Customer_Id = '{lblCustID.Text}' AND D.Status = 'Dikirim'";
            }
            else if (rdoFilterSelesai.Checked)
            {
                query = $"SELECT D.Transaction_Id, C.Category_Name, T.Total, T.Total_Price, D.Status, D.Pickup_Date, D.Delivery_Date FROM dbo.tblTransaction T INNER JOIN dbo.tblDelivery D ON T.Transaction_Id = D.Transaction_Id INNER JOIN dbo.tblCategory C ON T.Category_Id = C.Category_Id WHERE T.Customer_Id = '{lblCustID.Text}' AND D.Status = 'Selesai'";
            }
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblDelivery");
            dc[0] = ds.Tables["tblDelivery"].Columns[0];
            ds.Tables["tblDelivery"].PrimaryKey = dc;
        }

        // ----- tampil data
        private void tampilDataCustomer()
        {
            LoadDataCustomer();
            dr = ds.Tables["tblCustomer"].Rows.Find(lblCustID.Text);
            txtPassword.Text = dr[2].ToString();
            txtNama.Text = dr[1].ToString();
            txtAlamat.Text = dr[3].ToString();
            txtNomorTelepon.Text = dr[4].ToString();
        }

        private void tampilDataRiwayat()
        {
            LoadDataRiwayat();
            dgvRiwayatPesanan.Rows.Clear();
            foreach (DataRow dr in ds.Tables["tblDelivery"].Rows)
            {
                dgvRiwayatPesanan.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }
        }


        // ----- update data
        private void UpdateDataCustomer()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblCustomer"]);
        }
        private void UpdateDataTrans()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblTransaction"]);
        }
        private void UpdateDataDelivery()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblDelivery"]);
        }
        private void Pelanggan_Load(object sender, EventArgs e)
        {
            koneksi();
            tampilDataCustomer();
            LoadDataTrans();
            lblJumlahLaundry.Text ="-";
            dgvRiwayatPesanan.ColumnCount = 6;
            dgvRiwayatPesanan.Columns[0].HeaderText = "Pesanan";
            dgvRiwayatPesanan.Columns[1].HeaderText = "Total";
            dgvRiwayatPesanan.Columns[2].HeaderText = "Harga";
            dgvRiwayatPesanan.Columns[3].HeaderText = "Status";
            dgvRiwayatPesanan.Columns[4].HeaderText = "Tanggal Pengambilan";
            dgvRiwayatPesanan.Columns[5].HeaderText = "Tanggal Pengiriman";
            dgvRiwayatPesanan.AllowUserToAddRows = false;
            dgvRiwayatPesanan.ReadOnly = true;

            tampilDataRiwayat();
            if (lblPilihanLaundry.Text.Contains("Kiloan"))
            {
                lblJumlahLaundry.Text = 1 + "Kg";
            }
            else
            {
                lblJumlahLaundry.Text = 1+ "Pcs";
            }
        }
        private void KosongDataCustomer()
        {
            txtPassword.Text = "";
            txtNomorTelepon.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            chkShowPassword.Checked = false;
        }
        private void sliderJumlahLaundry_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {

            if (lblPilihanLaundry.Text.Contains("Kiloan"))
            {
                lblJumlahLaundry.Text = sliderJumlahLaundry.Value.ToString() + "Kg";
            }
            else
            {
                lblJumlahLaundry.Text = sliderJumlahLaundry.Value.ToString() + "Pcs";
            }
            HitungTotal();
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {


            LoadDataDelivery();

            int row = ds.Tables["tblDelivery"].Rows.Count + 1;
            dr = ds.Tables["tblDelivery"].Rows.Find("TR" + row);
            if (dr == null)
            {
                dr = ds.Tables["tblDelivery"].NewRow();
                dr[0] = "TR" + row;
                dr[1] = datePengambilan.Value.ToString();
                if (rdoNextDays.Checked)
                {
                    dr[2] = datePengambilan.Value.AddDays(1);
                }
                else
                {
                    dr[2] = datePengambilan.Value.AddDays(3);
                }
                dr[3] = "Pending";
            }
            ds.Tables["tblDelivery"].Rows.Add(dr);
            UpdateDataDelivery();

            LoadDataTrans(); 
            dr = ds.Tables["tblTransaction"].Rows.Find("TR" + row);
            if (dr == null)
            {
                dr = ds.Tables["tblTransaction"].NewRow();
                dr[0] = "TR" + row;
                dr[1] = lblCustID.Text;
                if (lblPilihanLaundry.Text.Contains("Kiloan"))
                {
                    dr[2] = "Laundry_Kiloan";
                }
                else
                {
                    dr[2] = "Laundry_Satuan";
                }
                dr[3] = lblPilihanLaundry.Text;
                dr[4] = sliderJumlahLaundry.Value.ToString();
                dr[5] = harga;
                dr[6] = txtCatatanPesanan.Text;
            }
            ds.Tables["tblTransaction"].Rows.Add(dr);
            UpdateDataTrans();


            snackBarBuatPesanan.Show(this, "Pesanan berhasil dibuat", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            tabNavigasi.PageIndex = 1;
            KosongDetail();
            LoadDataRiwayat();
            tampilDataRiwayat();
        }

        private void KosongDetail()
        {
            sliderJumlahLaundry.Value = 0;
            lblJumlahLaundry.Text = "-";
            datePengambilan.Value = DateTime.Today;
            txtCatatanPesanan.Text = "";
            lblHarga.Text = "Rp 0";
        }

        private void btnPesananBaru_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 0;
            tpPesanan.PageIndex = 0;
            KosongDetail();
            if (lblPilihanLaundry.Text.Contains("Kiloan"))
            {
                lblJumlahLaundry.Text = 1 + "Kg";
            }
            else
            {
                lblJumlahLaundry.Text = 1 + "Pcs";
            }
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
                this.Close();
            }

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 2;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDataCustomer();

            dr = ds.Tables["tblCustomer"].Rows.Find(lblCustID.Text);
            if (dr != null)
            {
                dr[1] = txtNama.Text;
                dr[2] = txtPassword.Text;
                dr[3] = txtAlamat.Text;
                dr[4] = txtNomorTelepon.Text;

                UpdateDataCustomer();
                snackbar.Show(this, "Profile information has been updated successfully", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000);
                KosongDataCustomer();
                tampilDataCustomer();
            }
        }

        private void rdoFilter_CheckedChanged(object sender, EventArgs e)
        {
            tampilDataRiwayat();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

    }
}

