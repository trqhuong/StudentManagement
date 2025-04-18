namespace PresentationLayer
{
    partial class FrmTeacher
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.checkNu = new System.Windows.Forms.CheckBox();
            this.checkNam = new System.Windows.Forms.CheckBox();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTPhone = new System.Windows.Forms.TextBox();
            this.txtTName = new System.Windows.Forms.TextBox();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.btReset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 65);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(380, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teacher Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btDelete
            // 
            this.btDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelete.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btDelete.FlatAppearance.BorderSize = 0;
            this.btDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btDelete.Location = new System.Drawing.Point(532, 324);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(115, 44);
            this.btDelete.TabIndex = 20;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btUpdate.FlatAppearance.BorderSize = 0;
            this.btUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btUpdate.Location = new System.Drawing.Point(393, 324);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(115, 44);
            this.btUpdate.TabIndex = 21;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btAdd.Location = new System.Drawing.Point(254, 324);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(115, 44);
            this.btAdd.TabIndex = 22;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // checkNu
            // 
            this.checkNu.AutoSize = true;
            this.checkNu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNu.ForeColor = System.Drawing.Color.White;
            this.checkNu.Location = new System.Drawing.Point(830, 200);
            this.checkNu.Name = "checkNu";
            this.checkNu.Size = new System.Drawing.Size(59, 29);
            this.checkNu.TabIndex = 19;
            this.checkNu.Text = "Nữ";
            this.checkNu.UseVisualStyleBackColor = true;
            // 
            // checkNam
            // 
            this.checkNam.AutoSize = true;
            this.checkNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNam.ForeColor = System.Drawing.Color.White;
            this.checkNam.Location = new System.Drawing.Point(708, 200);
            this.checkNam.Name = "checkNam";
            this.checkNam.Size = new System.Drawing.Size(75, 29);
            this.checkNam.TabIndex = 18;
            this.checkNam.Text = "Nam";
            this.checkNam.UseVisualStyleBackColor = true;
            // 
            // dtDob
            // 
            this.dtDob.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Location = new System.Drawing.Point(708, 144);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(301, 30);
            this.dtDob.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(586, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Dob:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(586, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Gender:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(34, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "TeacherName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "TeacherID:";
            // 
            // txtTPhone
            // 
            this.txtTPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTPhone.Location = new System.Drawing.Point(189, 246);
            this.txtTPhone.Multiline = true;
            this.txtTPhone.Name = "txtTPhone";
            this.txtTPhone.Size = new System.Drawing.Size(301, 44);
            this.txtTPhone.TabIndex = 16;
            // 
            // txtTName
            // 
            this.txtTName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTName.Location = new System.Drawing.Point(189, 185);
            this.txtTName.Multiline = true;
            this.txtTName.Name = "txtTName";
            this.txtTName.Size = new System.Drawing.Size(301, 44);
            this.txtTName.TabIndex = 15;
            // 
            // txtTID
            // 
            this.txtTID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTID.Location = new System.Drawing.Point(189, 124);
            this.txtTID.Multiline = true;
            this.txtTID.Name = "txtTID";
            this.txtTID.Size = new System.Drawing.Size(301, 44);
            this.txtTID.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(448, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Information";
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacher.Location = new System.Drawing.Point(12, 408);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.RowHeadersWidth = 51;
            this.dgvTeacher.RowTemplate.Height = 24;
            this.dgvTeacher.Size = new System.Drawing.Size(1040, 276);
            this.dgvTeacher.TabIndex = 24;
            this.dgvTeacher.SelectionChanged += new System.EventHandler(this.dgvTeacher_SelectionChanged);
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReset.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btReset.Location = new System.Drawing.Point(677, 324);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(115, 44);
            this.btReset.TabIndex = 25;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // FrmTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.dgvTeacher);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.checkNu);
            this.Controls.Add(this.checkNam);
            this.Controls.Add(this.dtDob);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTPhone);
            this.Controls.Add(this.txtTName);
            this.Controls.Add(this.txtTID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTeacher";
            this.Load += new System.EventHandler(this.FrmTeacher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.CheckBox checkNu;
        private System.Windows.Forms.CheckBox checkNam;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTPhone;
        private System.Windows.Forms.TextBox txtTName;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.Button btReset;
    }
}