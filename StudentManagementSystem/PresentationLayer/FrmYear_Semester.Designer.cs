namespace PresentationLayer
{
    partial class FrmYear_Semester
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
            this.btEnd = new System.Windows.Forms.Button();
            this.dgvYear = new System.Windows.Forms.DataGridView();
            this.dgvSemester = new System.Windows.Forms.DataGridView();
            this.lbYear = new System.Windows.Forms.Label();
            this.lbSemester = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemester)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEnd
            // 
            this.btEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btEnd.Location = new System.Drawing.Point(864, 122);
            this.btEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(169, 55);
            this.btEnd.TabIndex = 0;
            this.btEnd.Text = "End";
            this.btEnd.UseVisualStyleBackColor = true;
            this.btEnd.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // dgvYear
            // 
            this.dgvYear.BackgroundColor = System.Drawing.Color.White;
            this.dgvYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYear.Location = new System.Drawing.Point(46, 238);
            this.dgvYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvYear.Name = "dgvYear";
            this.dgvYear.RowHeadersWidth = 62;
            this.dgvYear.RowTemplate.Height = 28;
            this.dgvYear.Size = new System.Drawing.Size(529, 346);
            this.dgvYear.TabIndex = 1;
            // 
            // dgvSemester
            // 
            this.dgvSemester.BackgroundColor = System.Drawing.Color.White;
            this.dgvSemester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemester.Location = new System.Drawing.Point(614, 238);
            this.dgvSemester.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSemester.Name = "dgvSemester";
            this.dgvSemester.RowHeadersWidth = 62;
            this.dgvSemester.RowTemplate.Height = 28;
            this.dgvSemester.Size = new System.Drawing.Size(536, 346);
            this.dgvSemester.TabIndex = 1;
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYear.ForeColor = System.Drawing.Color.White;
            this.lbYear.Location = new System.Drawing.Point(288, 132);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(150, 32);
            this.lbYear.TabIndex = 2;
            this.lbYear.Text = "Năm học: ";
            // 
            // lbSemester
            // 
            this.lbSemester.AutoSize = true;
            this.lbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSemester.ForeColor = System.Drawing.Color.White;
            this.lbSemester.Location = new System.Drawing.Point(624, 132);
            this.lbSemester.Name = "lbSemester";
            this.lbSemester.Size = new System.Drawing.Size(107, 32);
            this.lbSemester.TabIndex = 2;
            this.lbSemester.Text = "Học kì:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1202, 81);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(375, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Year Semester Management";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmYear_Semester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1197, 886);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbSemester);
            this.Controls.Add(this.lbYear);
            this.Controls.Add(this.dgvSemester);
            this.Controls.Add(this.dgvYear);
            this.Controls.Add(this.btEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmYear_Semester";
            this.Text = "FrmYear_Semester";
            this.Load += new System.EventHandler(this.FrmYear_Semester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemester)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEnd;
        private System.Windows.Forms.DataGridView dgvYear;
        private System.Windows.Forms.DataGridView dgvSemester;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbSemester;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}