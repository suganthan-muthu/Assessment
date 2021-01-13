using MailDIR.DataAccess;
using MailDIR.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MailDIR.Services.contract
{
    public class MailItemRepo : IMailItemRepo
    {
        private IRepository<MailItem> _repository;
        private readonly ApplicationDbContext _context;

        public MailItemRepo(IRepository<MailItem> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public int Add(MailItem value)
        {
            return _repository.Insert(value);
        }

        public IEnumerable<MailItem> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<MailItem> GetAll(int UserId)
        {
            var ret = (from u in _context.Users
                       join m in _context.MailItems on u.Id equals m.UsersId into um
                       from umi in um.DefaultIfEmpty()
                       where u.Id == UserId
                       select new MailItem
                       {
                           Id = umi.Id,
                           Name = umi.Name,
                           UsersId = umi.UsersId
                       }).ToList();
            return ret.AsEnumerable();
        }

        public MailItem GetById(int Id)
        {
            return _repository.GetByID(Id);
        }
    }
}
