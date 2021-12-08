using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class ProductController
    {
        static Database db = new Database();

        public static void AddProduct(string p_name, string unit)
        {
            Product product = new Product();

            product.product_name = p_name;
            product.units = unit;


            db.Products.AddProduct(product);
        }
        //public static void UpdateProduct(string pname, string u)
        //{
        //    Product product = new Product()
        //    {
        //        product_name = pname,
        //        units = u,
        //    };
        //    //db.Users.UpdateUser(u);
        //    db.Products.UpdateProduct(product);

        //}
    }
}
