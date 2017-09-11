using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JLAPI.Interfaces;
using JLAPI.Models;
using JLAPI.Models.Base;

namespace JLAPI.Services
{
    public class HuntsRepository : IRepository<Hunt>
    {
        List<Hunt> _items;

        public HuntsRepository()
        {
            _items = new List<Hunt>
                     {
                         new Hunt { ID = 1, Location = "sted"},
                         new Hunt { ID = 2, Location = "sted2"},
                         new Hunt { ID = 3, Location = "sted3"},
                     };
            
        }

        public bool DoesItemExist(int id)
        {
            return _items.Any(item => item.ID == id);
        }

        public IEnumerable<Hunt> All => _items;

        public Hunt Find(int id)
        {
            return _items.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(Hunt item)
        {
            _items.Add(item);
        }

        public void Update(Hunt item)
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
