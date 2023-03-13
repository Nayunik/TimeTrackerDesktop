using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop.TimerClasses
{
    internal class ClassTimer
    {
        private int timer_id;
        private int user_id;
        private string start_time;
        private string end_time;
        private string description;
        private string app_name;
        private int object_id;
        private string duration;
        private string date;

        private ClassDataBase dataBase;

        public ClassTimer (ClassDataBase _database, int _user_id)
        {
            this.dataBase = _database;
            this.user_id = _user_id;
        }

        public int Timer_id { get => timer_id; set => timer_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Start_time { get => start_time; set => start_time = value; }
        public string End_time { get => end_time; set => end_time = value; }
        public string Description { get => description; set => description = value; }
        public string App_name { get => app_name; set => app_name = value; }
        public int Object_id { get => object_id; set => object_id = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Date { get => date; set => date = value; }

        public void InsertTimerInfo (int _user_id, string _date, string _description, string _start_time, string _end_time, string _duration, string _app_name)
        {
            dataBase.ExecuteScript(""); // Необходимо написать код для внесения данных в БД
        }
    }
}
