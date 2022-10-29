using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class VolunteerInCampaignDAO
    {
        private static VolunteerInCampaignDAO instance = null;
        private static readonly object instanceLock = new object();
        private VolunteerInCampaignDAO() { }
        public static VolunteerInCampaignDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new VolunteerInCampaignDAO();
                    }
                    return instance;
                }
            }
        }

        public List<VolunteerInCampaign> GetVolunteerInCampaigns()
        {
            List<VolunteerInCampaign> volunteerInCampaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaigns = bloodDonorContext.VolunteerInCampaigns
                    .Include(v => v.Campaign)
                    .Include(v => v.Volunteer)
                    .ToList();
                if (volunteerInCampaigns.Count > 0)
                {
                    volunteerInCampaigns.ForEach(v =>
                    {
                        v.BloodType = EnumExtensions.GetDisplayName(v.BloodType.ToEnum<BloodType>());
                        v.Status = EnumExtensions.GetDisplayName(v.Status.ToEnum<VolunteerInCampaignStatus>());
                    });
                }
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteerInCampaigns;
        }

        public List<VolunteerInCampaign> GetVolunteerInCampaignsByCampaignId(int campaignId)
        {
            List<VolunteerInCampaign> volunteerInCampaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaigns = bloodDonorContext.VolunteerInCampaigns.Include(v => v.Campaign).Include(v => v.Volunteer).Where(v => v.CampaignId == campaignId).ToList();
                if (volunteerInCampaigns.Count > 0)
                {
                    volunteerInCampaigns.ForEach(v =>
                    {
                        v.BloodType = EnumExtensions.GetDisplayName(v.BloodType.ToEnum<BloodType>());
                        v.Status = EnumExtensions.GetDisplayName(v.Status.ToEnum<VolunteerInCampaignStatus>());
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteerInCampaigns;
        }

        public List<VolunteerInCampaign> GetVolunteerInCampaignsByVolunteerId(string volunteerId)
        {
            List<VolunteerInCampaign> volunteerInCampaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaigns = bloodDonorContext.VolunteerInCampaigns.Include(v => v.Campaign).Include(v => v.Volunteer).Where(v => v.VolunteerId == volunteerId).ToList();
                if (volunteerInCampaigns.Count > 0)
                {
                    volunteerInCampaigns.ForEach(v =>
                    {
                        v.BloodType = EnumExtensions.GetDisplayName(v.BloodType.ToEnum<BloodType>());
                        v.Status = EnumExtensions.GetDisplayName(v.Status.ToEnum<VolunteerInCampaignStatus>());
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteerInCampaigns;
        }

        public VolunteerInCampaign GetVolunteerInCampaignById(int volunteerInCampaignId)
        {
            VolunteerInCampaign volunteerInCampaign = null;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaign = bloodDonorContext.VolunteerInCampaigns.Include(v => v.Campaign).Include(v => v.Volunteer).SingleOrDefault(v => v.Id == volunteerInCampaignId);
                if (volunteerInCampaign != null)
                {
                    volunteerInCampaign.Status = EnumExtensions.GetDisplayName(volunteerInCampaign.Status.ToEnum<VolunteerInCampaignStatus>());
                    volunteerInCampaign.BloodType = EnumExtensions.GetDisplayName(volunteerInCampaign.BloodType.ToEnum<BloodType>());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteerInCampaign;
        }

        public void CreateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign)
        {
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaign.BloodType = volunteerInCampaign.BloodType.GetValueFromName<BloodType>().ToString();
                volunteerInCampaign.Status = VolunteerInCampaignStatus.NEW.ToString();
                bloodDonorContext.VolunteerInCampaigns.Add(volunteerInCampaign);
                bloodDonorContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateVolunteerInCampaign(VolunteerInCampaign volunteerInCampaign)
        {
            try
            {
                VolunteerInCampaign _volunteerInCampaign = GetVolunteerInCampaignById(volunteerInCampaign.Id);
                if (_volunteerInCampaign != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    volunteerInCampaign.BloodType = volunteerInCampaign.BloodType.GetValueFromName<BloodType>().ToString();
                    volunteerInCampaign.Status = volunteerInCampaign.Status.GetValueFromName<VolunteerInCampaignStatus>().ToString();
                    bloodDonorContext.Entry<VolunteerInCampaign>(volunteerInCampaign).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The volunteerInCampaign does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
