using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var bloodDonorContext = new BloodDonorContext();
                volunteer = bloodDonorContext.Volunteers.SingleOrDefault(x => x.Phone == phone && x.Password == password);
                if (volunteer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Volunteer GetCustomerByPhone(string phone)
        {
            Volunteer volunteer = null;
            try
            {
                var bloodDonorContext = new BloodDonorContext();
                volunteer = bloodDonorContext.Volunteers.SingleOrDefault(x => x.Phone == phone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return volunteer;
        }
    }
}
