using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeModel
{
    public class LOG
    {
        public Guid Id { get; set; }
        public DateTime LogDate { get; set; }
        public LogType LogType  { get; set; }
        public string Message { get; set; } = string.Empty;
    }
    public enum LogType { exception, success, faile }
}
