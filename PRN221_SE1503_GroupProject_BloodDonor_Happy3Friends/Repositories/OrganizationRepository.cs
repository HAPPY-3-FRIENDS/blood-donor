using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepositories;
using System.Collections.Generic;

namespace Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public List<Organization> GetOrganizations() => OrganizationDAO.Instance.GetOrganizations();

        public Organization GetOrganizationById(int id) => OrganizationDAO.Instance.GetOrganizationById(id);

        public Organization GetOrganizationByName(string name) => OrganizationDAO.Instance.GetOrganizationByName(name);

        public Organization GetOrganizationByUserName(string userName) => OrganizationDAO.Instance.GetOrganizationByUserName(userName);

        public void CreateOrganization(Organization organization) => OrganizationDAO.Instance.CreateOrganization(organization);

        public void UpdateOrganization(Organization organization) => OrganizationDAO.Instance.UpdateOrganization(organization);

        public void DeleteOrganization(Organization organization) => OrganizationDAO.Instance.DeleteOrganization(organization);
        
        public void DeleteOrganizationById(int id) => OrganizationDAO.Instance.DeleteOrganizationById(id);

        public bool CheckLogin(string userName, string password) => OrganizationDAO.Instance.CheckLogin(userName, password);
    }
}