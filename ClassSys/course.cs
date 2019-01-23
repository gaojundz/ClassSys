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
    public partial class course : Form
    {

        private static SqLiteHelper sql;

        string GUID = "";
        string TITLE = "";

        public string QString = "";
        public course()
        {
            InitializeComponent();
        }
        public course(string title)
        {
            InitializeComponent();
            TITLE = title;           
            if(title!="") this.Text = this.Text + "-"+ title;     
        }
        public course(string title, string guid)
        {
            InitializeComponent();
            TITLE = title;            
            if (title != "") this.Text = this.Text + "-" + title;
            GUID = guid;
        }
        private void course_Load(object sender, EventArgs e)
        {
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            //---------------------------------------------------------------------------
            SQLiteDataReader read = sql.ExecuteQuery("select cname from course");
            //bool bRead = false;
            while (read.Read())
            {
                cbName.Items.Add(read.GetString(read.GetOrdinal("cname")));
                //bRead = true;
            }
            //if (bRead) cbName.SelectedIndex = 0;
            //----------------------------------------------------------------------------
            if (TITLE == "编辑")
            {
                txtNO.Enabled = false;
                SQLiteDataReader reader = sql.ExecuteQuery("select * from course where cno='" + GUID + "'");
                while (reader.Read())
                {
                    txtNO.Text = reader.GetString(reader.GetOrdinal("cno"));
                    txtName.Text = reader.GetString(reader.GetOrdinal("cname"));
                    cbName.Text = reader.GetString(reader.GetOrdinal("cpno"));
                    txtCredit.Text = reader.GetString(reader.GetOrdinal("ccredit"));
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
                    QString = QueryString("course", new string[] { txtNO.Text, txtName.Text, cbName.Text, txtCredit.Text });
                }
                else if (TITLE == "编辑")
                {
                    QString = UpdateString("course",
                                      new string[] { "cno", "cname", "cpno", "ccredit" },
                                      new string[] { txtNO.Text, txtName.Text, cbName.Text, txtCredit.Text },
                                      "cno", txtNO.Text, "=");
                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("课程号 课程名不能为空");
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
