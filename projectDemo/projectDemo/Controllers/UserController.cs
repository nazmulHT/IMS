using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class UserController
    {
        static Database db = new Database();
        public static void AddUser(string f_name, string l_name, string uname, string pass, string email, string contct)
        {
            User user = new User();

            user.first_name = f_name;
            user.last_name = l_name;
            user.username = uname;
            user.password = pass;
            user.email = email;
            user.contact = contct;
            

            db.Users.AddUser(user);
            
        }
        
        public static void DeleteUser(int id)
        {
            db.Users.DeleteUser(id);
        }
    }
}
