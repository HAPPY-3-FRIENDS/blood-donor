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
                    .Include(v => v.VolunteerHealth)
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
                volunteerInCampaigns = bloodDonorContext.VolunteerInCampaigns
                    .Include(v => v.Campaign)
                    .Include(v => v.Volunteer)
                    .Include(v => v.VolunteerHealth)
                    .Where(v => v.CampaignId == campaignId)
                    .OrderByDescending(v => v.RegistrationDate)
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

        public List<VolunteerInCampaign> GetVolunteerInCampaignsByVolunteerId(string volunteerId)
        {
            List<VolunteerInCampaign> volunteerInCampaigns;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaigns = bloodDonorContext.VolunteerInCampaigns
                    .Include(v => v.Campaign)
                    .Include(v => v.Volunteer)
                    .Include(v => v.VolunteerHealth)
                    .Where(v => v.VolunteerId == volunteerId)
                    .OrderByDescending(v => v.RegistrationDate)
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

        public VolunteerInCampaign GetVolunteerInCampaignById(int volunteerInCampaignId)
        {
            VolunteerInCampaign volunteerInCampaign = null;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteerInCampaign = bloodDonorContext.VolunteerInCampaigns
                    .Include(v => v.Campaign)
                    .Include(v => v.Volunteer)
                    .Include(v => v.VolunteerHealth)
                    .SingleOrDefault(v => v.Id == volunteerInCampaignId);
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

                Volunteer _volunteer = VolunteerDAO.Instance.GetVolunteerByPhone(volunteerInCampaign.VolunteerId);
                Campaign _campaign = CampaignDAO.Instance.GetCampaignById(volunteerInCampaign.CampaignId);

                if (!_volunteer.BloodType.Equals(EnumExtensions.GetDisplayName(BloodType.UNDEFINED)))
                {
                    if (!_volunteer.BloodType.Equals(_campaign.BloodTypeRequired))
                    {
                        throw new Exception("Nhóm máu của bạn không phù hợp trong chiến dịch này!");
                    }
                }

                volunteerInCampaign.BloodType = _volunteer.BloodType;
                volunteerInCampaign.BloodType = volunteerInCampaign.BloodType.GetValueFromName<BloodType>().ToString();

                DateTime registrationDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                volunteerInCampaign.RegistrationDate = registrationDate;

                volunteerInCampaign.Status = VolunteerInCampaignStatus.NEW.ToString();

                var today = DateTime.Today;
                var age = today.Year - _volunteer.DateOfBirth.Year;

                if (_volunteer.DateOfBirth.Date > today.AddYears(-age)) age--;

                VolunteerHealth volunteerHealth = new VolunteerHealth();
                volunteerInCampaign.VolunteerHealth = volunteerHealth;

                if (age >= 18)
                {
                    bloodDonorContext.VolunteerInCampaigns.Add(volunteerInCampaign);
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Bạn chưa đủ 18 tuổi nên không được đăng ký tham gia chiến dịch!");
                }
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

                    Volunteer _volunteer = VolunteerDAO.Instance.GetVolunteerByPhone(volunteerInCampaign.VolunteerId);
                    _volunteer.BloodType = volunteerInCampaign.BloodType;
                    if (_volunteerInCampaign.Status == EnumExtensions.GetDisplayName(VolunteerInCampaignStatus.JOINED))
                    {
                        _volunteer.LastDonatedDate = _volunteerInCampaign.DonatedDate;
                    }

                    bloodDonorContext.Entry<Volunteer>(_volunteer).State = EntityState.Modified;
                    bloodDonorContext.Entry<VolunteerHealth>(volunteerInCampaign.VolunteerHealth).State = EntityState.Modified;
                    bloodDonorContext.Entry<VolunteerInCampaign>(volunteerInCampaign).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Tình nguyện viên trong chiến dịch này không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}