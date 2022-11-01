using BusinessObjects.Models;

namespace Repositories.IRepositories
{
    public interface IVolunteerRepository
    {
        public bool CheckLogin(string phone, string password);
        public Volunteer GetVolunteerByPhone(string phone);
        public void CreateVolunteer(Volunteer volunteer);
        public void UpdateVolunteer(Volunteer volunteer);
    }
}