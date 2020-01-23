using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Service.Contracts.Base
{
    public interface ICrudBaseService<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        ICollection<TEntity> GetAll();
    }
}
