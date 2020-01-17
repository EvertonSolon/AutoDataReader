using AutoDataReader.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Repositories.Contracts
{
    public interface IWordRepository
    {
        ICollection<Word> GetAll();

        Word Get(int id);

        void Create(Word word);

        void Update(Word word);

        void Delete(int id);
    }
}
