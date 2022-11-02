using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IBloodRequestRepository
    {
        public List<BloodRequest> GetBloodRequestsByVolunteerPhone(string phone);
        public List<BloodRequest> GetBloodRequestsByOrganizationId(int organizationId);
        public BloodRequest GetBloodRequestById(int id);
        public void CreateBloodRequest(BloodRequest bloodRequest);
        public void UpdateBloodRequest(BloodRequest bloodRequest);
        public void DeleteBloodRequest(int id);
    }
}
