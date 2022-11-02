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
    public class BloodRequestRepository : IBloodRequestRepository
    {
        public List<BloodRequest> GetBloodRequestsByVolunteerPhone(string phone) => BloodRequestDAO.Instance.GetBloodRequestsByVolunteerPhone(phone);

        public List<BloodRequest> GetBloodRequestsByOrganizationId(int organizationId) => BloodRequestDAO.Instance.GetBloodRequestsByOrganizationId(organizationId);

        public BloodRequest GetBloodRequestById(int id) => BloodRequestDAO.Instance.GetBloodRequestById(id);

        public void CreateBloodRequest(BloodRequest bloodRequest) => BloodRequestDAO.Instance.CreateBloodRequest(bloodRequest);

        public void DeleteBloodRequest(int id) => BloodRequestDAO.Instance.DeleteBloodRequest(id);
    }
}