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
    public partial class FormChangeUser : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormChangeUser()
        {
            InitializeComponent();
        }

        private void FormChangeUser_Load(object sender, EventArgs e)
        {
            
        }
        public void SetUser(ClassUserAuht _user)
        {
            this.user = _user;
        }
        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }
    }
}
