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
            dataBase.ExecuteScript(string.Format("insert into main.timer (user_id, start_time, end_time, description, app_name, duration, \"date\") \r\n" +
                "values ({0}, to_timestamp('{1}','HH24:MI:SS'), to_timestamp('{2}','HH24:MI:SS'), '{3}', '{4}', to_timestamp('{5}','HH24:MI:SS'), to_date('{6}','DD.MM.YYYY'));", _user_id, _start_time, _end_time, _description, _app_name, _duration, _date)); 
        }

        
    }
}
