using System;
using System.Collections.Generic;
using System.Text;

namespace MailDIR.DataAccess
{
    public class MailDetailsViewModel
    {
        public string UserName { get; set; }
        public string MailItemName { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string X_FileName { get; set; }
        public string MailMessage { get; set; }
    }
}
