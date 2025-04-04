namespace PresentationLayer
{
    partial class FrmOnboarding
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOnboarding));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.pn1 = new System.Windows.Forms.Panel();
            this.pn2 = new System.Windows.Forms.Panel();
            this.timerPanel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(289, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbName.Location = new System.Drawing.Point(201, 277);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(412, 32);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Student Management System";
            // 
            // pn1
            // 
            this.pn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn1.Controls.Add(this.pn2);
            this.pn1.Location = new System.Drawing.Point(-2, 474);
            this.pn1.Name = "pn1";
            this.pn1.Size = new System.Drawing.Size(803, 27);
            this.pn1.TabIndex = 2;
            // 
            // pn2
            // 
            this.pn2.BackColor = System.Drawing.Color.MidnightBlue;
            this.pn2.Location = new System.Drawing.Point(0, 0);
            this.pn2.Name = "pn2";
            this.pn2.Size = new System.Drawing.Size(203, 25);
            this.pn2.TabIndex = 3;
            // 
            // timerPanel
            // 
            this.timerPanel.Enabled = true;
            this.timerPanel.Interval = 20;
            this.timerPanel.Tick += new System.EventHandler(this.timerPanel_Tick);
            // 
            // FrmOnboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pn1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOnboarding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onboarding";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pn1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel pn1;
        private System.Windows.Forms.Panel pn2;
        private System.Windows.Forms.Timer timerPanel;
    }
}