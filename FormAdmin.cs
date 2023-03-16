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
    public partial class FormAdmin : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            var resultFunc = database.SelectFunctionUsing("auth.get_users()");
            while (resultFunc.Read())
            {
                dataGridView1.Rows.Add(resultFunc.GetValue(0).ToString().Split(' ')[0], resultFunc.GetValue(1), resultFunc.GetValue(2), resultFunc.GetValue(3), resultFunc.GetValue(4), resultFunc.GetValue(5));
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

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string selectedLogin = dataGridView1.SelectedCells[0].Value.ToString();
            ClassUserAuht selectedUser = new ClassUserAuht(selectedLogin, database);
            FormChangeUser formChangeUser = new FormChangeUser();
            formChangeUser.SetUser(selectedUser);
            formChangeUser.SetDB(database);
            formChangeUser.ShowDialog();
        }
    }
}
