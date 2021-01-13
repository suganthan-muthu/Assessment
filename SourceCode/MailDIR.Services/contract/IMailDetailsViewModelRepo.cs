using MailDIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.Services.contract
{
    public interface IMailDetailsViewModelRepo
    {
        IEnumerable<MailDetailsViewModel> GetAll();

        IEnumerable<MailDetailsViewModel> MailDetailsByMailItemId(int Id);
        IEnumerable<MailDetailsViewModel> MailDetailsByUserId(int Id);

        IEnumerable<MailDetailsViewModel> MailDetailsBySearch(string IsearchMesaage);
    }
}
