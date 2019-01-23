namespace ClassSys
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtStu = new System.Windows.Forms.TextBox();
            this.btnStu = new System.Windows.Forms.Button();
            this.cbStu = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Del = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCur = new System.Windows.Forms.TextBox();
            this.btnCur = new System.Windows.Forms.Button();
            this.cbCur = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTch = new System.Windows.Forms.TextBox();
            this.btnTch = new System.Windows.Forms.Button();
            this.cbTch = new System.Windows.Forms.ComboBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView5 = new System.Windows.Forms.ListView();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.btnDept = new System.Windows.Forms.Button();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.txtSct = new System.Windows.Forms.TextBox();
            this.btnSct = new System.Windows.Forms.Button();
            this.cbSct = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnInit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 362);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtStu);
            this.tabPage1.Controls.Add(this.btnStu);
            this.tabPage1.Controls.Add(this.cbStu);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "学生信息表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtStu
            // 
            this.txtStu.Location = new System.Drawing.Point(81, 2);
            this.txtStu.Name = "txtStu";
            this.txtStu.Size = new System.Drawing.Size(111, 21);
            this.txtStu.TabIndex = 3;
            // 
            // btnStu
            // 
            this.btnStu.Location = new System.Drawing.Point(198, 3);
            this.btnStu.Name = "btnStu";
            this.btnStu.Size = new System.Drawing.Size(64, 21);
            this.btnStu.TabIndex = 2;
            this.btnStu.Text = "查询";
            this.btnStu.UseVisualStyleBackColor = true;
            this.btnStu.Click += new System.EventHandler(this.btnStu_Click);
            // 
            // cbStu
            // 
            this.cbStu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStu.FormattingEnabled = true;
            this.cbStu.Location = new System.Drawing.Point(4, 3);
            this.cbStu.Name = "cbStu";
            this.cbStu.Size = new System.Drawing.Size(71, 20);
            this.cbStu.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.ContextMenuStrip = this.menu;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(587, 305);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add,
            this.Del,
            this.Edit});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(101, 70);
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(100, 22);
            this.Add.Text = "添加";
            // 
            // Del
            // 
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(100, 22);
            this.Del.Text = "删除";
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(100, 22);
            this.Edit.Text = "编辑";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCur);
            this.tabPage2.Controls.Add(this.btnCur);
            this.tabPage2.Controls.Add(this.cbCur);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "课程信息表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCur
            // 
            this.txtCur.Location = new System.Drawing.Point(81, 2);
            this.txtCur.Name = "txtCur";
            this.txtCur.Size = new System.Drawing.Size(111, 21);
            this.txtCur.TabIndex = 6;
            // 
            // btnCur
            // 
            this.btnCur.Location = new System.Drawing.Point(198, 3);
            this.btnCur.Name = "btnCur";
            this.btnCur.Size = new System.Drawing.Size(64, 21);
            this.btnCur.TabIndex = 5;
            this.btnCur.Text = "查询";
            this.btnCur.UseVisualStyleBackColor = true;
            this.btnCur.Click += new System.EventHandler(this.btnCur_Click);
            // 
            // cbCur
            // 
            this.cbCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCur.FormattingEnabled = true;
            this.cbCur.Location = new System.Drawing.Point(4, 3);
            this.cbCur.Name = "cbCur";
            this.cbCur.Size = new System.Drawing.Size(71, 20);
            this.cbCur.TabIndex = 4;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.ContextMenuStrip = this.menu;
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(3, 28);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(587, 305);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTch);
            this.tabPage3.Controls.Add(this.btnTch);
            this.tabPage3.Controls.Add(this.cbTch);
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(593, 336);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "教师信息表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTch
            // 
            this.txtTch.Location = new System.Drawing.Point(81, 2);
            this.txtTch.Name = "txtTch";
            this.txtTch.Size = new System.Drawing.Size(111, 21);
            this.txtTch.TabIndex = 6;
            // 
            // btnTch
            // 
            this.btnTch.Location = new System.Drawing.Point(198, 3);
            this.btnTch.Name = "btnTch";
            this.btnTch.Size = new System.Drawing.Size(64, 21);
            this.btnTch.TabIndex = 5;
            this.btnTch.Text = "查询";
            this.btnTch.UseVisualStyleBackColor = true;
            this.btnTch.Click += new System.EventHandler(this.btnTch_Click);
            // 
            // cbTch
            // 
            this.cbTch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTch.FormattingEnabled = true;
            this.cbTch.Location = new System.Drawing.Point(4, 3);
            this.cbTch.Name = "cbTch";
            this.cbTch.Size = new System.Drawing.Size(71, 20);
            this.cbTch.TabIndex = 4;
            // 
            // listView3
            // 
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.ContextMenuStrip = this.menu;
            this.listView3.FullRowSelect = true;
            this.listView3.Location = new System.Drawing.Point(3, 28);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(587, 305);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView3_MouseClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtDept);
            this.tabPage4.Controls.Add(this.btnDept);
            this.tabPage4.Controls.Add(this.cbDept);
            this.tabPage4.Controls.Add(this.listView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(593, 336);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "院系信息表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            this.listView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView4.ContextMenuStrip = this.menu;
            this.listView4.FullRowSelect = true;
            this.listView4.Location = new System.Drawing.Point(3, 28);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(587, 305);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            this.listView4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView4_MouseClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtSct);
            this.tabPage5.Controls.Add(this.btnSct);
            this.tabPage5.Controls.Add(this.cbSct);
            this.tabPage5.Controls.Add(this.listView5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(593, 336);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "选课信息表";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView5
            // 
            this.listView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView5.ContextMenuStrip = this.menu;
            this.listView5.FullRowSelect = true;
            this.listView5.Location = new System.Drawing.Point(3, 28);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(587, 305);
            this.listView5.TabIndex = 1;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            this.listView5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView5_MouseClick);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(81, 2);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(111, 21);
            this.txtDept.TabIndex = 9;
            // 
            // btnDept
            // 
            this.btnDept.Location = new System.Drawing.Point(198, 3);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(64, 21);
            this.btnDept.TabIndex = 8;
            this.btnDept.Text = "查询";
            this.btnDept.UseVisualStyleBackColor = true;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(4, 3);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(71, 20);
            this.cbDept.TabIndex = 7;
            // 
            // txtSct
            // 
            this.txtSct.Location = new System.Drawing.Point(81, 2);
            this.txtSct.Name = "txtSct";
            this.txtSct.Size = new System.Drawing.Size(111, 21);
            this.txtSct.TabIndex = 12;
            // 
            // btnSct
            // 
            this.btnSct.Location = new System.Drawing.Point(198, 3);
            this.btnSct.Name = "btnSct";
            this.btnSct.Size = new System.Drawing.Size(64, 21);
            this.btnSct.TabIndex = 11;
            this.btnSct.Text = "查询";
            this.btnSct.UseVisualStyleBackColor = true;
            this.btnSct.Click += new System.EventHandler(this.btnSct_Click);
            // 
            // cbSct
            // 
            this.cbSct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSct.FormattingEnabled = true;
            this.cbSct.Location = new System.Drawing.Point(4, 3);
            this.cbSct.Name = "cbSct";
            this.cbSct.Size = new System.Drawing.Size(71, 20);
            this.cbSct.TabIndex = 10;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pictureBox1);
            this.tabPage6.Controls.Add(this.btnInit);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(593, 336);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "其他";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(235, 306);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(114, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "重新初始化数据";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(168, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 364);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "学生选课管理系统";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.TextBox txtStu;
        private System.Windows.Forms.Button btnStu;
        private System.Windows.Forms.ComboBox cbStu;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ToolStripMenuItem Del;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.TextBox txtCur;
        private System.Windows.Forms.Button btnCur;
        private System.Windows.Forms.ComboBox cbCur;
        private System.Windows.Forms.TextBox txtTch;
        private System.Windows.Forms.Button btnTch;
        private System.Windows.Forms.ComboBox cbTch;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Button btnDept;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.TextBox txtSct;
        private System.Windows.Forms.Button btnSct;
        private System.Windows.Forms.ComboBox cbSct;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

