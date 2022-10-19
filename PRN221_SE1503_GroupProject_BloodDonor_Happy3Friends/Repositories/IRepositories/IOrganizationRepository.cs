using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IOrganizationRepository
    {
        public List<Organization> GetOrganizations();
        public Organization GetOrganizationById(int id);
        public Organization GetOrganizationByName(string name);
        public void CreateOrganization(Organization organization);  
        public void UpdateOrganization(Organization organization);
        //public void DeleteOrganization(Organization organization);
    }
}
