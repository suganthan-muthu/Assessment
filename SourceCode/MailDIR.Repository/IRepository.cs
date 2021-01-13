using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();  
        T GetByID(int id);
        int Insert(T items);

    }
}
