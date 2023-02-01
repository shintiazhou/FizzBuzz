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
    public partial class Cabang : Form
    {
        public Cabang()
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
        public Cabang(Login Login)
        {
            InitializeComponent();
            this.Login = Login;
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
        private void LoadDataCabang()
        {
            ds = new DataSet();
            query = "SELECT * FROM tblBranch";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblBranch");
            dc[0] = ds.Tables["tblBranch"].Columns[0];
            ds.Tables["tblBranch"].PrimaryKey = dc;
        }
        private void TampilDataCabang()
        {
            LoadDataCabang();
            dr = ds.Tables["tblBranch"].Rows.Find(lblIDCabang.Text);
            lblIDCabang.Text = dr[0].ToString();
            txtPass.Text = dr[1].ToString();
            txtNamaCabang.Text = dr[2].ToString();
            txtAlamatCabang.Text = dr[3].ToString();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == true)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }
        private void UpdateDataCabang()
        {
            cb = new SqlCommandBuilder(da);
            da = cb.DataAdapter;
            da.Update(ds.Tables["tblBranch"]);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDataCabang();

            dr = ds.Tables["tblBranch"].Rows.Find(lblIDCabang.Text);
            if (dr != null)
            {
               
                dr[1] = txtPass.Text;
                dr[2] = txtNamaCabang.Text;
                dr[3] = txtAlamatCabang.Text;

                UpdateDataCabang();
                snackbar.Show(this, "Informasi akun berhasil diupdate", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000);
                TampilDataCabang();
            }
        }

        private void Cabang_Load(object sender, EventArgs e)
        {
            koneksi();
            LoadDataCabang();
            TampilDataCabang();
        }
    }
}
