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
    public partial class CabangBaru : Form
    {
        public CabangBaru()
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
        public CabangBaru(Login Login)
        {
            InitializeComponent();
            this.Login = Login;
        }
        private void Koneksi()
        {
            try
            {
                constr = "Data source = localhost; Initial Catalog = CleanLaundryPAB; Integrated Security = true";
                con = new SqlConnection(constr);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            ds = new DataSet();
            query ="SELECT * FROM tblBranch";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblBranch");
            dc[0] = ds.Tables["tblBranch"].Columns[0];
            ds.Tables["tblBranch"].PrimaryKey = dc;
        }

        private void CompanyBaru_Load(object sender, EventArgs e)
        {
            Koneksi();
            LoadData();
            lblIDCabang.Text ="BRANCH" + (ds.Tables["tblBranch"].Rows.Count +1);
        }
        private void kosong()
        {
            lblIDCabang.Text = "";
            txtAlamat.Clear();
            txtNamaCabang.Clear();
            txtNomorTelepon.Clear();
        }
        private void btnCabangBaru_Click(object sender, EventArgs e)
        {

            dr = ds.Tables["tblBranch"].Rows.Find("BRANCH" + (ds.Tables["tblBranch"].Rows.Count + 1));

                if (dr == null)
                {
                    dr = ds.Tables["tblBranch"].NewRow();
                    dr[0] = lblIDCabang.Text;
                dr[1] = txtPassword.Text;
                dr[2] = txtNamaCabang.Text;
                    dr[3] = txtAlamat.Text;
                ds.Tables["tblBranch"].Rows.Add(dr);
                cb = new SqlCommandBuilder(da);
                da = cb.DataAdapter;
                da.Update(ds.Tables["tblBranch"]);
                kosong();
                    MessageBox.Show("Akun cabang berhasil dibuat", "Cabang Baru", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

