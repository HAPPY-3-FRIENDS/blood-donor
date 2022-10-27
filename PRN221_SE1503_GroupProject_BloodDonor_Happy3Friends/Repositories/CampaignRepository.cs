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

        public Campaign GetCampaignById(int id) => CampaignDAO.Instance.GetCampaignById(id);

        public void CreateCampaign(Campaign campaign) => CampaignDAO.Instance.CreateCampaign(campaign);

        public void UpdateCampaign(Campaign campaign) => CampaignDAO.Instance.UpdateCampaign(campaign);

        public void DeleteCampaignById(int id) => CampaignDAO.Instance.DeleteCampaignById(id);
    }
}