using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepositories;
using System.Collections.Generic;

namespace Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public List<Campaign> GetCampaigns() => CampaignDAO.Instance.GetCampaigns();

        public List<Campaign> GetCampaignsByOrganizationId(int organizationId) => CampaignDAO.Instance.GetCampaignsByOrganizationId(organizationId);

        public void CreateCampaign(Campaign campaign) => CampaignDAO.Instance.CreateCampaign(campaign);
    }
}