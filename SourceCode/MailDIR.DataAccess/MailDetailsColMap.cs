using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailDIR.DataAccess
{
    [Table("tblMailDetailsColMap")]
    public class MailDetailsColMap : BaseEntity
    {        
        public string DbColumnName { get; set; }
        public string FlatFileColumnName { get; set; }
    }
}
