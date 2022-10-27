using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories.IRepositories
{
    public interface IOrganizationRepository
    {
        public List<Organization> GetOrganizations();
        public Organization GetOrganizationById(int id);
        public Organization GetOrganizationByName(string name);
        public Organization GetOrganizationByUserName(string userName);
        public void CreateOrganization(Organization organization);  
        public void UpdateOrganization(Organization organization);
        public void DeleteOrganizationById(int id);
        bool CheckLogin(string userName, string password);
    }
}