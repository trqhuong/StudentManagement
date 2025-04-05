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
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btSemester = new System.Windows.Forms.Button();
            this.bt1per = new System.Windows.Forms.Button();
            this.bt15min = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInput
            // 
            this.dgvInput.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Location = new System.Drawing.Point(12, 285);
            this.dgvInput.Name = "dgvInput";
            this.dgvInput.RowHeadersWidth = 51;
            this.dgvInput.RowTemplate.Height = 24;
            this.dgvInput.Size = new System.Drawing.Size(1040, 412);
            this.dgvInput.TabIndex = 11;
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
            this.label1.Size = new System.Drawing.Size(199, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Grades";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSemester
            // 
            this.btSemester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSemester.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btSemester.FlatAppearance.BorderSize = 0;
            this.btSemester.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btSemester.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSemester.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btSemester.Location = new System.Drawing.Point(663, 190);
            this.btSemester.Name = "btSemester";
            this.btSemester.Size = new System.Drawing.Size(179, 44);
            this.btSemester.TabIndex = 12;
            this.btSemester.Text = "Semester exam";
            this.btSemester.UseVisualStyleBackColor = true;
            // 
            // bt1per
            // 
            this.bt1per.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt1per.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.bt1per.FlatAppearance.BorderSize = 0;
            this.bt1per.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.bt1per.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.bt1per.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1per.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt1per.Location = new System.Drawing.Point(452, 190);
            this.bt1per.Name = "bt1per";
            this.bt1per.Size = new System.Drawing.Size(179, 44);
            this.bt1per.TabIndex = 13;
            this.bt1per.Text = "1 period";
            this.bt1per.UseVisualStyleBackColor = true;
            // 
            // bt15min
            // 
            this.bt15min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt15min.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.bt15min.FlatAppearance.BorderSize = 0;
            this.bt15min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.bt15min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.bt15min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt15min.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt15min.Location = new System.Drawing.Point(241, 190);
            this.bt15min.Name = "bt15min";
            this.bt15min.Size = new System.Drawing.Size(179, 44);
            this.bt15min.TabIndex = 14;
            this.bt15min.Text = "15 minutes";
            this.bt15min.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(365, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Class:";
            // 
            // cbbClass
            // 
            this.cbbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(453, 118);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(226, 33);
            this.cbbClass.TabIndex = 15;
            // 
            // FrmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbClass);
            this.Controls.Add(this.btSemester);
            this.Controls.Add(this.bt1per);
            this.Controls.Add(this.bt15min);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInput";
            this.Text = "FrmInput";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSemester;
        private System.Windows.Forms.Button bt1per;
        private System.Windows.Forms.Button bt15min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbClass;
    }
}