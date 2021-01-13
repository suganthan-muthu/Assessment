using MailDIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.Services.contract
{
    public interface IMailDetailRepo
    {

        IEnumerable<MailDetail> GetAll();
        MailDetail GetById(int Id);
        int Add(MailDetail value);

    }
}
