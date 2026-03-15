namespace AppPenilaianSiswa
{
    partial class SiswaForm
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
            components = new System.ComponentModel.Container();
            label5 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            cbKelas = new ComboBox();
            label6 = new Label();
            btnFoto = new Button();
            txtNamaSiswa = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNISN = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnEdit = new Button();
            btnTutup = new Button();
            btnHapus = new Button();
            btnUpdate = new Button();
            btnSimpan = new Button();
            btnTambah = new Button();
            groupBox3 = new GroupBox();
            dgvSiswa = new DataGridView();
            groupBox4 = new GroupBox();
            pbSiswa = new PictureBox();
            epSiswa = new ErrorProvider(components);
            tmData = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSiswa).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSiswa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epSiswa).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 19);
            label5.Name = "label5";
            label5.Size = new Size(87, 21);
            label5.TabIndex = 9;
            label5.Text = "Data Siswa";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(12, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 1);
            panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbKelas);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnFoto);
            groupBox1.Controls.Add(txtNamaSiswa);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNISN);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(535, 165);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data Siswa";
            // 
            // cbKelas
            // 
            cbKelas.FormattingEnabled = true;
            cbKelas.Items.AddRange(new object[] { "X", "XI", "XII" });
            cbKelas.Location = new Point(121, 77);
            cbKelas.Name = "cbKelas";
            cbKelas.Size = new Size(398, 23);
            cbKelas.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(9, 106);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 26;
            label6.Text = "Foto Siswa";
            // 
            // btnFoto
            // 
            btnFoto.Location = new Point(121, 106);
            btnFoto.Name = "btnFoto";
            btnFoto.Size = new Size(398, 23);
            btnFoto.TabIndex = 25;
            btnFoto.Text = "Pilih Foto";
            btnFoto.UseVisualStyleBackColor = true;
            btnFoto.Click += btnFoto_Click;
            // 
            // txtNamaSiswa
            // 
            txtNamaSiswa.Location = new Point(121, 48);
            txtNamaSiswa.Name = "txtNamaSiswa";
            txtNamaSiswa.Size = new Size(398, 23);
            txtNamaSiswa.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 51);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 22;
            label3.Text = "Nama Siswa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 80);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 20;
            label2.Text = "Kelas";
            // 
            // txtNISN
            // 
            txtNISN.Location = new Point(121, 19);
            txtNISN.Name = "txtNISN";
            txtNISN.Size = new Size(398, 23);
            txtNISN.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 22);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 18;
            label1.Text = "NISN";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEdit);
            groupBox2.Controls.Add(btnTutup);
            groupBox2.Controls.Add(btnHapus);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnSimpan);
            groupBox2.Controls.Add(btnTambah);
            groupBox2.Location = new Point(553, 50);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(235, 165);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(6, 77);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(223, 23);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnTutup
            // 
            btnTutup.Location = new Point(6, 134);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(223, 23);
            btnTutup.TabIndex = 24;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = true;
            btnTutup.Click += btnTutup_Click;
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(6, 105);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(223, 23);
            btnHapus.TabIndex = 23;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(6, 76);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(223, 23);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(6, 47);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(223, 23);
            btnSimpan.TabIndex = 21;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(6, 18);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(223, 23);
            btnTambah.TabIndex = 20;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvSiswa);
            groupBox3.Location = new Point(12, 221);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(535, 198);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "List Siswa";
            // 
            // dgvSiswa
            // 
            dgvSiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSiswa.Location = new Point(9, 22);
            dgvSiswa.Name = "dgvSiswa";
            dgvSiswa.Size = new Size(510, 170);
            dgvSiswa.TabIndex = 26;
            dgvSiswa.CellClick += dgvSiswa_CellClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pbSiswa);
            groupBox4.Location = new Point(559, 221);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(229, 192);
            groupBox4.TabIndex = 27;
            groupBox4.TabStop = false;
            groupBox4.Text = "Foto Siswa";
            // 
            // pbSiswa
            // 
            pbSiswa.Location = new Point(6, 22);
            pbSiswa.Name = "pbSiswa";
            pbSiswa.Size = new Size(217, 164);
            pbSiswa.SizeMode = PictureBoxSizeMode.Zoom;
            pbSiswa.TabIndex = 0;
            pbSiswa.TabStop = false;
            // 
            // epSiswa
            // 
            epSiswa.ContainerControl = this;
            // 
            // tmData
            // 
            tmData.Tick += tmData_Tick;
            // 
            // SiswaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 431);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Name = "SiswaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SiswaForm";
            Load += SiswaForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSiswa).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSiswa).EndInit();
            ((System.ComponentModel.ISupportInitialize)epSiswa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Panel panel1;
        private GroupBox groupBox1;
        private TextBox txtNamaSiswa;
        private Label label3;
        private Label label2;
        private TextBox txtNISN;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnHapus;
        private Button btnUpdate;
        private Button btnSimpan;
        private Button btnTambah;
        private Button btnTutup;
        private GroupBox groupBox3;
        private DataGridView dgvSiswa;
        private Label label6;
        private Button btnFoto;
        private GroupBox groupBox4;
        private PictureBox pbSiswa;
        private ErrorProvider epSiswa;
        private ComboBox cbKelas;
        private System.Windows.Forms.Timer tmData;
        private Button btnEdit;
    }
}