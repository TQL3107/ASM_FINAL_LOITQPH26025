using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.A.DAL.Repositories
{
    internal class UserRepository
    {
        ASMFINAL_NET103Context context = new ASMFINAL_NET103Context();
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }
        public User GetUser( string username, string password ) 
        {
            User user = context.Users.FirstOrDefault( x => x.Username == username && x.Password == password );
            return user;
        }
        
    }
}
