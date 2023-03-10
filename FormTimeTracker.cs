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
using TimeTrackerDesktop.TimerClasses;

namespace TimeTrackerDesktop
{
    public partial class FormTimeTracker : Form
    {
        private bool buttonIsStart = true;
        private Timer timer = new Timer();
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan time;

        private ClassUserAuht user;
        private ClassDataBase database;
        private ClassTimer _timer;

        public FormTimeTracker()
        {
            InitializeComponent();
        }

        private void FormTimeTracker_Load(object sender, EventArgs e)
        {
            if (!user.Roles.Contains(1))
            {
                buttonGoToAdminForm.Visible = false;
            }
            if (!user.Roles.Contains(3))
            {
                buttonCreateReport.Visible = false;
            }
            if(!user.Roles.Contains(4))
            {
                buttonCreateGraphic.Visible = false;
            }

            //Сделать подгрузку данных за текущую неделю
        }

        private void buttonStartStopTimer_Click(object sender, EventArgs e)
        {
            _timer = new ClassTimer(database, user.UserId);

            timer1.Enabled = !timer1.Enabled;
            if (buttonIsStart)
            {
                buttonStartStopTimer.Text = "Стоп";
                buttonStartStopTimer.BackColor = Color.Tomato;  // Визуальное изменение кнопки
                buttonIsStart = false;

                timer1.Enabled = true;
                startTime= DateTime.Now;
                timer.Start();

            }
            else
            {
                buttonStartStopTimer.Text = "Старт";
                buttonStartStopTimer.BackColor = Color.White;  // Визуальное изменение кнопки
                buttonIsStart = true;
                
                endTime = DateTime.Now;
                timer.Stop();
                time = endTime - startTime;

                labelTime.Text = "00:00:00";

                dataGridView1.Rows.Add(DateTime.Now.Date.ToShortDateString(), textBoxNameForTimeline.Text, startTime.TimeOfDay, endTime.TimeOfDay, time);
                _timer.InsertTimerInfo(user.UserId, DateTime.Now.Date.ToShortDateString(), textBoxNameForTimeline.Text, ""+startTime.TimeOfDay, ""+endTime.TimeOfDay, ""+time, "");
                textBoxNameForTimeline.Clear();
                
                // Реализовать вызов метода класса для добавления данных в БД, выше сделать работу через классы
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now - startTime;
            if (time.Hours < 24) 
            {
                labelTime.Text = time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
            }
            else if (time.Hours == 24) // Ограничение в 24 часа, так как данный трекер предназначен для использования на предприятии, где рабочая смена не должна быть больше 24 часов
            {
                timer.Stop();
                time = endTime - startTime;
            }
        }

        private void buttonGoToAdminForm_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.ShowDialog();
            formAdmin.Focus();
            formAdmin.Owner= this; 
        }
        public void SetUser(ClassUserAuht _user)
        {
            this.user = _user;
        }
        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
