using RepoAndUnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RepoAndUnitOfWork.Security
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        private readonly string[] userRole;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public AuthorizeRoleAttribute(params string[] roles)
        {
            this.userRole = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = false;

            foreach (var role in userRole)
            {
                authorized = unitOfWork.PersonRepository.IsUserRole(httpContext.User.Identity.Name, role);
                if (authorized) return authorized;
            }

            return authorized;
        }
    }
}
