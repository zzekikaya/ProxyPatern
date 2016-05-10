using Model;

namespace Repository
{
    public interface IUserBusiness
    {
        string Save(User user);
        void Delete(int id);
    }
}