using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MailDIR.DataAccess
{
    [Table("tblUsers")]
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<MailItem> MailItems { get; set; }
    }
}
