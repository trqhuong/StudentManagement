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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btEnd.Location = new System.Drawing.Point(719, 201);
            this.btEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(150, 44);
            this.btEnd.TabIndex = 0;
            this.btEnd.Text = "End";
            this.btEnd.UseVisualStyleBackColor = true;
            this.btEnd.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // dgvYear
            // 
            this.dgvYear.BackgroundColor = System.Drawing.Color.White;
            this.dgvYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYear.Location = new System.Drawing.Point(115, 328);
            this.dgvYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvYear.Name = "dgvYear";
            this.dgvYear.RowHeadersWidth = 62;
            this.dgvYear.RowTemplate.Height = 28;
            this.dgvYear.Size = new System.Drawing.Size(245, 120);
            this.dgvYear.TabIndex = 1;
            // 
            // dgvSemester
            // 
            this.dgvSemester.BackgroundColor = System.Drawing.Color.White;
            this.dgvSemester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemester.Location = new System.Drawing.Point(585, 328);
            this.dgvSemester.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSemester.Name = "dgvSemester";
            this.dgvSemester.RowHeadersWidth = 62;
            this.dgvSemester.RowTemplate.Height = 28;
            this.dgvSemester.Size = new System.Drawing.Size(213, 120);
            this.dgvSemester.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(307, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Năm học: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(603, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Học kì:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 65);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(372, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Semester Management";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmYear_Semester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSemester);
            this.Controls.Add(this.dgvYear);
            this.Controls.Add(this.btEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmYear_Semester";
            this.Text = "FrmYear_Semester";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}