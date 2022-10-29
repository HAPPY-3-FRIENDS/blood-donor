using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IVolunteerInCampaignRepository
    {
        public List<VolunteerInCampaign> GetVolunteerInCampaigns();
        public List<VolunteerInCampaign> GetVolunteerInCampaignsByCampaignId(int campaignId);
        public List<VolunteerInCampaign> GetVolunteerInCampaignsByVolunteerId(string volunteerId);
        public VolunteerInCampaign GetVolunteerInCampaignById(int volunteerInCampaignId);
        public void CreateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign);
        public void UpdateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign);
    }
}
