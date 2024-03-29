﻿using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
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
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                organization = bloodDonorContext.Organizations.Include(x => x.Campaigns).SingleOrDefault(x => x.Id == organizationId);
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
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                organization = bloodDonorContext.Organizations.SingleOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return organization;
        }

        public Organization GetOrganizationByUserName(string userName)
        {
            Organization organization = null;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                organization = bloodDonorContext.Organizations.SingleOrDefault(x => x.Username == userName);
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
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
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
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    bloodDonorContext.Entry<Organization>(organization).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Tổ chức không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrganizationById(int id)
        {
            try
            {
                Organization _organization = GetOrganizationById(id);
                if (_organization != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    if (_organization.Campaigns.Count == 0)
                    {
                        bloodDonorContext.Organizations.Remove(_organization);
                        bloodDonorContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Không thể xóa tổ chức có chiến dịch");
                    }
                }
                else
                {
                    throw new Exception("Tổ chức không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckLogin(string userName, string password)
        {
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                Organization organization = bloodDonorContext.Organizations.Where(o => o.Username.Equals(userName) && o.Password.Equals(password)).FirstOrDefault();
                if (organization != null)
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    }
}