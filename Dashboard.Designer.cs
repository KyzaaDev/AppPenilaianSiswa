namespace AppPenilaianSiswa
{
    partial class Dashboard
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
            msDashboard = new MenuStrip();
            dataToolStripMenuItem = new ToolStripMenuItem();
            dataSiswaToolStripMenuItem = new ToolStripMenuItem();
            inputNilaiToolStripMenuItem = new ToolStripMenuItem();
            keluarToolStripMenuItem = new ToolStripMenuItem();
            lblUsername = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            msDashboard.SuspendLayout();
            SuspendLayout();
            // 
            // msDashboard
            // 
            msDashboard.BackColor = Color.Turquoise;
            msDashboard.Items.AddRange(new ToolStripItem[] { dataToolStripMenuItem, inputNilaiToolStripMenuItem, keluarToolStripMenuItem });
            msDashboard.Location = new Point(0, 0);
            msDashboard.Name = "msDashboard";
            msDashboard.Size = new Size(753, 24);
            msDashboard.TabIndex = 0;
            msDashboard.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataSiswaToolStripMenuItem });
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(43, 20);
            dataToolStripMenuItem.Text = "Data";
            // 
            // dataSiswaToolStripMenuItem
            // 
            dataSiswaToolStripMenuItem.Name = "dataSiswaToolStripMenuItem";
            dataSiswaToolStripMenuItem.Size = new Size(180, 22);
            dataSiswaToolStripMenuItem.Text = "Data Siswa";
            dataSiswaToolStripMenuItem.Click += dataSiswaToolStripMenuItem_Click;
            // 
            // inputNilaiToolStripMenuItem
            // 
            inputNilaiToolStripMenuItem.Name = "inputNilaiToolStripMenuItem";
            inputNilaiToolStripMenuItem.Size = new Size(72, 20);
            inputNilaiToolStripMenuItem.Text = "Input nilai";
            // 
            // keluarToolStripMenuItem
            // 
            keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            keluarToolStripMenuItem.Size = new Size(52, 20);
            keluarToolStripMenuItem.Text = "Keluar";
            keluarToolStripMenuItem.Click += keluarToolStripMenuItem_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(294, 70);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 17);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Selamat datang";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 141);
            label1.Name = "label1";
            label1.Size = new Size(175, 30);
            label1.TabIndex = 2;
            label1.Text = "Aplikasi Penilaian";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(261, 196);
            label2.Name = "label2";
            label2.Size = new Size(219, 32);
            label2.TabIndex = 3;
            label2.Text = "Skansawa Creative";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(87, 228);
            label3.Name = "label3";
            label3.Size = new Size(589, 30);
            label3.TabIndex = 4;
            label3.Text = "Program Keahlian Pengembangan Perangkat Lunak dan Gim";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(237, 258);
            label4.Name = "label4";
            label4.Size = new Size(275, 30);
            label4.TabIndex = 5;
            label4.Text = "SMK Negeri 1 Wadaslintang";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(23, 337);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 1);
            panel1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(297, 341);
            label5.Name = "label5";
            label5.Size = new Size(160, 17);
            label5.TabIndex = 7;
            label5.Text = "Developed by @KyzaaDev";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 379);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblUsername);
            Controls.Add(msDashboard);
            MainMenuStrip = msDashboard;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            msDashboard.ResumeLayout(false);
            msDashboard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msDashboard;
        private ToolStripMenuItem dataToolStripMenuItem;
        private ToolStripMenuItem inputNilaiToolStripMenuItem;
        private ToolStripMenuItem keluarToolStripMenuItem;
        private Label lblUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private ToolStripMenuItem dataSiswaToolStripMenuItem;
    }
}