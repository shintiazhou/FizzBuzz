using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            koneksi();
            txtPassword.MaxLength = 10;
            txtNama.MaxLength = 10;
            txtNomorTelepon.MaxLength = 13;

            txtPassword.PasswordChar = '*';
            if (chkShowPassword.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void LoadData()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblEmployees";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblEmployees");
            dc[0] = ds.Tables["tblEmployees"].Columns[0];
            ds.Tables["tblEmployees"].PrimaryKey = dc;
        }
        private void UpdateData()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblEmployees"]);
        }
        private void Kosong()
        {
            lblEmployeeId.Text = "";
            txtPassword.Text = "";
            txtNomorTelepon.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            chkShowPassword.Checked = false;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();

            dr = ds.Tables["tblEmployees"].Rows.Find(lblEmployeeId.Text);
            if (dr != null)
            {
                dr[1] = txtNama.Text;
                dr[2] = txtPassword.Text;
                dr[3] = txtNomorTelepon.Text;
                dr[4] = txtAlamat.Text;

                UpdateData();
                MessageBox.Show("Username " + lblEmployeeId.Text + " has been edited.", "Edit Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Kosong();
            }
            else
            {
                MessageBox.Show("Username " + lblEmployeeId.Text + " not exist in database, register your account.", "Edit Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

