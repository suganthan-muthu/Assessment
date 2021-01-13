using MailDIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.Services.contract
{
    public interface IMailItemRepo
    {
        IEnumerable<MailItem> GetAll();
        IEnumerable<MailItem> GetAll(int UserId);
        MailItem GetById(int Id);
        int Add(MailItem value);
        
    }
}
