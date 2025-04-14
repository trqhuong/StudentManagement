namespace PresentationLayer
{
    partial class FrmInput
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
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbSubject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiem15P = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiem1T = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiemThi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvScore
            // 
            this.dgvScore.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Location = new System.Drawing.Point(12, 362);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.RowHeadersWidth = 51;
            this.dgvScore.RowTemplate.Height = 24;
            this.dgvScore.Size = new System.Drawing.Size(1040, 334);
            this.dgvScore.TabIndex = 11;
            this.dgvScore.SelectionChanged += new System.EventHandler(this.dgvScore_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 67);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(448, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập điểm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(188, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Môn học:";
            // 
            // cbbSubject
            // 
            this.cbbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSubject.FormattingEnabled = true;
            this.cbbSubject.Location = new System.Drawing.Point(291, 150);
            this.cbbSubject.Name = "cbbSubject";
            this.cbbSubject.Size = new System.Drawing.Size(226, 33);
            this.cbbSubject.TabIndex = 15;
            this.cbbSubject.SelectedIndexChanged += new System.EventHandler(this.cbbSubject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(441, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(307, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 39);
            this.label4.TabIndex = 16;
            this.label4.Text = "Danh sách lớp của môn học";
            // 
            // cbbClass
            // 
            this.cbbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(670, 148);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(226, 33);
            this.cbbClass.TabIndex = 15;
            this.cbbClass.SelectedIndexChanged += new System.EventHandler(this.cbbClass_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(574, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Lớp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(58, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(232, 46);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(736, 28);
            this.txtHoTen.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(58, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Điểm 15 phút:";
            // 
            // txtDiem15P
            // 
            this.txtDiem15P.Location = new System.Drawing.Point(205, 98);
            this.txtDiem15P.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiem15P.Multiline = true;
            this.txtDiem15P.Name = "txtDiem15P";
            this.txtDiem15P.Size = new System.Drawing.Size(96, 28);
            this.txtDiem15P.TabIndex = 18;
            this.txtDiem15P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiem15P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowDecimalOnly_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(339, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Điểm 1 tiết:";
            // 
            // txtDiem1T
            // 
            this.txtDiem1T.Location = new System.Drawing.Point(462, 98);
            this.txtDiem1T.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiem1T.Multiline = true;
            this.txtDiem1T.Name = "txtDiem1T";
            this.txtDiem1T.Size = new System.Drawing.Size(103, 28);
            this.txtDiem1T.TabIndex = 18;
            this.txtDiem1T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiem1T.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowDecimalOnly_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(606, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Điểm thi:";
            // 
            // txtDiemThi
            // 
            this.txtDiemThi.Location = new System.Drawing.Point(715, 100);
            this.txtDiemThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiemThi.Multiline = true;
            this.txtDiemThi.Name = "txtDiemThi";
            this.txtDiemThi.Size = new System.Drawing.Size(107, 28);
            this.txtDiemThi.TabIndex = 18;
            this.txtDiemThi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiemThi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowDecimalOnly_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.txtDiemThi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDiem1T);
            this.groupBox1.Controls.Add(this.txtDiem15P);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 198);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1040, 146);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập điểm:";
            // 
            // btSave
            // 
            this.btSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSave.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btSave.FlatAppearance.BorderSize = 0;
            this.btSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btSave.Location = new System.Drawing.Point(853, 98);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(115, 34);
            this.btSave.TabIndex = 19;
            this.btSave.Text = "Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // FrmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbClass);
            this.Controls.Add(this.cbbSubject);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInput";
            this.Text = "FrmInput";
            this.Load += new System.EventHandler(this.FrmInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiem15P;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiem1T;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiemThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSave;
    }
}