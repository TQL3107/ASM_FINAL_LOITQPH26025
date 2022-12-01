using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.A.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.B.BUS.Services
{
    internal class UserService
    {
        UserRepository ur = new UserRepository();
        public bool CheckEmtyDB()
        {
            return ur.GetAll() == null;
        }
        public User CheckLogin(string username, string password)
        {
            User us = ur.GetUser(username, password);
            return us;
        }
        
    }
}
