using System;
using System.Collections.Generic;
using System.Linq;
using Scaffolder.Models;

namespace Scaffolder.Repositories
{
    public class SqlScaffolderRepo : IScaffolderRepo
    {
        private readonly ScaffolderContext _context;

        public SqlScaffolderRepo(ScaffolderContext context)
        {
            _context = context;
        }

        public void CreateScaffold(Scaffold obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            _context.Scaffold.Add(obj);
        }

        public void DeleteScaffold(Scaffold obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Scaffold.Remove(obj);
        }

        public IEnumerable<Scaffold> GetAllScaffold()
        {
            return _context.Scaffold.ToList();
        }

        public Scaffold GetScaffoldById(int id)
        {
            return _context.Scaffold.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateScaffold(Scaffold obj)
        {
            throw new NotImplementedException();
        }
    }
}