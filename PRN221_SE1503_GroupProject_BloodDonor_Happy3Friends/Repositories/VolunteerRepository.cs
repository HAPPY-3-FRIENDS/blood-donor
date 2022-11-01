using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepositories;

namespace Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        bool IVolunteerRepository.CheckLogin(string phone, string password) => VolunteerDAO.Instance.CheckLogin(phone, password);

        Volunteer IVolunteerRepository.GetVolunteerByPhone(string phone) => VolunteerDAO.Instance.GetVolunteerByPhone(phone);

        public void CreateVolunteer(Volunteer volunteer) => VolunteerDAO.Instance.CreateVolunteer(volunteer);

        public void UpdateVolunteer(Volunteer volunteer) => VolunteerDAO.Instance.UpdateVolunteer(volunteer);
    }
}