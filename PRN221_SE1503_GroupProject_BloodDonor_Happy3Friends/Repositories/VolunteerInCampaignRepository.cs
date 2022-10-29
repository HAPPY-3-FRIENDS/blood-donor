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
    public class VolunteerInCampaignRepository : IVolunteerInCampaignRepository
    {
        public void CreateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign) => VolunteerInCampaignDAO.Instance.CreateVolunteerInCampaign(volunteerInCampaign);

        public List<VolunteerInCampaign> GetVolunteerInCampaigns() => VolunteerInCampaignDAO.Instance.GetVolunteerInCampaigns();

        public VolunteerInCampaign GetVolunteerInCampaignById(int volunteerInCampaignId) => VolunteerInCampaignDAO.Instance.GetVolunteerInCampaignById(volunteerInCampaignId);

        public List<VolunteerInCampaign> GetVolunteerInCampaignsByVolunteerId(string volunteerId) => VolunteerInCampaignDAO.Instance.GetVolunteerInCampaignsByVolunteerId(volunteerId);

        public List<VolunteerInCampaign> GetVolunteerInCampaignsByCampaignId(int campaignId) => VolunteerInCampaignDAO.Instance.GetVolunteerInCampaignsByCampaignId(campaignId);

        public void UpdateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign) => VolunteerInCampaignDAO.Instance.UpdateVolunteerInCampaign(volunteerInCampaign);
    }
}
