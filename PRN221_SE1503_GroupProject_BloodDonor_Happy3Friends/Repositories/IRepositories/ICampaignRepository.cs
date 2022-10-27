using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories.IRepositories
{
    public interface ICampaignRepository
    {
        public List<Campaign> GetCampaigns();
        public List<Campaign> GetCampaignsByOrganizationId(int organizationId);
        public void CreateCampaign(Campaign campaign);
    }
}