using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOC2
{
    public class LogService
    {
        public LogService()
        {
            
        }

        public string InsertLog(int userId, int operationId, int recordId)
        {
            string logQuery = "INSERT INTO log (`user_id`,`operation_id`,`record_id`,`inserttime`) VALUES ('" + userId + "','"+ operationId + "','" + recordId + "',NOW())";
            return logQuery;
        }
    }
}
