using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class OrganizationDAO
    {
        private static OrganizationDAO instance;
        private static readonly object instanceLock = new object();
        private OrganizationDAO() { }
        public static OrganizationDAO Instance 
        { 
            get 
            { 
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrganizationDAO();
                    }
                    return instance;
                }
            } 
        }

        public List<Organization> GetOrganizations()
        {
            List<Organization> organizations;
            try
            {
                var bloodDonorContext = new BloodDonorContext();
                organizations = bloodDonorContext.Organizations.ToList();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return organizations;
        }

        public Organization GetOrganizationById(int organizationId)
        {
            Organization organization = null;
            try
            {
                var bloodDonorContext = new BloodDonorContext();
                organization = bloodDonorContext.Organizations.SingleOrDefault(x => x.Id == organizationId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return organization;
        }

        public Organization GetOrganizationByName(string name)
        {
            Organization organization = null;
            try
            {
                var bloodDonorContext = new BloodDonorContext();
                organization = bloodDonorContext.Organizations.SingleOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return organization;
        }

        public void CreateOrganization(Organization organization)
        {
            try
            {
                var bloodDonorContext = new BloodDonorContext();
                bloodDonorContext.Organizations.Add(organization);
                bloodDonorContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrganization(Organization organization)
        {
            try
            {
                Organization _organization = GetOrganizationById(organization.Id);
                if (_organization != null)
                {
                    var bloodDonorContext = new BloodDonorContext();
                    bloodDonorContext.Entry<Organization>(organization).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The organization does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrganization(Organization organization)
        {
            try
            {
                Organization _organization = GetOrganizationById(organization.Id);
                if (_organization != null)
                {
                    var bloodDonorContext = new BloodDonorContext();
                    bloodDonorContext.Organizations.Remove(organization);
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The organization does not exist!");
                }
            }
        }
    }
}
