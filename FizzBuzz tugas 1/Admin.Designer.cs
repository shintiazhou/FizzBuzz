
namespace FizzBuzz_tugas_1
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPelanggan = new System.Windows.Forms.TabPage();
            this.tabPegawai = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabKeuangan = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPelanggan);
            this.tabControl1.Controls.Add(this.tabPegawai);
            this.tabControl1.Controls.Add(this.tabKeuangan);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 479);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPelanggan
            // 
            this.tabPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.tabPelanggan.Location = new System.Drawing.Point(4, 25);
            this.tabPelanggan.Name = "tabPelanggan";
            this.tabPelanggan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPelanggan.Size = new System.Drawing.Size(646, 450);
            this.tabPelanggan.TabIndex = 0;
            this.tabPelanggan.Text = "Pelanggan";
            // 
            // tabPegawai
            // 
            this.tabPegawai.BackColor = System.Drawing.Color.Transparent;
            this.tabPegawai.Location = new System.Drawing.Point(4, 25);
            this.tabPegawai.Name = "tabPegawai";
            this.tabPegawai.Padding = new System.Windows.Forms.Padding(3);
            this.tabPegawai.Size = new System.Drawing.Size(646, 450);
            this.tabPegawai.TabIndex = 1;
            this.tabPegawai.Text = "Pegawai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login Sebagai Shintia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Red;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(554, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 29);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Keluar";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // tabKeuangan
            // 
            this.tabKeuangan.BackColor = System.Drawing.Color.Transparent;
            this.tabKeuangan.Location = new System.Drawing.Point(4, 25);
            this.tabKeuangan.Name = "tabKeuangan";
            this.tabKeuangan.Size = new System.Drawing.Size(646, 450);
            this.tabKeuangan.TabIndex = 2;
            this.tabKeuangan.Text = "Keuangan";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 489);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Admin";
            this.Text = "Admin - Clean Laundry";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPelanggan;
        private System.Windows.Forms.TabPage tabPegawai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TabPage tabKeuangan;
    }
}