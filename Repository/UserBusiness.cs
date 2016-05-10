using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Repository
{
    public class UserBusiness : IUserBusiness
    {
        string IUserBusiness.Save(User user)
        {
            StringBuilder sb = new StringBuilder();
            string msg = string.Empty;
            string path = @"D:\Users.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {

                    sb.Append(user.Id);
                    sb.Append("-");
                    sb.Append(user.Name);
                    sb.Append("-");
                    sb.Append(user.LastName);
                    tw.WriteLine(sb);
                    tw.Close();
                    msg = "User Yerel Disk D 'ye kaydedildi.";
                }

            }

            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    sb.Append(user.Id);
                    sb.Append("-");
                    sb.Append(user.Name);
                    sb.Append("-");
                    sb.Append(user.LastName);
                    tw.WriteLine(sb);
                    msg = "User zaten var";
                    tw.Close();
                }
            }
            return msg;
        }

        void IUserBusiness.Delete(int id)
        {
            Console.WriteLine("Silinme işlemi yapıldı.");
        }
    }
}
