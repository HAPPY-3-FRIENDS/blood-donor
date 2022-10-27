using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class CampaignDAO
    {
        private static CampaignDAO instance = null;
        private static readonly object instanceLock = new object();
        private CampaignDAO() { }
        public static CampaignDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CampaignDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Campaign> GetCampaigns()
        {
            List<Campaign> campaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                campaigns = bloodDonorContext.Campaigns.Include(c => c.Organization).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return campaigns;
        }

        public List<Campaign> GetCampaignsByOrganizationId(int organizationId)
        {
            List<Campaign> campaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                campaigns = bloodDonorContext.Campaigns.Include(c => c.Organization).Where(c => c.Organization.Id == organizationId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return campaigns;
        }

        public void CreateCampaign(Campaign campaign)
        {
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                bloodDonorContext.Campaigns.Add(campaign);
                bloodDonorContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}