using StudentManagement.Models;
using System.Linq;

namespace StudentManagement.Function
{
    internal class AccountFunc
    {
        ConnectDB connect = new ConnectDB();

        public void Create(string user, string pass)
        {
            Account account = new Account() //Tự động tạo account
            {
                username = user,
                password = pass,
            };
            connect.Accounts.Add(account); //Thêm account vào csdl
            connect.SaveChanges();
        }

        public void Delete(string user)
        {
            Account deleteAcount = connect.Accounts.SingleOrDefault(x => x.username == user);
            if (deleteAcount != null)
            {
                connect.Accounts.Remove(deleteAcount); //Xóa account
                connect.SaveChanges();
            }
        }
    }
}
