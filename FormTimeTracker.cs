using ActiveWindow.BLL.ActiveWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Globalization;
using System.Linq;

using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        private System.Timers.Timer timer = new System.Timers.Timer();
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan time;

        private ClassUserAuht user;
        private ClassDataBase database;
        private ClassTimer _timer;

        public CancellationTokenSource _tokenSource;

        private List<string> listAppName;
        private List<TimeSpan> listAppTime;
        private List<DateTime> listAppStartTime;
        private List<DateTime> listAppEndTime;


        public FormTimeTracker()
        {
            InitializeComponent();

            //Ниже указан код, который необходим для открытия формы по сочетанию клавиш 
            HotKey h = new HotKey();

            h.Key = Keys.F2;
            h.KeyModifier = HotKey.KeyModifiers.Control; // это добавляет к основной кнопке комбинацию 
            h.HotKeyPressed += this.onHK;
            h.Handle = this.Handle;
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

            button1.Enabled = false;

            var resultFunc = database.SelectFunctionUsing(string.Format("main.get_timers({0})", user.UserId));
            while (resultFunc.Read())
            {
                dataGridView1.Rows.Add(resultFunc.GetValue(0).ToString().Split(' ')[0], resultFunc.GetValue(1), resultFunc.GetValue(2), resultFunc.GetValue(3), resultFunc.GetValue(4));
            }
            resultFunc.Close();
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
                startTime = DateTime.Now;
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

                dataGridView1.Rows.Add(DateTime.Now.Date.ToShortDateString(), textBoxNameForTimeline.Text, startTime.TimeOfDay.ToString().Split('.')[0], endTime.TimeOfDay.ToString().Split('.')[0], time.ToString().Split('.')[0]);
                _timer.InsertTimerInfo(user.UserId, DateTime.Now.Date.ToShortDateString(), textBoxNameForTimeline.Text, ""+startTime.TimeOfDay, ""+endTime.TimeOfDay, time.ToString().Split('.')[0], "");
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
            formAdmin.SetUser(user);
            formAdmin.SetDB(database);
            formAdmin.ShowDialog();
            formAdmin.Focus();
            formAdmin.Owner = this; 
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

        private async void buttonAutoMod_Click(object sender, EventArgs e)
        {
            int listAppCount;

            listAppName = new List<string>();
            listAppName.Add(""); // Нужно будет потом его удалить или игнорировать 
            listAppTime = new List<TimeSpan>();
            listAppStartTime = new List<DateTime>();
            listAppEndTime = new List<DateTime>();

            buttonAutoMod.BackColor = Color.Green;  // Визуальное изменение кнопки
            buttonAutoMod.Enabled = false;
            buttonStartStopTimer.Enabled = false;
            button1.Enabled = true;
            buttonAutoHideMod.Enabled = false;

            _tokenSource = new CancellationTokenSource();
            await Task.Run(() => GetApplicationAndTimeInfo(_tokenSource.Token), _tokenSource.Token);

            buttonAutoMod.BackColor = Color.White;  // Визуальное изменение кнопки
            buttonAutoMod.Enabled = true;
            buttonStartStopTimer.Enabled = true;
            button1.Enabled = false;
            buttonAutoHideMod.Enabled = true;

            listAppName.RemoveAt(0);
            listAppTime.RemoveAt(0);
            listAppStartTime.RemoveAt(0);
            listAppEndTime.RemoveAt(0);

            listAppCount = listAppName.Count;

            for (int i = 0; i < listAppCount; i++)
            {
                _timer = new ClassTimer(database, user.UserId);
                dataGridView1.Rows.Add(DateTime.Now.Date.ToShortDateString(), listAppName[i], listAppStartTime[i].TimeOfDay.ToString().Split('.')[0], listAppEndTime[i].TimeOfDay.ToString().Split('.')[0], listAppTime[i].ToString().Split('.')[0]);
                _timer.InsertTimerInfo(user.UserId, DateTime.Now.Date.ToShortDateString(), listAppName[i], "" + listAppStartTime[i].TimeOfDay, "" + listAppEndTime[i].TimeOfDay, listAppTime[i].ToString().Split('.')[0], listAppName[i]);
                
            }

        }

        

        private void GetApplicationAndTimeInfo(CancellationToken cancelToken)
        {
            bool timeGo = true;

            while (!cancelToken.IsCancellationRequested)
            {
                var activeWindowWatcher = new ActiveWindowWatcher(TimeSpan.FromMilliseconds(500));
                
                if (timeGo)
                {
                    startTime = DateTime.Now;
                    timeGo = false;
                }

                activeWindowWatcher.ActiveWindowChanged += (o, en) =>
                {
                    if ((en.ActiveWindow) != listAppName.Last())
                    {
                        listAppName.Add(en.ActiveWindow);

                        endTime = DateTime.Now;
                        time = endTime - startTime;
                        listAppTime.Add(time);
                        listAppEndTime.Add(endTime);
                        listAppStartTime.Add(startTime);

                        timeGo = true;
                    }
                };

                activeWindowWatcher.Start();
                Thread.Sleep(500);

            }
            endTime = DateTime.Now;
            time = endTime - startTime;
            listAppTime.Add(time);
            listAppEndTime.Add(endTime);
            listAppStartTime.Add(startTime);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }

        private void onHK(object sender, EventArgs e)
        {
            PasswordIsCorect();
        }

        private async void buttonAutoHideMod_Click(object sender, EventArgs e)
        {
            this.Hide();

            int listAppCount;

            listAppName = new List<string>();
            listAppName.Add(""); // Нужно будет потом его удалить или игнорировать 
            listAppTime = new List<TimeSpan>();
            listAppStartTime = new List<DateTime>();
            listAppEndTime = new List<DateTime>();

            _tokenSource = new CancellationTokenSource();
            await Task.Run(() => GetApplicationAndTimeInfo(_tokenSource.Token), _tokenSource.Token);

            listAppName.RemoveAt(0);
            listAppTime.RemoveAt(0);
            listAppStartTime.RemoveAt(0);
            listAppEndTime.RemoveAt(0);

            listAppCount = listAppName.Count - 1;

            for (int i = 0; i < listAppCount; i++)
            {
                _timer = new ClassTimer(database, user.UserId);
                dataGridView1.Rows.Add(DateTime.Now.Date.ToShortDateString(), listAppName[i], listAppStartTime[i].TimeOfDay.ToString().Split('.')[0], listAppEndTime[i].TimeOfDay.ToString().Split('.')[0], listAppTime[i].ToString().Split('.')[0]);
                _timer.InsertTimerInfo(user.UserId, DateTime.Now.Date.ToShortDateString(), listAppName[i], "" + listAppStartTime[i].TimeOfDay, "" + listAppEndTime[i].TimeOfDay, listAppTime[i].ToString().Split('.')[0], listAppName[i]);

            }

        }

        private void FormTimeTracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PasswordIsCorect()
        {
            FormEnterPassword formEnterPass = new FormEnterPassword();
            formEnterPass.SetFormTimeTracker(this);
            formEnterPass.SetUserPassword(user.Password);
            formEnterPass.Show();

        }

        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonCreateReport_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
