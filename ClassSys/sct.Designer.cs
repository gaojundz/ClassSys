namespace ClassSys
{
    partial class sct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGUID = new System.Windows.Forms.TextBox();
            this.cbsno = new System.Windows.Forms.ComboBox();
            this.cbcno = new System.Windows.Forms.ComboBox();
            this.cbtno = new System.Windows.Forms.ComboBox();
            this.txtgrade = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "GUID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "学号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "课程号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "教工号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "成绩";
            // 
            // txtGUID
            // 
            this.txtGUID.Enabled = false;
            this.txtGUID.Location = new System.Drawing.Point(88, 20);
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.Size = new System.Drawing.Size(223, 21);
            this.txtGUID.TabIndex = 5;
            // 
            // cbsno
            // 
            this.cbsno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsno.FormattingEnabled = true;
            this.cbsno.Location = new System.Drawing.Point(88, 47);
            this.cbsno.Name = "cbsno";
            this.cbsno.Size = new System.Drawing.Size(223, 20);
            this.cbsno.TabIndex = 6;
            // 
            // cbcno
            // 
            this.cbcno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcno.FormattingEnabled = true;
            this.cbcno.Location = new System.Drawing.Point(88, 78);
            this.cbcno.Name = "cbcno";
            this.cbcno.Size = new System.Drawing.Size(223, 20);
            this.cbcno.TabIndex = 7;
            // 
            // cbtno
            // 
            this.cbtno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtno.FormattingEnabled = true;
            this.cbtno.Location = new System.Drawing.Point(88, 104);
            this.cbtno.Name = "cbtno";
            this.cbtno.Size = new System.Drawing.Size(223, 20);
            this.cbtno.TabIndex = 8;
            // 
            // txtgrade
            // 
            this.txtgrade.Location = new System.Drawing.Point(88, 138);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(121, 21);
            this.txtgrade.TabIndex = 9;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(88, 174);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(73, 23);
            this.save.TabIndex = 10;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(236, 174);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // sct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 219);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.txtgrade);
            this.Controls.Add(this.cbtno);
            this.Controls.Add(this.cbcno);
            this.Controls.Add(this.cbsno);
            this.Controls.Add(this.txtGUID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "sct";
            this.Text = "选课信息";
            this.Load += new System.EventHandler(this.sct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGUID;
        private System.Windows.Forms.ComboBox cbsno;
        private System.Windows.Forms.ComboBox cbcno;
        private System.Windows.Forms.ComboBox cbtno;
        private System.Windows.Forms.TextBox txtgrade;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
    }
}