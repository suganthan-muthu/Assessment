using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailDIR.Services.implementation
{
    public class MailDetailsViewModelRepo : IMailDetailsViewModelRepo
    {
        private readonly ApplicationDbContext _context;
        public MailDetailsViewModelRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<MailDetailsViewModel> GetAll()
        //{
        //    var ret = from u in _context.Users
        //               join m in _context.MailItems on u.Id equals m.UsersId into um
        //               from umi in um.DefaultIfEmpty()
        //               join md in _context.MailDetails on umi.Id equals md.MailItemsId into mim
        //               from mimu in mim.DefaultIfEmpty()
        //               select new MailDetailsViewModel
        //               {
        //                   UserName = u.Name,
        //                   MailItemName = umi.Name,
        //                   Date = mimu.Date,
        //                   From = mimu.From,
        //                   To = mimu.To,
        //                   cc = mimu.cc,
        //                   Bcc = mimu.Bcc,
        //                   Subject = mimu.Subject,
        //                   X_FileName = mimu.X_FileName,
        //                   MailMessage = mimu.MailMessage
        //               };
        //    return ret.AsEnumerable();
        //}

        public IEnumerable<MailDetailsViewModel> GetAll()
        {
            var ret = (from u in _context.Users
                      join m in _context.MailItems on u.Id equals m.UsersId into um
                      from umi in um.DefaultIfEmpty()
                      join md in _context.MailDetails on umi.Id equals md.MailItemsId into mim
                      from mimu in mim.DefaultIfEmpty()
                      select new MailDetailsViewModel
                      {
                          UserName = u.Name,
                          MailItemName = umi.Name,
                          Date = mimu.Date,
                          From = mimu.From,
                          To = mimu.To,
                          cc = mimu.cc,
                          Bcc = mimu.Bcc,
                          Subject = mimu.Subject,
                          X_FileName = mimu.X_FileName,
                          MailMessage = mimu.MailMessage
                      }).ToList();
            return ret.AsEnumerable();
        }

        public IEnumerable<MailDetailsViewModel> MailDetailsByMailItemId(int Id)
        {
            var ret = (from u in _context.Users
                       join m in _context.MailItems on u.Id equals m.UsersId into um
                       from umi in um.DefaultIfEmpty()
                       join md in _context.MailDetails on umi.Id equals md.MailItemsId into mim
                       from mimu in mim.DefaultIfEmpty()
                       where umi.Id == Id
                       select new MailDetailsViewModel
                       {
                           UserName = u.Name,
                           MailItemName = umi.Name,
                           Date = mimu.Date,
                           From = mimu.From,
                           To = mimu.To,
                           cc = mimu.cc,
                           Bcc = mimu.Bcc,
                           Subject = mimu.Subject,
                           X_FileName = mimu.X_FileName,
                           MailMessage = mimu.MailMessage
                       }).ToList();
            return ret.AsEnumerable();
        }

        public IEnumerable<MailDetailsViewModel> MailDetailsBySearch(string searchMesaage)
        {
            var ret = (from u in _context.Users
                       join m in _context.MailItems on u.Id equals m.UsersId into um
                       from umi in um.DefaultIfEmpty()
                       join md in _context.MailDetails on umi.Id equals md.MailItemsId into mim
                       from mimu in mim.DefaultIfEmpty()
                       where mimu.MailMessage.Contains(searchMesaage)
                       select new MailDetailsViewModel
                       {
                           UserName = u.Name,
                           MailItemName = umi.Name,
                           Date = mimu.Date,
                           From = mimu.From,
                           To = mimu.To,
                           cc = mimu.cc,
                           Bcc = mimu.Bcc,
                           Subject = mimu.Subject,
                           X_FileName = mimu.X_FileName,
                           MailMessage = mimu.MailMessage
                       }).ToList();
            return ret.AsEnumerable();
        }

        public IEnumerable<MailDetailsViewModel> MailDetailsByUserId(int Id)
        {
            var ret = (from u in _context.Users
                       join m in _context.MailItems on u.Id equals m.UsersId into um
                       from umi in um.DefaultIfEmpty()
                       join md in _context.MailDetails on umi.Id equals md.MailItemsId into mim
                       from mimu in mim.DefaultIfEmpty()
                       where u.Id == Id
                       select new MailDetailsViewModel
                       {
                           UserName = u.Name,
                           MailItemName = umi.Name,
                           Date = mimu.Date,
                           From = mimu.From,
                           To = mimu.To,
                           cc = mimu.cc,
                           Bcc = mimu.Bcc,
                           Subject = mimu.Subject,
                           X_FileName = mimu.X_FileName,
                           MailMessage = mimu.MailMessage
                       }).ToList();
            return ret.AsEnumerable();
        }

    }
}

