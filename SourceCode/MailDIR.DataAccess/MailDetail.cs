using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MailDIR.DataAccess
{
    [Table("tblMailDetails")]
    public class MailDetail : BaseEntity    {
              
        public string Message_ID { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Mime_Version { get; set; }
        public string Content_Type { get; set; }
        public string Content_Transfer_Encoding { get; set; }
        public string X_From { get; set; }
        public string X_To { get; set; }
        public string X_cc { get; set; }
        public string X_bcc { get; set; }
        public string X_Folder { get; set; }
        public string X_Origin { get; set; }
        public string X_FileName { get; set; }
        public string MailMessage { get; set; }

        [ForeignKey("MailItemsId")]
        public int MailItemsId { get; set; }        
        public virtual MailItem MailItems { get; set; }
    }
}
