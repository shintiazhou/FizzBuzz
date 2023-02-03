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
        DataSet ds, dsCleanLaundry;
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
        private void LoadDataPenjualan()
        {
            dsCleanLaundry = new DataSet();
            string queryParam = $"SELECT T.Transaction_Id, T.Title, T.Total, T.Total_Price, C.Category_Id, C.Category_Name, C.Price, Cs.Customer_Id, Cs.Name, T.Created_Date, T.Branch_ID FROM tblTransaction T INNER JOIN tblCategory C ON T.Category_Id = C.Category_Id INNER JOIN tblCustomer Cs ON T.Customer_Id = Cs.Customer_Id WHERE T.Branch_ID LIKE '%{lblIDCabang.Text}%'";

            cmd = new SqlCommand(queryParam, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dsCleanLaundry, "Transaction");
        }
        private void LoadDataTransaction()
        {

            ds = new DataSet();
            query = $"SELECT * FROM tblTransaction WHERE Branch_Id like '%{lblIDCabang.Text}%'";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblTransaction");
            dc[0] = ds.Tables["tblTransaction"].Columns[0];
            ds.Tables["tblTransaction"].PrimaryKey = dc;

            
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
            int saldo = 0;
            koneksi();
            LoadDataCabang();
            TampilDataCabang();
            LoadDataTransaction();

            for (int i = 0; i < ds.Tables["tblTransaction"].Rows.Count; i++)
            {
                saldo += int.Parse(ds.Tables["tblTransaction"].Rows[i][5].ToString());
            }
           
            menuSaldo.Text = "Rp." + saldo;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Report.crPenjualan cr = new Report.crPenjualan();
            Report.cleanLaundryViewer viewer = new Report.cleanLaundryViewer();
            LoadDataPenjualan();
            cr.SetDataSource(dsCleanLaundry);
            viewer.crystalReportViewer1.ReportSource = cr;
            viewer.WindowState = FormWindowState.Maximized;
            viewer.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
