using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccessObjects
{
    public class VolunteerDAO
    {
        private static VolunteerDAO instance;
        private static readonly object instanceLock = new object();
        private VolunteerDAO() { }
        public static VolunteerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new VolunteerDAO();
                    }
                    return instance;
                }
            }
        }

        public bool CheckLogin(string phone, string password)
        {
            Volunteer volunteer = null;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteer = bloodDonorContext.Volunteers.SingleOrDefault(x => x.Phone == phone && x.Password == password);
                if (volunteer != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Volunteer GetVolunteerByPhone(string phone)
        {
            Volunteer volunteer = null;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                volunteer = bloodDonorContext.Volunteers.SingleOrDefault(x => x.Phone == phone);
                if (volunteer != null)
                {
                    volunteer.BloodType = EnumExtensions.GetDisplayName(volunteer.BloodType.ToEnum<BloodType>());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteer;
        }

        public void CreateVolunteer(Volunteer volunteer)
        {
            try
            {
                Volunteer _volunteer = GetVolunteerByPhone(volunteer.Phone);
                if (_volunteer == null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    volunteer.BloodType = BloodType.UNDEFINED.ToString();
                    bloodDonorContext.Volunteers.Add(volunteer);
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Tình nguyện viên này không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateVolunteer(Volunteer volunteer)
        {
            try
            {
                Volunteer _volunteer = GetVolunteerByPhone(volunteer.Phone);
                if (_volunteer != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    bloodDonorContext.Entry<Volunteer>(volunteer).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Tình nguyện viên này không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}