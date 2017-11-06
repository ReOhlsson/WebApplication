using RepoAndUnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                var person = unitOfWork.PersonRepository.GetUserCredentials(model.Username, model.Password);

                if (unitOfWork.PersonRepository.GetUserCredentials(model.Username, model.Password) != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Du har angett ett felaktigt användarnamn eller lösenord.");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}