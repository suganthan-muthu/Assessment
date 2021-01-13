using MailDIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailDIR.Services.contract
{
    public interface IUsersRepo
    {
        IEnumerable<User> GetAll();
        User GetById(int Id);
        int Add(User value);
        List<User> GetAllUsersMails();
    }
}
