using WebApi.Entities;
using System.Collections.Generic;

namespace WebApi.Service.Contracts
{
    public interface IWordService
    {
        Word Get(int id);

        void Create(Word word);

        void Update(Word word);

        void Delete(Word word);

        ICollection<Word> GetAll();
    }
}
