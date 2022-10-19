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
    public class OrganizationRepository : IOrganizationRepository
    {
        public List<Organization> GetOrganizations() => OrganizationDAO.Instance.GetOrganizations();

        public Organization GetOrganizationById(int id) => OrganizationDAO.Instance.GetOrganizationById(id);

        public Organization GetOrganizationByName(string name) => OrganizationDAO.Instance.GetOrganizationByName(name);

        public void CreateOrganization(Organization organization) => OrganizationDAO.Instance.CreateOrganization(organization);

        public void UpdateOrganization(Organization organization) => OrganizationDAO.Instance.UpdateOrganization(organization);

        //public void DeleteOrganization(Organization organization) => OrganizationDAO.Instance.DeleteOrganization(organization);
    }
}
