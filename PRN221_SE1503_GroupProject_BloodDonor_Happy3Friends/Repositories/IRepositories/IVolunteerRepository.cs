using BusinessObjects.Models;

namespace Repositories.IRepositories
{
    public interface IVolunteerRepository
    {
        bool CheckLogin(string phone, string password);
        Volunteer GetVolunteerByPhone(string phone);
    }
}