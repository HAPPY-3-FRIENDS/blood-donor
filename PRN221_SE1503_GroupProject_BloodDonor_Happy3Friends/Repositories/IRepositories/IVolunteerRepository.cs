using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IVolunteerRepository
    {
        bool CheckLogin(string phone, string password);
        Volunteer GetVolunteerByPhone(string phone);
    }
}
