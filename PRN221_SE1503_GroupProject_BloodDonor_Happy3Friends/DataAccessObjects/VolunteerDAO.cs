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
    }
}
