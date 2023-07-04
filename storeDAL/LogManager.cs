using storeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static storeModel.LOG;

namespace storeDAL
{
    public interface ILogManager
    {
        public void WriteLog(LogType type, string Message);
    }
    public class LogManager : ILogManager
    {
        private readonly DBContext _entityContext;
        public LogManager(DBContext entityContext) { _entityContext = entityContext; }

        public void WriteLog( LogType type, string Message) 
        { 
          
                LOG log = new LOG();
                log.Id = Guid.NewGuid();
                log.LogDate= DateTime.Now;
                log.Message = Message;
                log.LogType = type;
            _entityContext.Logs.Add(log);
            _entityContext.SaveChanges();
            
        }
    }
}
