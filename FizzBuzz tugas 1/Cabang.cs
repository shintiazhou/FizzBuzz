using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FizzBuzz_tugas_1
{
    public partial class Cabang : Form
    {
        public Cabang()
        {
            InitializeComponent();
        }

        Login Login;
        public Cabang(Login Login)
        {
            InitializeComponent();
            this.Login = Login;
        }
        private void Cabang_Load(object sender, EventArgs e)
        {

        }
    }
}
