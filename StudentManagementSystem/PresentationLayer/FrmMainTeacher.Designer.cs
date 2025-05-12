namespace PresentationLayer
{
    partial class FrmMainTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainTeacher));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCancel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btLogout = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btExport = new System.Windows.Forms.Button();
            this.btInput = new System.Windows.Forms.Button();
            this.btList = new System.Windows.Forms.Button();
            this.pnbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnbody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-8, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1356, 60);
            this.panel1.TabIndex = 1;
            // 
            // lbCancel
            // 
            this.lbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCancel.BackColor = System.Drawing.Color.White;
            this.lbCancel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbCancel.Location = new System.Drawing.Point(1294, 8);
            this.lbCancel.Name = "lbCancel";
            this.lbCancel.Size = new System.Drawing.Size(44, 42);
            this.lbCancel.TabIndex = 2;
            this.lbCancel.Text = "X";
            this.lbCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCancel.Click += new System.EventHandler(this.lbCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(514, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Management System";
            // 
            // pnLeft
            // 
            this.pnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnLeft.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLeft.Controls.Add(this.btLogout);
            this.pnLeft.Controls.Add(this.lbName);
            this.pnLeft.Controls.Add(this.pictureBox2);
            this.pnLeft.Controls.Add(this.btExport);
            this.pnLeft.Controls.Add(this.btInput);
            this.pnLeft.Controls.Add(this.btList);
            this.pnLeft.Location = new System.Drawing.Point(-8, 55);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(268, 730);
            this.pnLeft.TabIndex = 2;
            // 
            // btLogout
            // 
            this.btLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btLogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLogout.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogout.ForeColor = System.Drawing.Color.White;
            this.btLogout.Location = new System.Drawing.Point(29, 617);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(216, 50);
            this.btLogout.TabIndex = 4;
            this.btLogout.Text = "Log Out";
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbName.Location = new System.Drawing.Point(97, 172);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(78, 29);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(60, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 161);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btExport
            // 
            this.btExport.BackColor = System.Drawing.Color.White;
            this.btExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExport.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btExport.FlatAppearance.BorderSize = 0;
            this.btExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExport.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btExport.Location = new System.Drawing.Point(29, 399);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(216, 50);
            this.btExport.TabIndex = 2;
            this.btExport.Text = "Export grades";
            this.btExport.UseVisualStyleBackColor = false;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // btInput
            // 
            this.btInput.BackColor = System.Drawing.Color.White;
            this.btInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInput.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btInput.FlatAppearance.BorderSize = 0;
            this.btInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInput.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btInput.Location = new System.Drawing.Point(29, 332);
            this.btInput.Name = "btInput";
            this.btInput.Size = new System.Drawing.Size(216, 50);
            this.btInput.TabIndex = 2;
            this.btInput.Text = "Input grades";
            this.btInput.UseVisualStyleBackColor = false;
            this.btInput.Click += new System.EventHandler(this.btInput_Click);
            // 
            // btList
            // 
            this.btList.BackColor = System.Drawing.Color.White;
            this.btList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btList.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btList.FlatAppearance.BorderSize = 0;
            this.btList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btList.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btList.Location = new System.Drawing.Point(29, 264);
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(216, 50);
            this.btList.TabIndex = 2;
            this.btList.Text = "Class lists";
            this.btList.UseVisualStyleBackColor = false;
            this.btList.Click += new System.EventHandler(this.btList_Click);
            // 
            // pnbody
            // 
            this.pnbody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnbody.Controls.Add(this.pictureBox1);
            this.pnbody.Location = new System.Drawing.Point(260, 55);
            this.pnbody.Name = "pnbody";
            this.pnbody.Size = new System.Drawing.Size(1088, 730);
            this.pnbody.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(361, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMainTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1346, 775);
            this.Controls.Add(this.pnbody);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMainTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainTeacher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMainTeacher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btInput;
        private System.Windows.Forms.Button btList;
        private System.Windows.Forms.Panel pnbody;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btLogout;
    }
}