using AutoDataReader.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Service.Contracts
{
    public interface IWordService
    {
        PaginationList<Word> GetAll();

        Word Get(int id);

        void Create(Word word);

        void Update(Word word);

        void Delete(int id);
    }
}
