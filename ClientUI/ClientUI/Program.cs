using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //proxy dll referans gösterdikten sonra bizden 2 parametre istiyor;
            var proxy = ProxyPatern.ProxyGenerator<IUserBusiness, UserBusiness>.CreateProxy();
            var user = new User()
            {
                Name = "zeki",
                LastName = "Kaya"
            };

            var result = proxy.Save(user);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }


}
