using WebApi.Entities;
using System.Collections.Generic;
using WebApi.Repositories.Contracts.Base;

namespace WebApi.Repositories.Contracts
{
    public interface IWordRepository : ICrudBaseRepository<Word>
    {
    }
}
