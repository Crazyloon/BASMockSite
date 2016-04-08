using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Utilities
{
    interface IRepository<TEntity,in TPKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPKey id);
        void Insert(TEntity ent);
        void Update(TEntity ent);
        void Delete(TEntity ent);
    }
}
