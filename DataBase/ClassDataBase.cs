using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TimeTrackerDesktop.DataBase
{
    internal class ClassDataBase
    {
        private string configurationToConnect;
        private NpgsqlConnection connection;
        private string msg;

        public string ConfigurationToConnect { get => configurationToConnect; set => configurationToConnect = value; }
        public string GetMsg { get => msg; }

        public bool isConnectToDB(string configurationToConnect)
        {
            try
            {
                this.connection = new NpgsqlConnection(configurationToConnect);
                this.connection.Open();
                msg = "Connection is ready";
                return true;
                
            }
            catch
            {
                SystemException e = new SystemException();
                this.msg = (string)e.Message;
                return false;
            }

        }

        public NpgsqlDataReader FunctionUsing (string nameOfFunction)
        {
            if (nameOfFunction == null || nameOfFunction == "") 
            {
                return null;
            }
            else
            {
                var command = new NpgsqlCommand("select * from " + nameOfFunction, this.connection);
                return command.ExecuteReader();
            }
        }
        

 

    }
}
