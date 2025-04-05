namespace PresentationLayer
{
    partial class FrmSubject
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
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 65);
            this.panel1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(401, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSubject
            // 
            this.dgvSubject.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubject.Location = new System.Drawing.Point(10, 511);
            this.dgvSubject.Name = "dgvSubject";
            this.dgvSubject.RowHeadersWidth = 51;
            this.dgvSubject.RowTemplate.Height = 24;
            this.dgvSubject.Size = new System.Drawing.Size(1040, 185);
            this.dgvSubject.TabIndex = 53;
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
            this.btDelete.Location = new System.Drawing.Point(912, 443);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(115, 44);
            this.btDelete.TabIndex = 49;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
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
            this.btUpdate.Location = new System.Drawing.Point(773, 443);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(115, 44);
            this.btUpdate.TabIndex = 50;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
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
            this.btAdd.Location = new System.Drawing.Point(634, 443);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(115, 44);
            this.btAdd.TabIndex = 51;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
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
            this.btSave.Location = new System.Drawing.Point(495, 443);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(115, 44);
            this.btSave.TabIndex = 52;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(490, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "SubjectName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(490, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 45;
            this.label3.Text = "SubjectID:";
            // 
            // txtSID
            // 
            this.txtSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSID.Location = new System.Drawing.Point(645, 136);
            this.txtSID.Multiline = true;
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(382, 44);
            this.txtSID.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(744, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Information";
            // 
            // txtSName
            // 
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSName.Location = new System.Drawing.Point(645, 197);
            this.txtSName.Multiline = true;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(382, 44);
            this.txtSName.TabIndex = 48;
            // 
            // FrmSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSubject);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSubject";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSName;
    }
}