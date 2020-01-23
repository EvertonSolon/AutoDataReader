using AutoDataReader.Entities;
using System.Collections.Generic;

namespace AutoDataReader.Repositories.Contracts
{
    public interface IWordRepository
    {
        Word Get(int id);

        void Create(Word word);

        void Update(Word word);

        void Delete(Word word);

        ICollection<Word> GetAll();
    }
}
