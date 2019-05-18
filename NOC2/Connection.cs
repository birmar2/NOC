using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace NOC2
{
    public partial class Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;

        public Connection()
        {
            server   = "localhost";
            database = "noc";
            user     = "root";
            password = "";
            port     = "3306";
            sslM     = "none";

            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            connection = new MySqlConnection(connectionString);
        }

        /*public void InitSqlCommand(string query)
        {
            var Command = new MySqlCommand(query);
            Command.Connection = connection;
            connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }*/

        public MySqlCommand RunQuery(string query)
        {
            var myCommand = new MySqlCommand(query, connection);
            myCommand.Connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();
            return myCommand;
        }

        public MySqlCommand InitSqlCommand(string query)
        {
            var mySqlCommand = new MySqlCommand(query, connection);
            return mySqlCommand;
        }

        public DataTable GetData(string query)
        {
            var dataTable = new DataTable();
            var dataSet = new DataSet();
            var dataAdapter = new MySqlDataAdapter { SelectCommand = InitSqlCommand(query) };

            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
            return dataTable;
        }

    }

}