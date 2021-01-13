using MailDIR.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailDIR.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entity = null;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {           
            return entity.AsEnumerable();            
        }              

        public T GetByID(int id)
        {            
            return entity.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(T items)
        {
            entity.Add(items);
            _context.SaveChanges();
            return entity.LastOrDefault().Id;
        }
    }
}
