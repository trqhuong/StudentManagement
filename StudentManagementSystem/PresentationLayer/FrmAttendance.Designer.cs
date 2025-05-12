namespace PresentationLayer
{
    partial class FrmAttendance
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
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.checkNam = new System.Windows.Forms.CheckBox();
            this.checkNu = new System.Windows.Forms.CheckBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.btEnd = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btScanQR = new System.Windows.Forms.Button();
            this.btStopQR = new System.Windows.Forms.Button();
            this.cbbThietBi = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 65);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(372, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Attendance management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDiemDanh
            // 
            this.dgvDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiemDanh.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemDanh.Location = new System.Drawing.Point(23, 474);
            this.dgvDiemDanh.Name = "dgvDiemDanh";
            this.dgvDiemDanh.RowHeadersWidth = 51;
            this.dgvDiemDanh.RowTemplate.Height = 24;
            this.dgvDiemDanh.Size = new System.Drawing.Size(1014, 400);
            this.dgvDiemDanh.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(754, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Information";
            // 
            // txtSID
            // 
            this.txtSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSID.Location = new System.Drawing.Point(655, 132);
            this.txtSID.Multiline = true;
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(382, 44);
            this.txtSID.TabIndex = 1;
            // 
            // txtSName
            // 
            this.txtSName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSName.Location = new System.Drawing.Point(655, 193);
            this.txtSName.Multiline = true;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(382, 44);
            this.txtSName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(500, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "StudentID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(500, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "StudenName:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(500, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Class:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(500, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(500, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Dob:";
            // 
            // dtDob
            // 
            this.dtDob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDob.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDob.Location = new System.Drawing.Point(655, 256);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(382, 30);
            this.dtDob.TabIndex = 4;
            // 
            // checkNam
            // 
            this.checkNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkNam.AutoSize = true;
            this.checkNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNam.ForeColor = System.Drawing.Color.White;
            this.checkNam.Location = new System.Drawing.Point(655, 311);
            this.checkNam.Name = "checkNam";
            this.checkNam.Size = new System.Drawing.Size(77, 29);
            this.checkNam.TabIndex = 5;
            this.checkNam.Text = "Male";
            this.checkNam.UseVisualStyleBackColor = true;
            // 
            // checkNu
            // 
            this.checkNu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkNu.AutoSize = true;
            this.checkNu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNu.ForeColor = System.Drawing.Color.White;
            this.checkNu.Location = new System.Drawing.Point(777, 311);
            this.checkNu.Name = "checkNu";
            this.checkNu.Size = new System.Drawing.Size(99, 29);
            this.checkNu.TabIndex = 6;
            this.checkNu.Text = "Female";
            this.checkNu.UseVisualStyleBackColor = true;
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(655, 344);
            this.txtClass.Multiline = true;
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(382, 44);
            this.txtClass.TabIndex = 12;
            // 
            // btEnd
            // 
            this.btEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEnd.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btEnd.FlatAppearance.BorderSize = 0;
            this.btEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btEnd.Location = new System.Drawing.Point(875, 410);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(162, 44);
            this.btEnd.TabIndex = 13;
            this.btEnd.Text = "End";
            this.btEnd.UseVisualStyleBackColor = true;
            this.btEnd.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(23, 111);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(444, 293);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            // 
            // btScanQR
            // 
            this.btScanQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btScanQR.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btScanQR.FlatAppearance.BorderSize = 0;
            this.btScanQR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btScanQR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btScanQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btScanQR.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btScanQR.Location = new System.Drawing.Point(23, 410);
            this.btScanQR.Name = "btScanQR";
            this.btScanQR.Size = new System.Drawing.Size(162, 44);
            this.btScanQR.TabIndex = 11;
            this.btScanQR.Text = "Scan QR";
            this.btScanQR.UseVisualStyleBackColor = true;
            this.btScanQR.Click += new System.EventHandler(this.btScanQR_Click);
            // 
            // btStopQR
            // 
            this.btStopQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStopQR.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btStopQR.FlatAppearance.BorderSize = 0;
            this.btStopQR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btStopQR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btStopQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStopQR.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btStopQR.Location = new System.Drawing.Point(305, 410);
            this.btStopQR.Name = "btStopQR";
            this.btStopQR.Size = new System.Drawing.Size(162, 44);
            this.btStopQR.TabIndex = 13;
            this.btStopQR.Text = "Stop";
            this.btStopQR.UseVisualStyleBackColor = true;
            this.btStopQR.Click += new System.EventHandler(this.btStopQR_Click);
            // 
            // cbbThietBi
            // 
            this.cbbThietBi.FormattingEnabled = true;
            this.cbbThietBi.Location = new System.Drawing.Point(23, 79);
            this.cbbThietBi.Name = "cbbThietBi";
            this.cbbThietBi.Size = new System.Drawing.Size(444, 24);
            this.cbbThietBi.TabIndex = 14;
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 886);
            this.Controls.Add(this.dgvDiemDanh);
            this.Controls.Add(this.cbbThietBi);
            this.Controls.Add(this.btEnd);
            this.Controls.Add(this.btStopQR);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.btScanQR);
            this.Controls.Add(this.checkNu);
            this.Controls.Add(this.checkNam);
            this.Controls.Add(this.dtDob);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picQR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAttendancecs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAttendance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvDiemDanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.CheckBox checkNam;
        private System.Windows.Forms.CheckBox checkNu;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Button btEnd;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button btScanQR;
        private System.Windows.Forms.Button btStopQR;
        private System.Windows.Forms.ComboBox cbbThietBi;
    }
}