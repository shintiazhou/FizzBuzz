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
    public partial class AkunBaru : Form
    {
        public AkunBaru()
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

        private void AkunBaru_Load(object sender, EventArgs e)
        {
            koneksi();

            txtUsername.Focus();
            txtPassword.PasswordChar = '*';
            if (chkShowPassword.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void LoaddataEmployee()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblEmployees";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblEmployees");
            dc[0] = ds.Tables["tblEmployees"].Columns[0];
            ds.Tables["tblEmployees"].PrimaryKey = dc;
        }
        private void LoaddataCustomer()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblCustomer";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblCustomer");
            dc[0] = ds.Tables["tblCustomer"].Columns[0];
            ds.Tables["tblCustomer"].PrimaryKey = dc;
        }
        private void UpdateDataEmployee()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblEmployees"]);
        }
        private void UpdateDataCustomer()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblCustomer"]);
        }

        private void Kosong()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNama.Text = "";
            txtNomorTelepon.Text = "";
            txtAlamat.Text = "";
            txtUsername.Focus();
            chkShowPassword.Checked = false;
        }


        private void HalamanUtama()
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
            this.Close();
        }

        private void btnAkunBaru_Click(object sender, EventArgs e)
        {
            if (rdoAkunPegawai.Checked == true)
            {
                LoaddataEmployee();
                dr = ds.Tables["tblEmployees"].Rows.Find(txtUsername.Text);
                if (dr == null)
                {
                    dr = ds.Tables["tblEmployees"].NewRow();
                    dr[0] = txtUsername.Text;
                    dr[1] = txtNama.Text;
                    dr[2] = txtPassword.Text;
                    dr[3] = txtNomorTelepon.Text;
                    dr[4] = txtAlamat.Text;

                    ds.Tables["tblEmployees"].Rows.Add(dr);
                    UpdateDataEmployee();

                    snackbar.Show(this, $"Account created successfully", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000);
                    Pegawai Pegawai = new Pegawai(this);
                    Pegawai.lblEmployeeId.Text = dr[0].ToString();
                    Pegawai.ShowDialog();
                    this.Close();
                }
                else
                {
                    snackbar.Show(this, $"Username {txtUsername.Text} has been taken", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000);
                }
                HalamanUtama();
            }
            if (rdoAkunPelanggan.Checked == true)
            {
                LoaddataCustomer();
                dr = ds.Tables["tblCustomer"].Rows.Find(txtUsername.Text);
                if (dr == null)
                {
                    dr = ds.Tables["tblCustomer"].NewRow();
                    dr[0] = txtUsername.Text;
                    dr[1] = txtNama.Text;
                    dr[2] = txtPassword.Text;
                    dr[3] = txtAlamat.Text;
                    dr[4] = txtNomorTelepon.Text;

                    ds.Tables["tblCustomer"].Rows.Add(dr);
                    UpdateDataCustomer();

                    snackbar.Show(this, $"Account created successfully", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000);
                    Pelanggan Pelanggan = new Pelanggan(this);
                    Pelanggan.lblCustID.Text = dr[0].ToString();
                    Pelanggan.ShowDialog();
                    this.Close();
                }
                else
                {
                    snackbar.Show(this, $"Username {txtUsername.Text} has been taken", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000);
                }
                HalamanUtama();
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
    }
}
