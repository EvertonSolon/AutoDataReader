using AutoDataReader.Entities;
using AutoDataReader.Repositories.Contracts;
using AutoDataReader.Service.Contracts;
using System;
using System.Collections.Generic;

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

        public void Delete(Word word)
        {
            _repository.Delete(word);
        }

        public Word Get(int id)
        {
            var result = _repository.Get(id);
            return result;
        }

        public ICollection<Word> GetAll()
        {
            var results = _repository.GetAll();

            return results;
        }

        public void Update(Word word)
        {
            _repository.Update(word);
        }
    }
}
