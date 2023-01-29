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
        string username;

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
            btnCariPesanan.Enabled = true;
            btnRefresh.Enabled = true;
            koneksi();
            LoadDataEmployees();
            TampilDataEmployee();


            txtPassword.PasswordChar = '*';

            LoadDataDelivery();
            TampilData();
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
            query = "SELECT t.Customer_Id, d.Pickup_Date, d.Delivery_Date, d.Status, t.Transaction_Id FROM tbldelivery d INNER JOIN tblTransaction t ON d.Transaction_Id = t.Transaction_Id INNER JOIN tblEmployees e ON e.Employee_Id = d.Employee_Id INNER JOIN tblCustomer cust ON cust.Customer_Id = t.Customer_Id WHERE d.Employee_Id LIKE '%" + lblEmployeeId.Text + "%'";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "JoinDTECust");
        }
        private void LoadDataStatus()
        {
            ds = new DataSet();
            query = "SELECT * FROM tbldelivery";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbldelivery");
            dc[0] = ds.Tables["tbldelivery"].Columns[0];
            ds.Tables["tbldelivery"].PrimaryKey = dc;
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
        private void Kosong()
        {
            txtPassword.Text = "";
            txtNomorTelepon.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            chkShowPassword.Checked = false;
        }
        private void TampilData()
        {
            dgvStatusPengiriman.DataSource = ds.Tables["JoinDTECust"];
            dgvStatusPengiriman.Columns[0].HeaderText = "Name";
            dgvStatusPengiriman.Columns[1].HeaderText = "Pickup Date";
            dgvStatusPengiriman.Columns[2].HeaderText = "Delivery Date";
            dgvStatusPengiriman.Columns[3].HeaderText = "Status";
            dgvStatusPengiriman.Columns[4].HeaderText = "Transaction ID";
            dgvStatusPengiriman.AllowUserToAddRows = false;
            dgvStatusPengiriman.ReadOnly = true;
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
            dtpPengambilan.CustomFormat = "dd MMMM yyyy";
            dtpPengambilan.Format = DateTimePickerFormat.Custom;
            dtpPengiriman.CustomFormat = "dd MMMM yyyy";
            dtpPengiriman.Format = DateTimePickerFormat.Custom;

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

        private void btnCariPesanan_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            if (chkPesananPending.Checked)
            {
                query = "SELECT t.Customer_Id, d.Pickup_Date, d.Delivery_Date, d.Status, t.Transaction_Id FROM tbldelivery d INNER JOIN tblTransaction t ON d.Transaction_Id = t.Transaction_Id INNER JOIN tblEmployees e ON e.Employee_Id = d.Employee_Id INNER JOIN tblCustomer cust ON cust.Customer_Id = t.Customer_Id WHERE cust.Customer_Id LIKE '%" + txtCariPesanan.Text + "%' AND d.Pickup_Date = '" + dtpPengambilan.Value.ToString("yyyy-MM-dd") + "' AND d.Delivery_Date = '" + dtpPengiriman.Value.ToString("yyyy-MM-dd") + "' AND d.Status = 'Pending'";
            }
            else if(chkPesananPending.Checked == false)
            {
                query = "SELECT t.Customer_Id, d.Pickup_Date, d.Delivery_Date, d.Status, t.Transaction_Id FROM tbldelivery d INNER JOIN tblTransaction t ON d.Transaction_Id = t.Transaction_Id INNER JOIN tblEmployees e ON e.Employee_Id = d.Employee_Id INNER JOIN tblCustomer cust ON cust.Customer_Id = t.Customer_Id WHERE cust.Customer_Id LIKE '%" + txtCariPesanan.Text + "%' AND d.Pickup_Date = '" + dtpPengambilan.Value.ToString("yyyy-MM-dd") + "' AND d.Delivery_Date = '" + dtpPengiriman.Value.ToString("yyyy-MM-dd") + "'";
            }
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "JoinDTECust");

            TampilData();
        }

        private void dgvStatusPengiriman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = dgvStatusPengiriman.CurrentCell.RowIndex;
            lblTransactionId.Text = dgvStatusPengiriman[4, baris].Value.ToString();
            rdoDiproses.Enabled = true;
            rdoDikirim.Enabled = true;
            rdoSelesai.Enabled = true;
            btnUbahStatusPesanan.Enabled = true;
        }

        private void btnUbahStatusPesanan_Click(object sender, EventArgs e)
        {
            LoadDataStatus();
            dr = ds.Tables["tbldelivery"].Rows.Find(lblTransactionId.Text);
            if(dr != null)
            {
                if (rdoDiproses.Checked)
                {
                    dr[4] = "Diproses";
                }
                else if (rdoDikirim.Checked)
                {
                    dr[4] = "Dikirim";
                }
                else if (rdoSelesai.Checked)
                {
                    dr[4] = "Selesai";
                }
                UpdateDataDelivery();
                MessageBox.Show("Status Delivery has been updated.", "Update Status Delivery", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            else
            {
                MessageBox.Show("Status Delivery does not exists in database. Please Add the status before edit!", "Update Status Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            koneksi();
            LoadDataDelivery();
            TampilData();
            txtCariPesanan.Clear();
            chkPesananPending.Checked = false;
            txtCariPesanan.Focus();
        }
    }
}

