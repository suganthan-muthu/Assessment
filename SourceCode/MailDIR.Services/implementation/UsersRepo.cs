using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
namespace MailDIR.Services.implementation
{
    public class UsersRepo : IUsersRepo
    {
        private IRepository<User> _repository;

        private readonly ApplicationDbContext _context;

        public UsersRepo ( IRepository<User> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;            
        }

        public int Add(User value)
        {
           return _repository.Insert(value);
        }

        public IEnumerable<User> GetAll()
        {
            
            return _repository.GetAll();
        }

        public User GetById(int Id)
        {
            return _repository.GetByID(Id);
        }

        public List<User> GetAllUsersMails()
        {
            string s = "s";
            var o = from u in _context.Users
                    select new User
                    {
                        Id = u.Id,
                        Name = u.Name,
                        MailItems = (from mi in _context.MailItems
                                     where mi.UsersId == u.Id
                                     select new MailItem
                                     {
                                         Id = mi.Id,
                                         Name = mi.Name,
                                         UsersId = u.Id,
                                         MailDetails = (from md in _context.MailDetails
                                                        where md.MailItemsId == mi.Id
                                                        select md
                                           ).ToList()
                                     }).ToList()
                    };


            return o.ToList();
        }

    }
}
