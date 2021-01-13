using MailDIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailDIR.Services.contract
{
    public interface IMailDetailsColMapRepo
    {
        List<MailDetailsColMap> GetAll();
        MailDetailsColMap GetById(int Id);
        string GetFlatFileColumName(string Columne);

        int Add(MailDetailsColMap value);
        

    }
}
