using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JLAPI.Models.Base;

namespace JLAPI.Interfaces
{
    public interface IRepository<EntityBase>
    {
        bool DoesItemExist(int id);
        IEnumerable<EntityBase> All { get; }
        EntityBase Find(int id);
        void Insert(EntityBase item);
        void Update(EntityBase item);
        void Delete(int id);
    }
}
