using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly WebApiContext _context;

        public WordRepository(WebApiContext context)
        {
            _context = context;
        }

        public void Create(Word word)
        {
            _context.Words.Add(word);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);

            _context.Remove(entity);
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
