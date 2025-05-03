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
            ((System.ComponentModel.ISupportInitialize)(this.dgvYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemester)).BeginInit();
            this.SuspendLayout();
            // 
            // btEnd
            // 
            this.btEnd.Location = new System.Drawing.Point(476, 38);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(169, 50);
            this.btEnd.TabIndex = 0;
            this.btEnd.Text = "End";
            this.btEnd.UseVisualStyleBackColor = true;
            this.btEnd.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // dgvYear
            // 
            this.dgvYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYear.Location = new System.Drawing.Point(70, 155);
            this.dgvYear.Name = "dgvYear";
            this.dgvYear.RowHeadersWidth = 62;
            this.dgvYear.RowTemplate.Height = 28;
            this.dgvYear.Size = new System.Drawing.Size(240, 150);
            this.dgvYear.TabIndex = 1;
            // 
            // dgvSemester
            // 
            this.dgvSemester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemester.Location = new System.Drawing.Point(442, 155);
            this.dgvSemester.Name = "dgvSemester";
            this.dgvSemester.RowHeadersWidth = 62;
            this.dgvSemester.RowTemplate.Height = 28;
            this.dgvSemester.Size = new System.Drawing.Size(240, 150);
            this.dgvSemester.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Năm học: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Học kì:";
            // 
            // FrmYear_Semester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSemester);
            this.Controls.Add(this.dgvYear);
            this.Controls.Add(this.btEnd);
            this.Name = "FrmYear_Semester";
            this.Text = "FrmYear_Semester";
            ((System.ComponentModel.ISupportInitialize)(this.dgvYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemester)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEnd;
        private System.Windows.Forms.DataGridView dgvYear;
        private System.Windows.Forms.DataGridView dgvSemester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}