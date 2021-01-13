using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MailDIR.Services.implementation
{


    public class ImportToSQLRepo : IImportToSQLRepo
    {
        public IConfiguration Configuration { get; }
        private IUsersRepo _users;
        private IMailItemRepo _mailItems;
        private IMailDetailRepo _mailDetailRepo;
        private IMailDetailsColMapRepo _mailDtlsColMap;


        string RootPath = "";

        public ImportToSQLRepo(IConfiguration configuration,
            IUsersRepo users, IMailItemRepo mailItems, IMailDetailRepo mailDetailRepo,
            IMailDetailsColMapRepo mailDtlsColMap)
        {

            Configuration = configuration;
            RootPath = Configuration.GetSection("RootPath").Value;
            _users = users;
            _mailItems = mailItems;
            _mailDetailRepo = mailDetailRepo;
            _mailDtlsColMap = mailDtlsColMap;
        }
        void IImportToSQLRepo.ImportToSQL()
        {
            ImportUsers(RootPath);
            //ImportMailDetails(1, "C:\\Projects\\Enron_mails\\maildir\\badeer-r\\all_documents");
        }

        void ImportUsers(string Path)
        {
            string[] dirs = Directory.GetDirectories(Path);

            if (dirs.Length != 0)
            {
                foreach (string dirName in dirs)
                {
                    int UsersId = 0;
                    User user = new User();
                    user.Name = GetFolderName(dirName);
                    UsersId = _users.Add(user);
                    ImportMailItems(UsersId, dirName);
                }
            }
        }

        void ImportMailItems(int UsersId, string Path)
        {
            string[] dirs = Directory.GetDirectories(Path);

            if (dirs.Length != 0)
            {
                foreach (string dir in dirs)
                {
                    int MailItemsId = 0;
                    MailItem mail = new MailItem();
                    mail.Name = GetFolderName(dir);
                    mail.UsersId = UsersId;
                    MailItemsId = _mailItems.Add(mail);
                    ImportMailDetails(MailItemsId, dir);
                }
            }
        }

        void ImportMailDetails(int MailItemsId, string Path)
        {
            string[] files = Directory.GetFiles(Path);

            if (files.Length != 0)
            {
                List<MailDetailsColMap> columns = _mailDtlsColMap.GetAll();

                foreach (string file in files)
                {
                    columns = SortingFlatFileColumns(file, columns);

                    List<string> lstFlatCol = (from col in columns select col.FlatFileColumnName).ToList();

                    MailDetail mailItem = new MailDetail();
                    int i= 0;                   
                    string AllText = File.ReadAllText(file);
                    string AllTextOut = "" ;

                    mailItem.MailItemsId = MailItemsId;
                    foreach (MailDetailsColMap column in columns)
                    {                        
                        string value = GetValueFromFlatFile(AllText, column.FlatFileColumnName, lstFlatCol,out AllTextOut);
                        mailItem.GetType().GetProperty(column.DbColumnName).SetValue(mailItem, value, null);
                        if (column.FlatFileColumnName == "X-FileName")
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                string[] Message = value.Split("\r\n",2);
                                mailItem.X_FileName = Message[0];
                                mailItem.MailMessage = Message[1];
                            }
                        }                        
                        
                        AllText = AllTextOut;
                    }
                    //ReadColumnValue(file, columns);
                    _mailDetailRepo.Add(mailItem);
                }
            }
        }

        List<MailDetailsColMap> SortingFlatFileColumns(string file, List<MailDetailsColMap> columns)
        {
            List<string> lst = new List<string>();
            List<MailDetailsColMap> o_columns = new List<MailDetailsColMap>();
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {

                foreach (MailDetailsColMap col in columns)
                {
                    if (line.ToLower().IndexOf(col.FlatFileColumnName.ToLower() + ":", 0) != -1)
                    {
                        lst.Add(col.FlatFileColumnName.ToLower());
                        o_columns.Add(col);
                        columns.Remove(col);
                        break;
                    }
                }
            }
            return o_columns;
        }
        string GetFolderName(string dirName)
        {
            string[] path = dirName.Split('\\');
            return path[path.Length - 1];
        }

        
        string GetValueFromFlatFile(string AllText, string columName, List<string> lstFlatCol,out string AllTextOut)
        {
            try
            {
                int start, length = 0;
                string columValue = "";
                start = AllText.ToLower().IndexOf(lstFlatCol[0].ToLower() + ":") + lstFlatCol[0].Length + 1;

                if (lstFlatCol.Count > 1)
                    length = AllText.ToLower().IndexOf(lstFlatCol[1].ToLower()) - start;

                if (lstFlatCol.Count > 1)
                {
                    columValue = AllText.Substring(start, length);
                    AllText = AllText.Substring(start + length);
                }
                else
                {
                    columValue = AllText.Substring(start);
                }
                lstFlatCol.Remove(columName);
                AllTextOut = AllText;

                return columValue;
            }
            catch (Exception ex) {

                AllTextOut = AllText;
                return "";
            }
        }

    }
}
