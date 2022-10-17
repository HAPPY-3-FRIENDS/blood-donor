using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
