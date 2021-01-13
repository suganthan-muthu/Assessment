using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailDIR.DataAccess;
using MailDIR.Repository;
using MailDIR.Services.contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MailDIR.App.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUsersRepo _users;
        private readonly IMailItemRepo _mailItem;
        private readonly IMailDetailsViewModelRepo _mailDtlaVM;
        private readonly IMailDetailRepo _mailDetails;

        IImportToSQLRepo _Impo;
        public HomeController(
            IUsersRepo users,
            IImportToSQLRepo Impo,
            IMailItemRepo mailItem,
            IMailDetailRepo mailDetails,
            IMailDetailsViewModelRepo mailDtlaVM
            )
        {
            _users = users;
            _Impo = Impo;
            _mailItem = mailItem;
            _mailDetails = mailDetails;
            _mailDtlaVM = mailDtlaVM;


        }

        public IActionResult Users()
        {
            //List<MailDetailsViewModel> lst = new List<MailDetailsViewModel>();
            //lst = _mailDtlaVM.GetAll();
            //IEnumerable<User> user = _users.GetAll();

            IEnumerable<User> user = _users.GetAllUsersMails();           
            return (IActionResult)View(user);
        }
              
        public IActionResult MailItems()
        {
            IEnumerable<MailItem> mail = _mailItem.GetAll();
            return (IActionResult)View(mail);
        }

        public IActionResult MailItemsUserId(int Id)
        {
            IEnumerable<MailItem> mail = _mailItem.GetAll(Id);
            return (IActionResult)View("MailItems",mail);
        }

        public IActionResult MailDetails()
        {
            IEnumerable<MailDetailsViewModel> mailDetails = _mailDtlaVM.GetAll();
            return (IActionResult)View(mailDetails);
        }

        public IActionResult MailDetailsByMailItemId(int Id)
        {
            IEnumerable<MailDetailsViewModel> mailDetails = _mailDtlaVM.MailDetailsByMailItemId(Id);
            return (IActionResult)View("MailDetails",mailDetails);
        }

        [HttpGet]
        public IActionResult MailDetailsBySearch()
        {
            int Id = 0;
            IEnumerable<MailDetailsViewModel> mailDetails = _mailDtlaVM.MailDetailsByMailItemId(Id);
            return (IActionResult)View("MailDetailsBySearch", mailDetails);
        }


        [HttpPost]
        public IActionResult MailDetailsBySearch(string searchMesaage)
        {
            IEnumerable<MailDetailsViewModel> mailDetails = _mailDtlaVM.MailDetailsBySearch(searchMesaage);
            return (IActionResult)View("MailDetailsBySearch", mailDetails);
        }



        public IActionResult ConvertToSQL()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult ImportToSQL()
        {
            _Impo.ImportToSQL();
            return null;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}