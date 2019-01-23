/** @file      Form1.cs
*   @note      gaojundz@qq.com 微信qq 124099929
*   @brief     学生选课信息管理作业
*   @author    gaojun
*   @date      2018/12/09
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sqlite;
using System.Data.SQLite;
using System.IO;

namespace ClassSys
{
    public partial class Form1 : Form
    {
        private static SqLiteHelper sql;
        int tabPage = 0;
        string SelectNO = "";
        string SelectCon = "";
        public Form1()
        {
            InitializeComponent();
            //--------------------初始化数据库-----------------------
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            //创建名为table1的数据表
            //sql.CreateTable("table1", new string[] { "BarCode", "Num", "Weight", "Volume", "Time", "UploadStatus" }, new string[] { "TEXT PRIMARY KEY", "INTEGER", "TEXT", "TEXT", "TEXT", "TEXT" });
            sql.CreateTable("student", new string[] { "sno", "sname", "ssex", "sage", "sdept"}, new string[] { "TEXT PRIMARY KEY",  "TEXT", "TEXT", "TEXT", "TEXT" });
            sql.CreateTable("course", new string[] { "cno", "cname", "cpno", "ccredit" }, new string[] { "TEXT PRIMARY KEY", "TEXT", "TEXT", "TEXT" });
            sql.CreateTable("teacher", new string[] { "tno", "tname", "tsex", "tage", "teb", "tpt", "cno1", "cno2", "cno3" }, new string[] { "TEXT PRIMARY KEY", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT" });
            sql.CreateTable("department", new string[] { "dno", "dname", "dmanager"}, new string[] { "TEXT PRIMARY KEY", "TEXT", "TEXT" });
            sql.CreateTable("sct", new string[] { "GUID", "sno", "cno", "tno", "grade" }, new string[] { "TEXT PRIMARY KEY", "TEXT", "TEXT", "TEXT", "TEXT" });
            //---------------------初始化界面-----------------------
            InitStudent();
            InitCourse();
            InitTeacher();
            InitDepartment();
            InitSct();
            //--------------------------------------------------------
        }
        //==============================选课信息表=====================================================
        public void InitSct()
        {
            string[] cbx = new string[] { "所有", "学号", "课程号", "教工号","成绩"};
            for (int i = 0; i < cbx.Length; i++)
            {
                cbSct.Items.Add(cbx[i]);
            }
            cbSct.SelectedIndex = 0;

            listView5.Columns.Add("序号", 40, HorizontalAlignment.Left);
            listView5.Columns.Add("GUID", 60, HorizontalAlignment.Left);
            listView5.Columns.Add("学号", 120, HorizontalAlignment.Left);
            listView5.Columns.Add("课程号", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("教工号", 120, HorizontalAlignment.Left);
            listView5.Columns.Add("成绩", 60, HorizontalAlignment.Left);

            ReadAllSct();
        }
        public void ReadAllSct()
        {
            //------------------------------------------------------------------------------------
            listView5.BeginUpdate();
            listView5.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ReadFullTable("sct");
            while (reader.Read())
            {
                int no = listView5.Items.Count;
                listView5.Items.Add(Convert.ToString(no + 1));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("GUID")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("grade")));
            }
            //-------------------------------------------------------------------------------
            listView5.EndUpdate();
        }
        private void listView5_MouseClick(object sender, MouseEventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
            if (e.Button == MouseButtons.Right)
            {
                if (listView5.SelectedItems.Count <= 0)
                    return;
                else
                {
                    SelectNO = listView5.SelectedItems[0].SubItems[1].Text;
                    SelectCon = listView5.SelectedItems[0].SubItems[2].Text;
                }
            }
        }
        private void btnSct_Click(object sender, EventArgs e)
        {
            string strsql = "select * from sct";
            string[] value = { "sno", "cno", "tno","grade"};
            string[] content = { "学号", "课程号", "教工号", "成绩" };
            for (int i = 0; i < content.Length; i++)
            {
                if (cbSct.Text == content[i])
                {
                    strsql += " where ";
                    strsql += value[i];
                    strsql += " like '%";
                    strsql += txtSct.Text;
                    strsql += "%'";
                    break;
                }
            }
            //MessageBox.Show(strsql);
            //------------------------------------------------------------------------------------
            listView5.BeginUpdate();
            listView5.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ExecuteQuery(strsql);
            while (reader.Read())
            {
                int no = listView5.Items.Count;
                listView5.Items.Add(Convert.ToString(no + 1));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("GUID")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tno")));
                listView5.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("grade")));
            }
            //-------------------------------------------------------------------------------
            listView5.EndUpdate();
        }
        //==============================院系信息表=====================================================
        public void InitDepartment()
        {
            string[] cbx = new string[] { "所有", "系编号", "系名", "系主任" };
            for (int i = 0; i < cbx.Length; i++)
            {
                cbDept.Items.Add(cbx[i]);
            }
            cbDept.SelectedIndex = 0;

            listView4.Columns.Add("序号", 40, HorizontalAlignment.Left);
            listView4.Columns.Add("系编号", 60, HorizontalAlignment.Left);
            listView4.Columns.Add("系名", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("系主任", 100, HorizontalAlignment.Left);
            
            ReadAllDept();
        }
        public void ReadAllDept()
        {
            //------------------------------------------------------------------------------------
            listView4.BeginUpdate();
            listView4.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ReadFullTable("department");
            while (reader.Read())
            {
                int no = listView4.Items.Count;
                listView4.Items.Add(Convert.ToString(no + 1));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dno")));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dname")));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dmanager")));
            }
            //-------------------------------------------------------------------------------
            listView4.EndUpdate();
        }
        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
            if (e.Button == MouseButtons.Right)
            {
                if (listView4.SelectedItems.Count <= 0)
                    return;
                else
                {
                    SelectNO = listView4.SelectedItems[0].SubItems[1].Text;
                    SelectCon = listView4.SelectedItems[0].SubItems[2].Text;
                }
            }
        }
        private void btnDept_Click(object sender, EventArgs e)
        {
            string strsql = "select * from department";
            string[] value = { "dno", "dname", "dmanager"};
            string[] content = { "系编号", "系名", "系主任" };
            for (int i = 0; i < content.Length; i++)
            {
                if (cbDept.Text == content[i])
                {
                    strsql += " where ";
                    strsql += value[i];
                    strsql += " like '%";
                    strsql += txtDept.Text;
                    strsql += "%'";
                    break;
                }
            }
            //MessageBox.Show(strsql);
            //------------------------------------------------------------------------------------
            listView4.BeginUpdate();
            listView4.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ExecuteQuery(strsql);
            while (reader.Read())
            {
                int no = listView4.Items.Count;
                listView4.Items.Add(Convert.ToString(no + 1));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dno")));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dname")));
                listView4.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("dmanager")));
            }
            //-------------------------------------------------------------------------------
            listView4.EndUpdate();
        }
        //==============================教师信息表=====================================================
        public void InitTeacher()
        {
            string[] cbx = new string[] { "所有", "教工号", "姓名", "性别", "年龄", "学历", "职称", "主课一", "主课二", "主课三" };
            for (int i = 0; i < cbx.Length; i++)
            {
                cbTch.Items.Add(cbx[i]);
            }
            cbTch.SelectedIndex = 0;

            listView3.Columns.Add("序号", 40, HorizontalAlignment.Left);
            listView3.Columns.Add("教工号", 60, HorizontalAlignment.Left);
            listView3.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listView3.Columns.Add("性别", 40, HorizontalAlignment.Left);
            listView3.Columns.Add("年龄", 40, HorizontalAlignment.Left);
            listView3.Columns.Add("学历", 40, HorizontalAlignment.Left);
            listView3.Columns.Add("职称", 40, HorizontalAlignment.Left);
            listView3.Columns.Add("主课一", 80, HorizontalAlignment.Left);
            listView3.Columns.Add("主课二", 80, HorizontalAlignment.Left);
            listView3.Columns.Add("主课三", 80, HorizontalAlignment.Left);

            ReadAllTeacher();
        }
        public void ReadAllTeacher()
        {
            //------------------------------------------------------------------------------------
            listView3.BeginUpdate();
            listView3.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ReadFullTable("teacher");
            while (reader.Read())
            {
                int no = listView3.Items.Count;
                listView3.Items.Add(Convert.ToString(no + 1));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tno")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tname")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tsex")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tage")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("teb")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tpt")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno1")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno2")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno3")));
            }
            //-------------------------------------------------------------------------------
            listView3.EndUpdate();
        }
        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
            if (e.Button == MouseButtons.Right)
            {
                if (listView3.SelectedItems.Count <= 0)
                    return;
                else
                {
                    SelectNO = listView3.SelectedItems[0].SubItems[1].Text;
                    SelectCon = listView3.SelectedItems[0].SubItems[2].Text;
                }
            }
        }
        private void btnTch_Click(object sender, EventArgs e)
        {
            string strsql = "select * from teacher";
            string[] value = { "tno", "tname", "tsex", "tage","teb","tpt","cno1","cno2","cno3"};
            string[] content = { "教工号", "姓名", "性别", "年龄", "学历", "职称", "主课一", "主课二", "主课三" };
            for (int i = 0; i < content.Length; i++)
            {
                if (cbTch.Text == content[i])
                {
                    strsql += " where ";
                    strsql += value[i];
                    strsql += " like '%";
                    strsql += txtTch.Text;
                    strsql += "%'";
                    break;
                }
            }
            //MessageBox.Show(strsql);
            //------------------------------------------------------------------------------------
            listView3.BeginUpdate();
            listView3.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ExecuteQuery(strsql);
            while (reader.Read())
            {
                int no = listView3.Items.Count;
                listView3.Items.Add(Convert.ToString(no + 1));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tno")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tname")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tsex")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tage")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("teb")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("tpt")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno1")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno2")));
                listView3.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno3")));
            }
            //-------------------------------------------------------------------------------
            listView3.EndUpdate();
        }
        //==============================课程信息表=====================================================
        public void InitCourse()
        {
            string[] cbx = new string[] { "所有", "课程号", "课程名", "先行课", "学分" };
            for (int i = 0; i < cbx.Length; i++)
            {
                cbCur.Items.Add(cbx[i]);
            }
            cbCur.SelectedIndex = 0;

            listView2.Columns.Add("序号", 40, HorizontalAlignment.Left);
            listView2.Columns.Add("课程号", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("课程名", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("先行课", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("学分", 100, HorizontalAlignment.Left);

            ReadAllCourse();
        }
        public void ReadAllCourse()
        {
            //------------------------------------------------------------------------------------
            listView2.BeginUpdate();
            listView2.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ReadFullTable("course");
            while (reader.Read())
            {
                int no = listView2.Items.Count;
                listView2.Items.Add(Convert.ToString(no + 1));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cname")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cpno")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("ccredit")));
            }
            //-------------------------------------------------------------------------------
            listView2.EndUpdate();
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
            if (e.Button == MouseButtons.Right)
            {
                if (listView2.SelectedItems.Count <= 0)
                    return;
                else
                {
                    SelectNO = listView2.SelectedItems[0].SubItems[1].Text;
                    SelectCon = listView2.SelectedItems[0].SubItems[2].Text;
                }
            }
        }
        private void btnCur_Click(object sender, EventArgs e)
        {
            string strsql = "select * from course";
            string[] value = { "cno", "cname", "cpno", "ccredit" };
            string[] content = { "课程号", "课程名", "先行课", "学分" };
            for (int i = 0; i < content.Length; i++)
            {
                if (cbCur.Text == content[i])
                {
                    strsql += " where ";
                    strsql += value[i];
                    strsql += " like '%";
                    strsql += txtCur.Text;
                    strsql += "%'";
                    break;
                }
            }
            //MessageBox.Show(strsql);
            //------------------------------------------------------------------------------------
            listView2.BeginUpdate();
            listView2.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ExecuteQuery(strsql);
            while (reader.Read())
            {
                int no = listView2.Items.Count;
                listView2.Items.Add(Convert.ToString(no + 1));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cno")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cname")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("cpno")));
                listView2.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("ccredit")));
            }
            //-------------------------------------------------------------------------------
            listView2.EndUpdate();
        }
        //==============================学生信息表=====================================================
        public void InitStudent()
        {
            string[] cbx = new string[] {"所有","学号","姓名","性别","年龄","系别"};
            for (int i = 0; i < cbx.Length; i++)
            {
                cbStu.Items.Add(cbx[i]);
            }
            cbStu.SelectedIndex = 0;

            listView1.Columns.Add("序号", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("学号", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("性别", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("年龄", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("系别", 150, HorizontalAlignment.Left);

            ReadAllStudent();
        }
        public void ReadAllStudent()
        {
            //------------------------------------------------------------------------------------
            listView1.BeginUpdate();
            listView1.Items.Clear();

            //读取整张表
            SQLiteDataReader reader = sql.ReadFullTable("student");
            while (reader.Read())
            {
                int no = listView1.Items.Count;
                listView1.Items.Add(Convert.ToString(no + 1));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sno")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sname")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("ssex")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sage")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sdept")));
            }
            //-------------------------------------------------------------------------------
            listView1.EndUpdate();
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count <= 0)
                    return;
                else
                {
                    SelectNO = listView1.SelectedItems[0].SubItems[1].Text;
                    SelectCon = listView1.SelectedItems[0].SubItems[2].Text;
                }
            }
        }
        private void btnStu_Click(object sender, EventArgs e)
        {
            string strsql = "select * from student";
            string[] value = {"sno","sname","ssex","sage","sdept"};
            string[] content = {"学号","姓名","性别","年龄","系别"};
            for (int i = 0; i < content.Length; i++)
            {
                if (cbStu.Text == content[i])
                {
                    strsql += " where ";
                    strsql += value[i];
                    strsql += " like '%";
                    strsql += txtStu.Text;
                    strsql += "%'";
                    break;
                }
            }
            //MessageBox.Show(strsql);
            //------------------------------------------------------------------------------------
            listView1.BeginUpdate();
            listView1.Items.Clear();
            //读取整张表
            SQLiteDataReader reader = sql.ExecuteQuery(strsql);
            while (reader.Read())
            {
                int no = listView1.Items.Count;
                listView1.Items.Add(Convert.ToString(no + 1));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sno")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sname")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("ssex")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sage")));
                listView1.Items[no].SubItems.Add(reader.GetString(reader.GetOrdinal("sdept")));
            }
            //-------------------------------------------------------------------------------
            listView1.EndUpdate();
        }
        //==============================菜单操作=======================================================
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabPage[] _TabPage = new TabPage[] { tabPage1, tabPage2, tabPage3, tabPage4, tabPage5 };
            for (int i = 0; i < _TabPage.Length; i++)
            {
                if (e.TabPage == _TabPage[i])
                {
                    tabPage = i;
                    break;
                }
            }

            //MessageBox.Show("tabPage="+tabPage);
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加":
                    ADD(tabPage);
                    break;
                case "删除":
                    DEL(tabPage);
                    break;
                case "编辑":
                    EDIT(tabPage);
                    break;
                default:
                    break;
            }
        }

        private void ADD(int tab)
        {
            switch (tab)
            {
                case 0:
                    student mystudent = new student("添加");
                    mystudent.StartPosition = FormStartPosition.CenterParent;
                    mystudent.ShowDialog();
                    if (mystudent.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mystudent.QString);
                        ReadAllStudent();
                    }
                    break;
                case 1:
                    course mycourse = new course("添加");
                    mycourse.StartPosition = FormStartPosition.CenterParent;
                    mycourse.ShowDialog();
                    if (mycourse.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mycourse.QString);
                        ReadAllCourse();
                    }
                    break;
                case 2:
                    teacher myteacher = new teacher("添加");
                    myteacher.StartPosition = FormStartPosition.CenterParent;
                    myteacher.ShowDialog();
                    if (myteacher.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(myteacher.QString);
                        ReadAllTeacher();
                    }
                    break;
                case 3:
                    department mydept = new department("添加");
                    mydept.StartPosition = FormStartPosition.CenterParent;
                    mydept.ShowDialog();
                    if (mydept.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mydept.QString);
                        ReadAllDept();
                    }
                    break;
                case 4:
                    sct mysct = new sct("添加");
                    mysct.StartPosition = FormStartPosition.CenterParent;
                    mysct.ShowDialog();
                    if (mysct.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mysct.QString);
                        ReadAllSct();
                    }
                    break;
                default:
                    break;
            }
        }
        private void DEL(int tab)
        {
            if (SelectNO == "")
            {
                MessageBox.Show("未选中数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否删除 [" + SelectNO + "] [" + SelectCon + "] 的数据信息", "删除数据", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) return;

            switch (tab)
            {
                case 0:
                    sql.ExecuteQuery("DELETE FROM student where sno=\"" + SelectNO + "\"");
                    ReadAllStudent();
                    break;
                case 1:
                    sql.ExecuteQuery("DELETE FROM course where cno=\"" + SelectNO + "\"");
                    ReadAllCourse();
                    break;
                case 2:
                    sql.ExecuteQuery("DELETE FROM teacher where tno=\"" + SelectNO + "\"");
                    ReadAllTeacher();
                    break;
                case 3:
                    sql.ExecuteQuery("DELETE FROM department where dno=\"" + SelectNO + "\"");
                    ReadAllDept();
                    break;
                case 4:
                    sql.ExecuteQuery("DELETE FROM sct where GUID=\"" + SelectNO + "\"");
                    ReadAllSct();
                    break;
                default:
                    break;
            }
        }
        private void EDIT(int tab)
        {
            if (SelectNO == "")
            {
                MessageBox.Show("未选中数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (tab)
            {
                case 0:
                    student mystudent = new student("编辑", SelectNO);
                    mystudent.StartPosition = FormStartPosition.CenterParent;
                    mystudent.ShowDialog();
                    if (mystudent.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mystudent.QString);
                        ReadAllStudent();
                    }
                    break;
                case 1:
                    course mycourse = new course("编辑", SelectNO);
                    mycourse.StartPosition = FormStartPosition.CenterParent;
                    mycourse.ShowDialog();
                    if (mycourse.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mycourse.QString);
                        ReadAllCourse();
                    }
                    break;
                case 2:
                    teacher myteacher = new teacher("编辑", SelectNO);
                    myteacher.StartPosition = FormStartPosition.CenterParent;
                    myteacher.ShowDialog();
                    if (myteacher.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(myteacher.QString);
                        ReadAllTeacher();
                    }
                    break;
                case 3:
                    department mydept = new department("编辑", SelectNO);
                    mydept.StartPosition = FormStartPosition.CenterParent;
                    mydept.ShowDialog();
                    if (mydept.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mydept.QString);
                        ReadAllDept();
                    }
                    break;
                case 4:
                    sct mysct = new sct("编辑", SelectNO);
                    mysct.StartPosition = FormStartPosition.CenterParent;
                    mysct.ShowDialog();
                    if (mysct.DialogResult == DialogResult.OK)
                    {
                        sql.ExecuteQuery(mysct.QString);
                        ReadAllSct();
                    }
                    break;
                default:
                    break;
            }
        }
        //==============================附加操作========================================================
        private void listView2_Click(object sender, EventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            SelectNO = "";
            SelectCon = "";
        }
        #region
        //这里用不上了
        /*
        private void test()
        {
            sql.InsertValues("department", new string[] { "000", "英才实验学院", "张三" });
            sql.InsertValues("department", new string[] { "001", "通信与信息工程学院", "李四" });
            sql.InsertValues("department", new string[] { "002", "电子工程学院", "王五" });
            sql.InsertValues("department", new string[] { "003", "微电子与固体电子学院", "丰起" });
            sql.InsertValues("department", new string[] { "004", "物理电子学院", "木华" });
            sql.InsertValues("department", new string[] { "005", "光电信息学院", "曹德" });
            sql.InsertValues("department", new string[] { "006", "计算机科学与工程学院", "鲁单" });
            sql.InsertValues("department", new string[] { "007", "自动化工程学院", "欧阳德" });
            sql.InsertValues("department", new string[] { "008", "机械电子工程学院", "孔德" });
            sql.InsertValues("department", new string[] { "009", "生命科学与技术学院", "刘辉" });
            sql.InsertValues("department", new string[] { "010", "数学科学学院", "纪德" });
            sql.InsertValues("department", new string[] { "011", "经济与管理学院", "谷大度" });
            sql.InsertValues("department", new string[] { "012", "政治与公共管理学院", "凯林" });
            sql.InsertValues("department", new string[] { "013", "外国语学院", "商学起" });
            sql.InsertValues("department", new string[] { "017", "能源科学与工程学院", "胡一宗" });
            sql.InsertValues("department", new string[] { "018", "资源与环境学院", "牛胜" });
            sql.InsertValues("department", new string[] { "019", "航空航天学院", "武列" });
            sql.InsertValues("department", new string[] { "022", "信息软件工程学院", "郭能" });

            sql.InsertValues("student", new string[] { "15022101", "雷雪怡", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022102", "汤万福", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022103", "董尚华", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022104", "韩雪玲", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022105", "马亦龙", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022106", "赵晓燕", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022107", "梁泽", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022108", "丁鹏", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022109", "王永涛", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022110", "武思阳", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022111", "谢希栋", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022112", "代金营", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022113", "王贵昌", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022114", "杨兴博", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022115", "张玉霞", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022116", "李晓玉", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022117", "王晓阳", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022118", "姚敏", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022119", "刘丽华", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022120", "李志坚", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022121", "邸婷", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022122", "王丹", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022123", "赵明鑫", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022124", "王斐斐", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022125", "陶学斌", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022126", "张乾", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022127", "项安", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022128", "武玉娇", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022129", "葛婷", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022130", "马倩", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022131", "孙玉杰", "男", "19", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022132", "常伟天", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022133", "李文婷", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022134", "朱天昌", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022135", "尚海莲", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022136", "胡建华", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022137", "付天君", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022138", "孙云", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022139", "韩福洁", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022140", "王帅", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022141", "宋银玉", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022142", "戴丽", "女", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022143", "张成江", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022144", "杨晓荣", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022145", "刘盛林", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022146", "单永枭", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022147", "苏宁", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022148", "张元钟", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022149", "毛仲锦", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022150", "刘德新", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022151", "赵毅", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022152", "秦彬耀", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022153", "陈玉红", "女", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022154", "鲁娅楠", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022155", "马俊杰", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022156", "马亦龙", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022157", "展大振", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022158", "李建", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022159", "张大砚", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022160", "马江山", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022161", "周震", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022162", "王文博", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022163", "章亮", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022164", "周江", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022165", "姚积刚", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022166", "曹利文", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022167", "梁大森", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022168", "张朝志", "男", "21", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022169", "马耀彪", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022170", "张振昌", "男", "20", "光电信息学院" });
            sql.InsertValues("student", new string[] { "15022171", "薛琴", "女", "21", "光电信息学院" });

            sql.InsertValues("course", new string[] { "10129014", "《红楼梦》专题研讨", "", "5" });
            sql.InsertValues("course", new string[] { "10229035", "《史记》选读", "", "4" });
            sql.InsertValues("course", new string[] { "11029001", "奥林匹克运动", "", "5" });
            sql.InsertValues("course", new string[] { "11929002", "办公室管理与文秘写作", "", "3" });
            sql.InsertValues("course", new string[] { "11229049", "北洋军阀史", "", "4" });
            sql.InsertValues("course", new string[] { "12229002", "比较政治制度", "", "5" });
            sql.InsertValues("course", new string[] { "11229047", "大国的兴衰", "", "5" });
            sql.InsertValues("course", new string[] { "11729001", "大学生健康教育", "", "4" });
            sql.InsertValues("course", new string[] { "10129001", "大学生就业指导", "", "3" });
            sql.InsertValues("course", new string[] { "12229011", "大学生心理素质教育", "", "5" });
            sql.InsertValues("course", new string[] { "11529008", "大学生心理与成才", "", "5" });
        }
        */
        #endregion
        private void btnInit_Click(object sender, EventArgs e)
        {
            sql.CloseConnection();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            byte[] byDll = global::ClassSys.Properties.Resources.mydb;//获取嵌入dll文件的字节数组  
            string strPath = Application.StartupPath + @"\mydb.db";//设置释放路径   导出路径
            //创建dll文件（覆盖模式）  
            using (FileStream fs = new FileStream(strPath, FileMode.Create))
            {
                fs.Write(byDll, 0, byDll.Length);
            }
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            //---------------------初始化界面-----------------------
            InitStudent();
            InitCourse();
            InitTeacher();
            InitDepartment();
            InitSct();
            //--------------------------------------------------------
            MessageBox.Show("重新初始化数据成功");
        }
    }
}