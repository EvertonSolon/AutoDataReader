using AutoDataReader.Context;
using AutoDataReader.Entities;
using AutoDataReader.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoDataReader.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly AutoDataReaderContext _context;

        public WordRepository(AutoDataReaderContext context)
        {
            _context = context;
        }

        public void Create(Word word)
        {
            _context.Words.Add(word);
            _context.SaveChanges();
        }

        public void Delete(Word word)
        {
            //var entity = Get(id);

            _context.Remove(word);
            _context.SaveChanges();
        }

        public Word Get(int id)
        {
            var entity = _context.Words.AsNoTracking().FirstOrDefault(x => x.Id == id);

            return entity;
        }

        public ICollection<Word> GetAll()
        {
            var entities = _context.Words.ToList();

            return entities;
        }

        public void Update(Word word)
        {
            _context.Words.Update(word);
            _context.SaveChanges();
        }
    }
}
