using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JLAPI.Interfaces;
using JLAPI.Models;
using JLAPI.Models.Base;

namespace JLAPI.Services
{
    public class LogsRepository : IRepository<LogEntry>
    {
        List<LogEntry> _items;

        public LogsRepository()
        {
            _items = new List<LogEntry>
                     {
                         new LogEntry{ID = 1, HuntId = 1},
                         new LogEntry{ID = 2, HuntId = 1}
                     };
        }

        public bool DoesItemExist(int id)
        {
            return _items.Any(item => item.ID == id);
        }

        public IEnumerable<LogEntry> All => _items;

        public LogEntry Find(int id)
        {
            return _items.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(LogEntry item)
        {
            _items.Add(item);
        }

        public void Update(LogEntry item)
        {
            var todoItem = this.Find(item.ID);
            var index = _items.IndexOf(todoItem);
            _items.RemoveAt(index);
            _items.Insert(index, item);
        }

        public void Delete(int id)
        {
            _items.Remove(this.Find(id));
        }
    }
}
