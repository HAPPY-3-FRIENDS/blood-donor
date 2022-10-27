using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories.IRepositories
{
    public interface ICampaignRepository
    {
        public List<Campaign> GetCampaigns();
        public List<Campaign> GetCampaignsByOrganizationId(int organizationId);
        public Campaign GetCampaignById(int id);
        public void CreateCampaign(Campaign campaign);
        public void UpdateCampaign(Campaign campaign);
        public void DeleteCampaignById(int id);
    }
}