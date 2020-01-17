using AutoDataReader.Entities;
using AutoDataReader.Repositories.Contracts;
using AutoDataReader.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Service
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _repository;

        public WordService(IWordRepository repository)
        {
            _repository = repository;
        }

        public void Create(Word word)
        {
            word.CreatedDate = DateTime.Now;
            _repository.Create(word);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Word Get(int id)
        {
            var result = _repository.Get(id);
            return result;
        }

        public PaginationList<Word> GetAll()
        {
            var paginationList = new PaginationList<Word>();
            //var entityIqueriable = _context.Words.AsNoTracking().AsQueryable();

            throw new NotImplementedException();
        }

        public void Update(Word word)
        {
            throw new NotImplementedException();
        }
    }
}
