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
    public partial class Pegawai : Form
    {
        public Pegawai()
        {
            InitializeComponent();
        }
        SqlConnection con;
        string constr;
        SqlDataAdapter da;
        SqlCommand cmd;
        string query;
        DataSet ds;
        SqlCommandBuilder cb;
        DataRow dr;
        DataColumn[] dc = new DataColumn[1];

        Login Login;
        public Pegawai(Login Login)
        {
            InitializeComponent();
            this.Login = Login;
        }
        AkunBaru AkunBaru;
        public Pegawai(AkunBaru AkunBaru)
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

        private void Pegawai_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            koneksi();
            LoadDataEmployees();
            TampilDataEmployee();


            txtPassword.PasswordChar = '*';

            SearchDataDelivery();
            TampilDataDelivery();

            LoadDataCustomer();
            TampilCustomer();
        }

        private void LoadDataEmployees()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblEmployees";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblEmployees");
            dc[0] = ds.Tables["tblEmployees"].Columns[0];
            ds.Tables["tblEmployees"].PrimaryKey = dc;
        }
        private void LoadDataDelivery()
        {
            ds = new DataSet();
            query = "SELECT * FROM tbldelivery";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbldelivery");
            dc[0] = ds.Tables["tbldelivery"].Columns[0];
            ds.Tables["tbldelivery"].PrimaryKey = dc;
        }
        private void SearchDataDelivery()
        {
            ds = new DataSet();
            if (chkPesananPending.Checked)
            {
                query = $"SELECT T.Transaction_Id, T.Title, T.Total, T.Total_Price, D.Pickup_Date, D.Delivery_Date, D.Status FROM tblTransaction T INNER JOIN tbldelivery D ON T.Transaction_Id = D.Transaction_Id WHERE T.Customer_Id LIKE '%{cboPelanggan.SelectedItem}%' AND D.Status = 'Pending'";
            }
            else
            {
                query = $"SELECT T.Transaction_Id, T.Title, T.Total, T.Total_Price, D.Pickup_Date, D.Delivery_Date, D.Status FROM tblTransaction T INNER JOIN tbldelivery D ON T.Transaction_Id = D.Transaction_Id WHERE T.Customer_Id LIKE '%{cboPelanggan.SelectedItem}%' ";
            }
                
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbldelivery");
            dc[0] = ds.Tables["tbldelivery"].Columns[0];
            ds.Tables["tbldelivery"].PrimaryKey = dc;
        }
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
        private void UpdateDataEmployees()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblEmployees"]);
        }
        private void UpdateDataDelivery()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tbldelivery"]);
        }
        private void TampilDataDelivery()
        {
            SearchDataDelivery();
            dgvStatusPengiriman.DataSource = ds.Tables["tblDelivery"];
            dgvStatusPengiriman.Columns[0].HeaderText = "ID";
            dgvStatusPengiriman.Columns[1].HeaderText = "Title";
            dgvStatusPengiriman.Columns[2].HeaderText = "Qty";
            dgvStatusPengiriman.Columns[3].HeaderText = "Harga";
            dgvStatusPengiriman.Columns[4].HeaderText = "Pick up";
            dgvStatusPengiriman.Columns[5].HeaderText = "Delivery";
            dgvStatusPengiriman.Columns[6].HeaderText = "Status";
            dgvStatusPengiriman.AllowUserToAddRows = false;
            dgvStatusPengiriman.ReadOnly = true;


            foreach (DataGridViewRow row in dgvStatusPengiriman.Rows)
            {         
                if (row.Cells[6].Value.ToString() =="Pending")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if  (row.Cells[6].Value.ToString() == "Selesai")
                    {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (row.Cells[6].Value.ToString() == "Diproses")
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
                else if (row.Cells[6].Value.ToString() == "Dikirim")
                {
                    row.DefaultCellStyle.BackColor = Color.SkyBlue;
                }
            }
            lblJumlahRecord.Text = dgvStatusPengiriman.RowCount.ToString();
        }
        private void TampilDataEmployee()
        {
            LoadDataEmployees();
            dr = ds.Tables["tblEmployees"].Rows.Find(lblEmployeeId.Text);
            lblEmployeeId.Text = dr[0].ToString();
            txtPassword.Text = dr[2].ToString();
            txtNama.Text = dr[1].ToString();
            txtAlamat.Text = dr[3].ToString();
            txtNomorTelepon.Text = dr[4].ToString();
        }
        private void TampilCustomer()
        {
            LoadDataCustomer();
            cboPelanggan.Items.Clear();
            for (int i = 0; i < ds.Tables["tblCustomer"].Rows.Count; i++)
            {
                if (i == 0)
                {
                    cboPelanggan.Items.Add("");
                }
                cboPelanggan.Items.Add(ds.Tables["tblCustomer"].Rows[i][0].ToString());
            }
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
            txtPassword.PasswordChar = '*';
        }

        private void btnPesanan_Click(object sender, EventArgs e)
        {
            tabNavigasi.PageIndex = 0;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDataEmployees();

            dr = ds.Tables["tblEmployees"].Rows.Find(lblEmployeeId.Text);
            if (dr != null)
            {
                dr[1] = txtNama.Text;
                dr[2] = txtPassword.Text;
                dr[3] = txtNomorTelepon.Text;
                dr[4] = txtAlamat.Text;

                UpdateDataEmployees();
                snackbar.Show(this, "Profile information has been updated successfully", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000);
                TampilDataEmployee();
            }
        }
        private void kosongDelivery()
        {
            dgvStatusPengiriman.ClearSelection();
            rdoDikirim.Enabled = false;
            rdoDiproses.Enabled = false;
            rdoSelesai.Enabled = false;
            lblTransactionId.Text = "";
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


        private void btnUbahStatusPesanan_Click(object sender, EventArgs e)
        {
            LoadDataDelivery();
            dr = ds.Tables["tbldelivery"].Rows.Find(lblTransactionId.Text);
            if(dr != null)
            {
                if (rdoDiproses.Checked)
                {
                    dr[3] = "Diproses";
                }
                else if (rdoDikirim.Checked)
                {
                    dr[3] = "Dikirim";
                }
                else if (rdoSelesai.Checked)
                {
                    dr[3] = "Selesai";
                }
                
                UpdateDataDelivery();
                SearchDataDelivery();
                TampilDataDelivery();
                snackbar.Show(this, "Status has been updated", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                kosongDelivery();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            koneksi();
            SearchDataDelivery();
            TampilDataDelivery();
            chkPesananPending.Checked = false;
            cboPelanggan.SelectedIndex = 0;
        }

        private void cboPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPelanggan.SelectedIndex == 0)
            {
                LoadDataDelivery();
                TampilDataDelivery();
            }
            else
            {
                SearchDataDelivery();
                TampilDataDelivery();
            }
        }


        private void dgvStatusPengiriman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = dgvStatusPengiriman.CurrentCell.RowIndex;
            lblTransactionId.Text = dgvStatusPengiriman[0, baris].Value.ToString();
            rdoDiproses.Enabled = true;
            rdoDikirim.Enabled = true;
            rdoSelesai.Enabled = true;
            btnUbahStatusPesanan.Enabled = true;
        }

        private void chkPesananPending_CheckedChanged(object sender, EventArgs e)
        {
            SearchDataDelivery();
            TampilDataDelivery();
        }
    }
}

