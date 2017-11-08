using Newtonsoft.Json;
using RepoAndUnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //    // Send an email with this link
                //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //    return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}