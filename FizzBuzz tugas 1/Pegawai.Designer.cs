
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAbsensi = new System.Windows.Forms.TabPage();
            this.tabGaji = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Red;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(550, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 29);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "Keluar";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Login Sebagai Shintia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAbsensi);
            this.tabControl1.Controls.Add(this.tabGaji);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-1, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 479);
            this.tabControl1.TabIndex = 13;
            // 
            // tabAbsensi
            // 
            this.tabAbsensi.BackColor = System.Drawing.Color.Transparent;
            this.tabAbsensi.Location = new System.Drawing.Point(4, 25);
            this.tabAbsensi.Name = "tabAbsensi";
            this.tabAbsensi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbsensi.Size = new System.Drawing.Size(646, 450);
            this.tabAbsensi.TabIndex = 0;
            this.tabAbsensi.Text = "Absensi";
            // 
            // tabGaji
            // 
            this.tabGaji.BackColor = System.Drawing.Color.Transparent;
            this.tabGaji.Location = new System.Drawing.Point(4, 25);
            this.tabGaji.Name = "tabGaji";
            this.tabGaji.Padding = new System.Windows.Forms.Padding(3);
            this.tabGaji.Size = new System.Drawing.Size(646, 450);
            this.tabGaji.TabIndex = 1;
            this.tabGaji.Text = "Gaji";
            // 
            // Pegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 484);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Pegawai";
            this.Text = "Pegawai - Clean Laundry";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAbsensi;
        private System.Windows.Forms.TabPage tabGaji;
    }
}