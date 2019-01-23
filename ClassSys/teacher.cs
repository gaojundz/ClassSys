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
    public partial class teacher : Form
    {
        private static SqLiteHelper sql;

        string GUID = "";
        string TITLE = "";

        public string QString = "";
        public teacher()
        {
            InitializeComponent();
        }
        public teacher(string title)
        {
            InitializeComponent();
            TITLE = title;
            if(title!="") this.Text = this.Text + "-"+ title;
        }
        public teacher(string title, string guid)
        {
            InitializeComponent();
            TITLE = title;
            if (title != "") this.Text = this.Text + "-" + title;
            GUID = guid;
        }

        private void teacher_Load(object sender, EventArgs e)
        {
            sql = new SqLiteHelper("data source=" + Application.StartupPath + "\\mydb.db");

            cbSex.Items.Add("男");
            cbSex.Items.Add("女");
            cbSex.SelectedIndex = 0;

            for (int i = 60; i >= 24; i--)
            {
                cbAge.Items.Add(i.ToString());
            }
            cbAge.SelectedIndex = 0;

            cbEb.Items.Add("博士");
            cbEb.Items.Add("硕士");
            cbEb.Items.Add("学士");
            cbEb.SelectedIndex = 0;

            cbPt.Items.Add("教授");
            cbPt.Items.Add("副教授");
            cbPt.Items.Add("讲师");
            cbPt.Items.Add("助教");
            cbPt.SelectedIndex = 0;

            //---------------------------------------------------------------------------
            SQLiteDataReader read = sql.ExecuteQuery("select cname from course");
            //bool bRead = false;
            while (read.Read())
            {
                string strCno = read.GetString(read.GetOrdinal("cname"));
                cbCno1.Items.Add(strCno);
                cbCno2.Items.Add(strCno);
                cbCno3.Items.Add(strCno);
                //bRead = true;
            }
            //if (bRead) cbName.SelectedIndex = 0;
            //----------------------------------------------------------------------------
            if (TITLE == "编辑")
            {
                txtNO.Enabled = false;
                SQLiteDataReader reader = sql.ExecuteQuery("select * from teacher where tno='" + GUID + "'");
                while (reader.Read())
                {
                    txtNO.Text = reader.GetString(reader.GetOrdinal("tno"));
                    txtName.Text = reader.GetString(reader.GetOrdinal("tname"));
                    cbSex.Text = reader.GetString(reader.GetOrdinal("tsex"));
                    cbAge.Text = reader.GetString(reader.GetOrdinal("tage"));
                    cbEb.Text = reader.GetString(reader.GetOrdinal("teb"));
                    cbPt.Text = reader.GetString(reader.GetOrdinal("tpt"));
                    cbCno1.Text = reader.GetString(reader.GetOrdinal("cno1"));
                    cbCno2.Text = reader.GetString(reader.GetOrdinal("cno2"));
                    cbCno3.Text = reader.GetString(reader.GetOrdinal("cno3"));
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
                    QString = QueryString("teacher", new string[] { txtNO.Text, txtName.Text, cbSex.Text, cbAge.Text, cbEb.Text, cbPt.Text, cbCno1.Text, cbCno2.Text, cbCno3.Text });
                }
                else if (TITLE == "编辑")
                {
                    QString = UpdateString("teacher",
                                      new string[] { "tno", "tname", "tsex", "tage", "teb", "tpt", "cno1", "cno2", "cno3" },
                                      new string[] { txtNO.Text, txtName.Text, cbSex.Text, cbAge.Text, cbEb.Text, cbPt.Text, cbCno1.Text, cbCno2.Text, cbCno3.Text },
                                      "tno", GUID, "=");
                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("教工号 姓名不能为空");
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
