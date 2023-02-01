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
using System.Data.SqlClient;

namespace FizzBuzz_tugas_1
{
    public partial class Login : Form
    {
        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {
            koneksi();
            txtUsername.Focus();
            btnLoginPelanggan.Enabled = false;
            btnLoginPegawai.Enabled = false;
            noticeSnackbar.Show(this, "Notice: Jika terdapat build error\nsilahkan coba hapus file licenses.licx dalam folder properties pada project anda.\nTerima kasih!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 5000);
        }

        private void LoaddataEmployee()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblEmployee";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblEmployee");
            dc[0] = ds.Tables["tblEmployee"].Columns[0];
            ds.Tables["tblEmployee"].PrimaryKey = dc;
        }
        private void LoaddataCabang()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblBranch";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblBranch");
            dc[0] = ds.Tables["tblBranch"].Columns[0];
            ds.Tables["tblBranch"].PrimaryKey = dc;
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


        private void btnLoginPelanggan_Click(object sender, EventArgs e)
        {
            LoaddataCustomer();
            dr = ds.Tables["tblCustomer"].Rows.Find(txtUsername.Text);
            if (dr != null)
            {
               if(dr[2].ToString() == txtPassword.Text.ToString())
                {
                    Pelanggan Pelanggan = new Pelanggan(this);
                    Pelanggan.lblCustID.Text = dr[0].ToString();
                    Pelanggan.btnProfile.Text= dr[0].ToString();
                    Pelanggan.ShowDialog();
                }
                else{
                    snackbar.Show(this, "Wrong Password", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
            else
            {
                snackbar.Show(this, "Username " + txtUsername.Text + " Not Found", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            
        }
        private void btnLoginPegawai_Click(object sender, EventArgs e)
        {
            LoaddataEmployee();
            dr = ds.Tables["tblEmployee"].Rows.Find(txtUsername.Text);

            if (dr != null)
            {
                if (dr[2].ToString() == txtPassword.Text.ToString())
                {
                    Pegawai Pegawai = new Pegawai(this);
                    Pegawai.btnProfile.Text = dr[0].ToString();
                    Pegawai.lblEmployeeId.Text = dr[0].ToString();
                    Pegawai.ShowDialog();
                }
                else
                {
                    snackbar.Show(this, "Wrong Password", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
            else
            {
                snackbar.Show(this, "Username " + txtUsername.Text + " Not Found", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }
        private void btnLoginCabang_Click(object sender, EventArgs e)
        {
            LoaddataCabang();
            dr = ds.Tables["tblBranch"].Rows.Find(txtUsername.Text);

            if (dr != null)
            {
                if (dr[1].ToString() == txtPassword.Text.ToString())
                {
                    Cabang Cabang = new Cabang(this);
                    Cabang.btnProfile.Text = dr[0].ToString();
                    Cabang.lblEmployeeId.Text = dr[0].ToString();
                    Cabang.ShowDialog();
                }
                else
                {
                    snackbar.Show(this, "Wrong Password", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
            else
            {
                snackbar.Show(this, "Cabang dengan id " + txtUsername.Text + " tidak ditemukan", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginPelanggan.Enabled = true;
                btnLoginPegawai.Enabled = true;
                     btnLoginCabang.Enabled = true;

            }
            else
            {
                btnLoginPelanggan.Enabled = false;
                btnLoginPegawai.Enabled = false;

                btnLoginCabang.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLoginPelanggan.Enabled = true;
                btnLoginPegawai.Enabled = true;
                btnLoginCabang.Enabled = true;

            }
            else
            {
                btnLoginPelanggan.Enabled = false;
                btnLoginPegawai.Enabled = false;
                btnLoginCabang.Enabled = false;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAkunBaru_Click(object sender, EventArgs e)
        {
            AkunBaru AkunBaru = new AkunBaru(this);
            AkunBaru.ShowDialog();
        }

        private void btnDaftarCabang_Click(object sender, EventArgs e)
        {
            CabangBaru CabangBaru = new CabangBaru(this);
            CabangBaru.ShowDialog();
        }


    }
}
