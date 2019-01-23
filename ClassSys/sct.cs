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
    public partial class sct : Form
    {
        private static SqLiteHelper sql;

        string GUID = "";
        string TITLE = "";

        public string QString = "";
        public sct()
        {
            InitializeComponent();
        }
        public sct(string title)
        {
            InitializeComponent();
            TITLE = title;           
            if(title!="") this.Text = this.Text + "-"+ title;     
        }
        public sct(string title, string guid)
        {
            InitializeComponent();
            TITLE = title;            
            if (title != "") this.Text = this.Text + "-" + title;
            GUID = guid;
        }

        private void sct_Load(object sender, EventArgs e)
        {
            if (GUID == "") GUID = System.Guid.NewGuid().ToString("N");

            txtGUID.Text = GUID;
            //--------------------------------------------------------------------------
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");
            //--------------------------------------------------------------------------
            SQLiteDataReader read; 
            read = sql.ExecuteQuery("select sno,sname from student");
            while (read.Read())
            {
                cbsno.Items.Add(read.GetString(read.GetOrdinal("sno")) +","+ read.GetString(read.GetOrdinal("sname")));
            }

            read = sql.ExecuteQuery("select cno,cname from course");
            while (read.Read())
            {
                cbcno.Items.Add(read.GetString(read.GetOrdinal("cno")) + "," + read.GetString(read.GetOrdinal("cname")));
            }

            read = sql.ExecuteQuery("select tno,tname from teacher");
            while (read.Read())
            {
                cbtno.Items.Add(read.GetString(read.GetOrdinal("tno")) + "," + read.GetString(read.GetOrdinal("tname")));
            }
            //-------------------------------------------------------------------------------------------------
            if (TITLE == "编辑")
            {
                SQLiteDataReader reader = sql.ExecuteQuery("select * from sct where GUID='" + GUID + "'");
                while (reader.Read())
                {
                    cbsno.Text = reader.GetString(reader.GetOrdinal("sno"));
                    cbcno.Text = reader.GetString(reader.GetOrdinal("cno"));
                    cbtno.Text = reader.GetString(reader.GetOrdinal("tno"));
                    txtgrade.Text = reader.GetString(reader.GetOrdinal("grade"));
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
            if (cbsno.Text != "" && cbcno.Text != "" && cbtno.Text != "")
            {
                //string[] sno = cbsno.Text.Split(',');
                //string[] cno = cbcno.Text.Split(',');
                //string[] tno = cbtno.Text.Split(',');
                if (TITLE == "添加")
                {
                    QString = QueryString("sct", new string[] { GUID, cbsno.Text, cbcno.Text, cbtno.Text, txtgrade.Text });
                }
                else if (TITLE == "编辑")
                {
                    QString = UpdateString("sct",
                                      new string[] { "GUID","sno", "cno", "tno","grade" },
                                      new string[] { GUID, cbsno.Text, cbcno.Text, cbtno.Text, txtgrade.Text },
                                      "GUID", GUID, "=");
                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("学号 课程号 教工号不能为空");
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
