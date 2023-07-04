using storeDAL;
using storeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBL
{
    public interface ILogService
    {
        public void WriteLog(LogType type, string Message);
    }
    public class LogService : ILogService
    {
        private readonly ILogManager _ILogService;
        public LogService(ILogManager ILogService) { _ILogService = ILogService; }
        public void WriteLog(LogType type, string Message)
        {
            _ILogService.WriteLog(type, Message);
        }
    }
}
