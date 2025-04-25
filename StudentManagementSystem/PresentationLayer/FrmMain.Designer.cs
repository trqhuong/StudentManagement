namespace PresentationLayer
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCancel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btAttendance = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btLogout = new System.Windows.Forms.Button();
            this.btStatistical = new System.Windows.Forms.Button();
            this.btSchedule = new System.Windows.Forms.Button();
            this.btSubject = new System.Windows.Forms.Button();
            this.btClass = new System.Windows.Forms.Button();
            this.btTeacher = new System.Windows.Forms.Button();
            this.btStudent = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnbody = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnbody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-4, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1356, 56);
            this.panel1.TabIndex = 0;
            // 
            // lbCancel
            // 
            this.lbCancel.BackColor = System.Drawing.Color.White;
            this.lbCancel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbCancel.Location = new System.Drawing.Point(1289, 7);
            this.lbCancel.Name = "lbCancel";
            this.lbCancel.Size = new System.Drawing.Size(43, 41);
            this.lbCancel.TabIndex = 2;
            this.lbCancel.Text = "X";
            this.lbCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCancel.Click += new System.EventHandler(this.lbCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(513, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Management System";
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLeft.Controls.Add(this.btAttendance);
            this.pnLeft.Controls.Add(this.pictureBox2);
            this.pnLeft.Controls.Add(this.lbName);
            this.pnLeft.Controls.Add(this.btLogout);
            this.pnLeft.Controls.Add(this.btStatistical);
            this.pnLeft.Controls.Add(this.btSchedule);
            this.pnLeft.Controls.Add(this.btSubject);
            this.pnLeft.Controls.Add(this.btClass);
            this.pnLeft.Controls.Add(this.btTeacher);
            this.pnLeft.Controls.Add(this.btStudent);
            this.pnLeft.Location = new System.Drawing.Point(-4, 52);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(265, 722);
            this.pnLeft.TabIndex = 1;
            // 
            // btAttendance
            // 
            this.btAttendance.BackColor = System.Drawing.Color.White;
            this.btAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAttendance.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btAttendance.FlatAppearance.BorderSize = 0;
            this.btAttendance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btAttendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAttendance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btAttendance.Location = new System.Drawing.Point(25, 432);
            this.btAttendance.Name = "btAttendance";
            this.btAttendance.Size = new System.Drawing.Size(216, 50);
            this.btAttendance.TabIndex = 5;
            this.btAttendance.Text = "Attendance";
            this.btAttendance.UseVisualStyleBackColor = false;
            this.btAttendance.Click += new System.EventHandler(this.btAttendance_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(78, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbName.Location = new System.Drawing.Point(96, 117);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(78, 29);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btLogout
            // 
            this.btLogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLogout.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogout.ForeColor = System.Drawing.Color.White;
            this.btLogout.Location = new System.Drawing.Point(25, 648);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(216, 50);
            this.btLogout.TabIndex = 2;
            this.btLogout.Text = "Log Out";
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // btStatistical
            // 
            this.btStatistical.BackColor = System.Drawing.Color.White;
            this.btStatistical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStatistical.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btStatistical.FlatAppearance.BorderSize = 0;
            this.btStatistical.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btStatistical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btStatistical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStatistical.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btStatistical.Location = new System.Drawing.Point(25, 570);
            this.btStatistical.Name = "btStatistical";
            this.btStatistical.Size = new System.Drawing.Size(216, 50);
            this.btStatistical.TabIndex = 2;
            this.btStatistical.Text = "Statistical report";
            this.btStatistical.UseVisualStyleBackColor = false;
            this.btStatistical.Click += new System.EventHandler(this.btStatistical_Click);
            // 
            // btSchedule
            // 
            this.btSchedule.BackColor = System.Drawing.Color.White;
            this.btSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSchedule.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btSchedule.FlatAppearance.BorderSize = 0;
            this.btSchedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSchedule.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btSchedule.Location = new System.Drawing.Point(25, 502);
            this.btSchedule.Name = "btSchedule";
            this.btSchedule.Size = new System.Drawing.Size(216, 50);
            this.btSchedule.TabIndex = 2;
            this.btSchedule.Text = "Teaching Schedule";
            this.btSchedule.UseVisualStyleBackColor = false;
            this.btSchedule.Click += new System.EventHandler(this.btSchedule_Click);
            // 
            // btSubject
            // 
            this.btSubject.BackColor = System.Drawing.Color.White;
            this.btSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSubject.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btSubject.FlatAppearance.BorderSize = 0;
            this.btSubject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btSubject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSubject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btSubject.Location = new System.Drawing.Point(25, 364);
            this.btSubject.Name = "btSubject";
            this.btSubject.Size = new System.Drawing.Size(216, 50);
            this.btSubject.TabIndex = 2;
            this.btSubject.Text = "Subject";
            this.btSubject.UseVisualStyleBackColor = false;
            this.btSubject.Click += new System.EventHandler(this.btSubject_Click);
            // 
            // btClass
            // 
            this.btClass.BackColor = System.Drawing.Color.White;
            this.btClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClass.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btClass.FlatAppearance.BorderSize = 0;
            this.btClass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btClass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClass.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btClass.Location = new System.Drawing.Point(25, 295);
            this.btClass.Name = "btClass";
            this.btClass.Size = new System.Drawing.Size(216, 50);
            this.btClass.TabIndex = 2;
            this.btClass.Text = "Class";
            this.btClass.UseVisualStyleBackColor = false;
            this.btClass.Click += new System.EventHandler(this.btClass_Click);
            // 
            // btTeacher
            // 
            this.btTeacher.BackColor = System.Drawing.Color.White;
            this.btTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTeacher.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btTeacher.FlatAppearance.BorderSize = 0;
            this.btTeacher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btTeacher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTeacher.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btTeacher.Location = new System.Drawing.Point(25, 228);
            this.btTeacher.Name = "btTeacher";
            this.btTeacher.Size = new System.Drawing.Size(216, 50);
            this.btTeacher.TabIndex = 2;
            this.btTeacher.Text = "Teacher";
            this.btTeacher.UseVisualStyleBackColor = false;
            this.btTeacher.Click += new System.EventHandler(this.btTeacher_Click);
            // 
            // btStudent
            // 
            this.btStudent.BackColor = System.Drawing.Color.White;
            this.btStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStudent.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btStudent.FlatAppearance.BorderSize = 0;
            this.btStudent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStudent.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btStudent.Location = new System.Drawing.Point(25, 160);
            this.btStudent.Name = "btStudent";
            this.btStudent.Size = new System.Drawing.Size(216, 50);
            this.btStudent.TabIndex = 2;
            this.btStudent.Text = "Student";
            this.btStudent.UseVisualStyleBackColor = false;
            this.btStudent.Click += new System.EventHandler(this.btStudent_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(360, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pnbody
            // 
            this.pnbody.Controls.Add(this.pictureBox1);
            this.pnbody.Location = new System.Drawing.Point(267, 56);
            this.pnbody.Name = "pnbody";
            this.pnbody.Size = new System.Drawing.Size(1076, 718);
            this.pnbody.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1346, 775);
            this.Controls.Add(this.pnbody);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnbody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStudent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btSubject;
        private System.Windows.Forms.Button btClass;
        private System.Windows.Forms.Button btTeacher;
        private System.Windows.Forms.Button btSchedule;
        private System.Windows.Forms.Button btStatistical;
        private System.Windows.Forms.Label lbCancel;
        private System.Windows.Forms.Panel pnbody;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btAttendance;
        private System.Windows.Forms.Button btLogout;
    }
}