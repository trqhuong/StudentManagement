namespace PresentationLayer
{
    partial class FrmClass
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
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCNumber = new System.Windows.Forms.TextBox();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCTID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btReset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbGrade = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClass
            // 
            this.dgvClass.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass.Location = new System.Drawing.Point(11, 500);
            this.dgvClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.RowHeadersWidth = 51;
            this.dgvClass.RowTemplate.Height = 24;
            this.dgvClass.Size = new System.Drawing.Size(1170, 370);
            this.dgvClass.TabIndex = 42;
            this.dgvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellContentClick);
            this.dgvClass.SelectionChanged += new System.EventHandler(this.dgvClass_SelectionChanged);
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
            this.btDelete.Location = new System.Drawing.Point(616, 376);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(129, 55);
            this.btDelete.TabIndex = 9;
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
            this.btUpdate.Location = new System.Drawing.Point(460, 376);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(129, 55);
            this.btUpdate.TabIndex = 8;
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
            this.btAdd.Location = new System.Drawing.Point(304, 376);
            this.btAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(129, 55);
            this.btAdd.TabIndex = 7;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(615, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 29);
            this.label5.TabIndex = 27;
            this.label5.Text = "Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(36, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "ClassName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 29;
            this.label3.Text = "ClassID:";
            // 
            // txtCNumber
            // 
            this.txtCNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNumber.Location = new System.Drawing.Point(790, 175);
            this.txtCNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCNumber.Multiline = true;
            this.txtCNumber.Name = "txtCNumber";
            this.txtCNumber.Size = new System.Drawing.Size(342, 54);
            this.txtCNumber.TabIndex = 3;
            // 
            // txtCID
            // 
            this.txtCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCID.Location = new System.Drawing.Point(210, 175);
            this.txtCID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCID.Multiline = true;
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new System.Drawing.Size(342, 54);
            this.txtCID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(524, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 32);
            this.label2.TabIndex = 30;
            this.label2.Text = "Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(451, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(210, 251);
            this.txtCName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCName.Multiline = true;
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(342, 54);
            this.txtCName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1201, 81);
            this.panel1.TabIndex = 25;
            // 
            // txtCTID
            // 
            this.txtCTID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTID.Location = new System.Drawing.Point(790, 251);
            this.txtCTID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCTID.Multiline = true;
            this.txtCTID.Name = "txtCTID";
            this.txtCTID.Size = new System.Drawing.Size(342, 54);
            this.txtCTID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(615, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 29);
            this.label6.TabIndex = 29;
            this.label6.Text = "TeacherID:";
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReset.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btReset.Location = new System.Drawing.Point(774, 376);
            this.btReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(129, 55);
            this.btReset.TabIndex = 55;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(36, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 29);
            this.label7.TabIndex = 28;
            this.label7.Text = "ClassGrade:";
            // 
            // cbbGrade
            // 
            this.cbbGrade.FormattingEnabled = true;
            this.cbbGrade.Location = new System.Drawing.Point(210, 336);
            this.cbbGrade.Name = "cbbGrade";
            this.cbbGrade.Size = new System.Drawing.Size(191, 28);
            this.cbbGrade.TabIndex = 56;
            // 
            // FrmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1197, 886);
            this.Controls.Add(this.cbbGrade);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.dgvClass);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCNumber);
            this.Controls.Add(this.txtCTID);
            this.Controls.Add(this.txtCID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClass";
            this.Load += new System.EventHandler(this.FrmClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCNumber;
        private System.Windows.Forms.TextBox txtCID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCTID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbGrade;
    }
}