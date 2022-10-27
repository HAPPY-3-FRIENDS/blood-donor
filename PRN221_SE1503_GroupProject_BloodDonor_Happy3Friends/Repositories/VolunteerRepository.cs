using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepositories;

namespace Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        bool IVolunteerRepository.CheckLogin(string phone, string password) => VolunteerDAO.Instance.CheckLogin(phone, password);

        Volunteer IVolunteerRepository.GetVolunteerByPhone(string phone) => VolunteerDAO.Instance.GetCustomerByPhone(phone);
    }
}