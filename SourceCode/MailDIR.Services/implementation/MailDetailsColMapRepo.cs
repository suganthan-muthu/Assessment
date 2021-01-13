using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailDIR.Services.implementation
{
    public class MailDetailsColMapRepo : IMailDetailsColMapRepo
    {
                private IRepository<MailDetailsColMap> _repository;
        
        public MailDetailsColMapRepo(IRepository<MailDetailsColMap> repository, IConfiguration configuration)
        {
            _repository = repository;
            
        }

        public List<MailDetailsColMap> GetAll()
        {
          return  _repository.GetAll().ToList();
        }

        public string GetFlatFileColumName(string Columne)
        {
            IEnumerable<MailDetailsColMap> lst = _repository.GetAll();
            var rlt = from col in lst where col.DbColumnName == Columne select col;
            return rlt.FirstOrDefault().FlatFileColumnName;
        }

        public MailDetailsColMap GetById(int Id)
        {
            return _repository.GetByID(Id);
        }

        public int Add(MailDetailsColMap value)
        {
            return _repository.Insert(value);
        }
    }
}
