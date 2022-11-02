using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BloodRequestDAO
    {
        private static BloodRequestDAO instance = null;
        private static readonly object instanceLock = new object();
        private BloodRequestDAO() { }
        public static BloodRequestDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BloodRequestDAO();
                    }
                    return instance;
                }
            }
        }

        public List<BloodRequest> GetBloodRequestsByVolunteerPhone(string phone)
        {
            List<BloodRequest> bloodRequests;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                bloodRequests = bloodDonorContext.BloodRequests
                    .Include(b => b.Volunteer)
                    .Include(b => b.Organization)
                    .Where(b => b.VolunteerId == phone)
                    .ToList();
                if (bloodRequests.Count > 0)
                {
                    bloodRequests.ForEach(b =>
                    {
                        b.Status = EnumExtensions.GetDisplayName(b.Status.ToEnum<BloodRequestStatus>());
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bloodRequests;
        }

        public List<BloodRequest> GetBloodRequestsByOrganizationId(int organizationId)
        {
            List<BloodRequest> bloodRequests;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                bloodRequests = bloodDonorContext.BloodRequests
                    .Include(b => b.Volunteer)
                    .Include(b => b.Organization)
                    .Where(b => b.OrganizationId == organizationId)
                    .ToList();
                if (bloodRequests.Count > 0)
                {
                    bloodRequests.ForEach(b =>
                    {
                        b.Status = EnumExtensions.GetDisplayName(b.Status.ToEnum<BloodRequestStatus>());
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bloodRequests;
        }

        public BloodRequest GetBloodRequestById(int id)
        {
            BloodRequest bloodRequest;
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                bloodRequest = bloodDonorContext.BloodRequests
                    .Include(b => b.Volunteer)
                    .Include(b => b.Organization)
                    .Where(b => b.Id == id)
                    .FirstOrDefault();
                if (bloodRequest != null)
                {
                    bloodRequest.Status = EnumExtensions.GetDisplayName(bloodRequest.Status.ToEnum<BloodRequestStatus>());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bloodRequest;
        }

        public void CreateBloodRequest(BloodRequest bloodRequest)
        {
            try
            {
                var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                DateTime requestDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                bloodRequest.RequestDate = requestDate;
                bloodRequest.Status = BloodRequestStatus.NEW.ToString();

                bloodDonorContext.BloodRequests.Add(bloodRequest);
                bloodDonorContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBloodRequest(BloodRequest bloodRequest)
        {
            try
            {
                BloodRequest _bloodRequest = GetBloodRequestById(bloodRequest.Id);
                if (_bloodRequest != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    bloodRequest.Status = bloodRequest.Status.GetValueFromName<BloodRequestStatus>().ToString();
                    bloodDonorContext.Entry<BloodRequest>(bloodRequest).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Yêu cầu không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBloodRequest(int id)
        {
            try
            {
                BloodRequest _bloodRequest = GetBloodRequestById(id);
                if (_bloodRequest != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    if (_bloodRequest.Status.Equals("Đã yêu cầu"))
                    {
                        bloodDonorContext.BloodRequests.Remove(_bloodRequest);
                        bloodDonorContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Không thể xóa yêu cầu máu có trạng thái khác Đã yêu cầu!");
                    }
                }
                else
                {
                    throw new Exception("Yêu cầu không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ApproveBloodRequestById(int id)
        {
            try
            {
                BloodRequest _bloodRequest = GetBloodRequestById(id);
                if (_bloodRequest != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    _bloodRequest.Status = BloodRequestStatus.ACCEPTED.ToString();
                    bloodDonorContext.Entry<BloodRequest>(_bloodRequest).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Yêu cầu không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RejectBloodRequestById(int id)
        {
            try
            {
                BloodRequest _bloodRequest = GetBloodRequestById(id);
                if (_bloodRequest != null)
                {
                    var bloodDonorContext = new PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext();
                    _bloodRequest.Status = BloodRequestStatus.REJECTED.ToString();
                    bloodDonorContext.Entry<BloodRequest>(_bloodRequest).State = EntityState.Modified;
                    bloodDonorContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Yêu cầu không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
