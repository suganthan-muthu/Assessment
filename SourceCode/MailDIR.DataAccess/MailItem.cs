using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MailDIR.DataAccess
{
    [Table("tblMailItems")]
    public class MailItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual User Users { get; set; }

        [ForeignKey("UsersId")]
        public int UsersId { get; set; }
        public virtual ICollection<MailDetail> MailDetails { get; set; }
    }
}
