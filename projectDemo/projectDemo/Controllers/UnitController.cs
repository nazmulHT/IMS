using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class UnitController
    {
        static Database db = new Database();

        public static void AddUnits(string unit_name)
        {
            //User user = new User();
            Unit unit = new Unit();

            //user.first_name = f_name;
            unit.unit = unit_name;

            db.Units.AddUnits(unit);

            //db.Users.AddUser(user);

        }
        public static void DeleteUnit(int id)
        {

            //id = id;

            db.Units.DeleteUnit(id);
        }
    }
}
