
namespace FizzBuzz_tugas_1
{
    partial class Pegawai
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
            this.tabAbsensi = new System.Windows.Forms.TabPage();
            this.tabGaji = new System.Windows.Forms.TabPage();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabAbsensi);
            this.tabControl1.Controls.Add(this.tabGaji);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-1, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 467);
            this.tabControl1.TabIndex = 13;
            // 
            // tabAbsensi
            // 
            this.tabAbsensi.BackColor = System.Drawing.Color.Transparent;
            this.tabAbsensi.Location = new System.Drawing.Point(4, 25);
            this.tabAbsensi.Name = "tabAbsensi";
            this.tabAbsensi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbsensi.Size = new System.Drawing.Size(717, 438);
            this.tabAbsensi.TabIndex = 0;
            this.tabAbsensi.Text = "Absensi";
            // 
            // tabGaji
            // 
            this.tabGaji.BackColor = System.Drawing.Color.Transparent;
            this.tabGaji.Location = new System.Drawing.Point(4, 25);
            this.tabGaji.Name = "tabGaji";
            this.tabGaji.Padding = new System.Windows.Forms.Padding(3);
            this.tabGaji.Size = new System.Drawing.Size(717, 438);
            this.tabGaji.TabIndex = 1;
            this.tabGaji.Text = "Gaji";
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.SeaShell;
            this.tabHome.Controls.Add(this.pictureBox1);
            this.tabHome.Controls.Add(this.button6);
            this.tabHome.Controls.Add(this.button5);
            this.tabHome.Controls.Add(this.btnLogin);
            this.tabHome.Controls.Add(this.label1);
            this.tabHome.Location = new System.Drawing.Point(4, 25);
            this.tabHome.Name = "tabHome";
            this.tabHome.Size = new System.Drawing.Size(717, 438);
            this.tabHome.TabIndex = 2;
            this.tabHome.Text = "Home";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FizzBuzz_tugas_1.Properties.Resources.clean_laundry;
            this.pictureBox1.Location = new System.Drawing.Point(223, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.RoyalBlue;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(353, 344);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(226, 51);
            this.button6.TabIndex = 27;
            this.button6.Text = "Informasi Gaji";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkCyan;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(121, 344);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(226, 51);
            this.button5.TabIndex = 26;
            this.button5.Text = "Absensi";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Red;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(622, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 29);
            this.btnLogin.TabIndex = 25;
            this.btnLogin.Text = "Keluar";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 37);
            this.label1.TabIndex = 24;
            this.label1.Text = "Selamat Datang Shintia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 479);
            this.Controls.Add(this.tabControl1);
            this.Name = "Pegawai";
            this.Text = "Pegawai - Clean Laundry";
            this.tabControl1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAbsensi;
        private System.Windows.Forms.TabPage tabGaji;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
    }
}