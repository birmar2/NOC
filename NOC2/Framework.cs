using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOC2
{
    public static class Framework
    {
        //public int myUserId { get; set; }
        public static Connection db = new Connection();
        private static LogService logService = new LogService();
        public static Colors getColor = new Colors();

        private static string _myUsername = "";
        private static int _myUserId = 0;
        private static int _myGroupId = 0;

        public static int MyUserId
        {
            get { return _myUserId; }
            set { _myUserId = value; }
        }

        public static string MyUserName
        {
            get { return _myUsername; }
            set { _myUsername = value; }
        }

        public static int MyGroupId
        {
            get { return _myGroupId; }
            set { _myGroupId = value; }
        }

        private static List<Operation> GetOperations()
        {
            string getOperationsQuery = "SELECT * FROM operations";
            var typeTable = db.GetData(getOperationsQuery);
            DataView result = new DataView(typeTable);

            List<Operation> items = new List<Operation>();
            foreach (DataRowView row in result)
            {
                items.Add(new Operation() { operationId = Convert.ToInt32(row["operationid"]), operationName = row["operationname"].ToString() });
            }
            return items;
        }

        public static int Operation(string operationName)
        {
            var items = GetOperations();
            Operation result = items.Find(i => i.operationName == operationName);
            int opId = result != null ? result.operationId : 0;
            return opId;
        }

        public static void insertLog(int userId, int operationId, int recordId)
        {
            string insertQuery = logService.InsertLog(userId,operationId,recordId);
            db.RunQuery(insertQuery);
        }

        private static List<SystemParams> GetSystemparams()
        {
            string getSystemparamsQuery = "SELECT * FROM systemparams";
            var typeTable = db.GetData(getSystemparamsQuery);
            DataView result = new DataView(typeTable);

            List<SystemParams> items = new List<SystemParams>();
            foreach (DataRowView row in result)
            {
                items.Add(new SystemParams() { sysparamId = Convert.ToInt32(row["sysparamid"]), sysKey = row["syskey"].ToString(), sysValue = row["sysvalue"].ToString() });
            }
            return items;
        }

        public static string Systemparam(string key)
        {
            var items = GetSystemparams();
            SystemParams result = items.Find(i => i.sysKey == key);
            string sysvalue = result != null ? result.sysValue : "";
            return sysvalue;
        }

    }
}
