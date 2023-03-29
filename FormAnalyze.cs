using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTrackerDesktop.AuthClasses;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop
{
    public partial class FormAnalyze : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormAnalyze()
        {
            InitializeComponent();
        }

        private void FormAnalyze_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var resultFunc = database.SelectFunctionUsing("auth.get_users()");

            while (resultFunc.Read())
            {
                dataGridView1.Rows.Add(resultFunc.GetValue(0).ToString().Split(' ')[0], resultFunc.GetValue(1), resultFunc.GetValue(2), resultFunc.GetValue(3), resultFunc.GetValue(4), resultFunc.GetValue(5));

                if (!resultFunc.IsDBNull(6) && resultFunc.GetBoolean(6))
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Red;

                }
            }
            resultFunc.Close();
        }
        public void SetUser(ClassUserAuht _user)
        {
            this.user = _user;
        }
        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }

        private void FormAnalyze_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            textBoxDateEnd.Text = string.Empty;
            textBoxDateStart.Text = string.Empty;
        }
    }
}
