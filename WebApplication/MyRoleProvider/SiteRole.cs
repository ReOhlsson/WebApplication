﻿using RepoAndUnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication.MyRoleProvider
{
    public class SiteRole : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            ProgramDbContext dbContect = new ProgramDbContext();
            string data = dbContect.Person.Where(x => x.Username == username).FirstOrDefault().Role.Roles;
            string[] result = { data };
            return result;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //Checks if an user is authorized or not
        public override bool IsUserInRole(string username, string roleName)
        {
            ProgramDbContext dbContect = new ProgramDbContext();
            var data = dbContect.Person.Where(x => x.Username == username && x.Role.Roles == roleName).FirstOrDefault();

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}