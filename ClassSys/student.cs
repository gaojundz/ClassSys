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

namespace ClassSys
{
    public partial class student : Form
    {
        private static SqLiteHelper sql;

        string GUID = "";
        string TITLE = "";

        public string QString = "";
        public student()
        {
            InitializeComponent();
        }
        public student(string title)
        {
            InitializeComponent();
            TITLE = title;
            if(title!="") this.Text = this.Text + "-"+ title;
        }
        public student(string title, string guid)
        {
            InitializeComponent();
            TITLE = title;
            if (title != "") this.Text = this.Text + "-" + title;
            GUID = guid;
        }

        private void student_Load(object sender, EventArgs e)
        {
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            //SqLiteHelper inssql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            cbSex.Items.Add("男");
            cbSex.Items.Add("女");
            cbSex.SelectedIndex = 0;

            for (int i = 24; i >= 14; i--)
            {
                cbAge.Items.Add(i.ToString());
            }
            cbAge.SelectedIndex = 0;

            //---------------------------------------------------------------------------
            SQLiteDataReader read = sql.ExecuteQuery("select dname from department");
            bool bRead = false;
            while (read.Read())
            {
                cbDept.Items.Add(read.GetString(read.GetOrdinal("dname")));
                bRead = true;
            }
            if (bRead) cbDept.SelectedIndex = 0;
            //----------------------------------------------------------------------------
            if (TITLE == "编辑")
            {
                txtNO.Enabled = false;
                SQLiteDataReader reader = sql.ExecuteQuery("select * from student where sno='" + GUID + "'");
                while (reader.Read())
                {
                    txtNO.Text = reader.GetString(reader.GetOrdinal("sno"));
                    txtName.Text = reader.GetString(reader.GetOrdinal("sname"));
                    cbSex.Text = reader.GetString(reader.GetOrdinal("ssex"));
                    cbAge.Text = reader.GetString(reader.GetOrdinal("sage"));
                    cbDept.Text = reader.GetString(reader.GetOrdinal("sdept"));
                }
            }
        }
        private string QueryString(string tableName, string[] values)
        {
            string str = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                str += ", " + "'" + values[i] + "'";
            }
            str += " )";
            return str;
        }
        private string UpdateString(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=")
        {
            string str = "UPDATE " + tableName + " SET " + colNames[0] + "=" + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                str += ", " + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            str += " WHERE " + key + operation + "'" + value + "'";
            return str;
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (txtNO.Text != "" && txtName.Text != "")
            {
                if (TITLE == "添加")
                {
                    QString = QueryString("student", new string[] { txtNO.Text, txtName.Text, cbSex.Text, cbAge.Text, cbDept.Text });
                }
                else if (TITLE == "编辑")
                {
                    QString = UpdateString("student",
                                      new string[] { "sno", "sname", "ssex", "sage", "sdept" },
                                      new string[] { txtNO.Text, txtName.Text, cbSex.Text, cbAge.Text, cbDept.Text },
                                      "sno", GUID, "=");
                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("学号 姓名不能为空");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
            this.Close();
        }

    }
}
