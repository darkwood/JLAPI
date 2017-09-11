using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JLAPI.Services
{
    public static class DB
    {
        public static HuntsRepository HuntsRepository { get; set; }
        public static LogsRepository LogsRepository { get; set; }

        static DB()
        {
            HuntsRepository = new HuntsRepository();
            LogsRepository = new  LogsRepository();
        }
    }
}
