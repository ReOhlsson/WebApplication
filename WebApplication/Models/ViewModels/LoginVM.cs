using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class LoginVM
    {
        //Errormessage
        [Required(ErrorMessage="Du måste fylla i ditt användarnamn!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Du måste fylla i ditt lösenord!")]
        //Ser till att inmatningsfältet blir av typen Passsword
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Role Role { get; set; } = new Role();

    }
}