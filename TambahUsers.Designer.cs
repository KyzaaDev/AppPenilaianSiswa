namespace AppPenilaianSiswa
{
    partial class TambahUsers
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
            btnTambah = new Button();
            label3 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtNama = new TextBox();
            labeldoang = new Label();
            cbRole = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnTambah
            // 
            btnTambah.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTambah.Location = new Point(119, 232);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(215, 30);
            btnTambah.TabIndex = 11;
            btnTambah.Text = "Tambah User";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(311, 45);
            label3.TabIndex = 10;
            label3.Text = "Tambah user bentar";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(119, 131);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(215, 30);
            txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(119, 95);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(215, 30);
            txtUsername.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 131);
            label2.Name = "label2";
            label2.Size = new Size(99, 30);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 95);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 6;
            label1.Text = "Username";
            // 
            // txtNama
            // 
            txtNama.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNama.Location = new Point(119, 167);
            txtNama.Multiline = true;
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(215, 30);
            txtNama.TabIndex = 13;
            // 
            // labeldoang
            // 
            labeldoang.AutoSize = true;
            labeldoang.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labeldoang.Location = new Point(12, 164);
            labeldoang.Name = "labeldoang";
            labeldoang.Size = new Size(69, 30);
            labeldoang.TabIndex = 12;
            labeldoang.Text = "Nama";
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(119, 203);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(215, 23);
            cbRole.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 194);
            label5.Name = "label5";
            label5.Size = new Size(53, 30);
            label5.TabIndex = 15;
            label5.Text = "Role";
            // 
            // TambahUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 280);
            Controls.Add(label5);
            Controls.Add(cbRole);
            Controls.Add(txtNama);
            Controls.Add(labeldoang);
            Controls.Add(btnTambah);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TambahUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TambahUsers";
            Load += TambahUsers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTambah;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
        private TextBox txtNama;
        private Label labeldoang;
        private ComboBox cbRole;
        private Label label5;
    }
}