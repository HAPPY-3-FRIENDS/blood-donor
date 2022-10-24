using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        bool IVolunteerRepository.CheckLogin(string phone, string password) => VolunteerDAO.Instance.CheckLogin(phone, password);

        Volunteer IVolunteerRepository.GetVolunteerByPhone(string phone) => VolunteerDAO.Instance.GetCustomerByPhone(phone);
    }
}