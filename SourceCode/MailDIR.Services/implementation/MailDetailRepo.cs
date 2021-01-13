using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.Services.implementation
{
    public class MailDetailRepo : IMailDetailRepo
    {
        private IRepository<MailDetail> _repository;
        public MailDetailRepo(IRepository<MailDetail> repository)
        {
            _repository = repository;
        }
        public int Add(MailDetail value)
        {
            return _repository.Insert(value);
        }

        public IEnumerable<MailDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public MailDetail GetById(int Id)
        {
            return _repository.GetByID(Id);
        }
    }
}
