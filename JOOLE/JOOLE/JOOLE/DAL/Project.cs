using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOOLE.DAL
{
    public class Project : IProject
    {
        public int projectID { get; private set; }
        public string location { get; set; }
        public string projectName { get; set; }
        public int customerID { get; set; }

        public Project(string loc, string pName)
        {
            if (String.IsNullOrEmpty(loc) || String.IsNullOrEmpty(pName) )
            {
                throw new ArgumentException("Arguments can't be empty");
            }
            location = loc;
            projectName = pName;

        }

        public Project(string loc, string pName, int pID=0, int cID=0)
        {
            if (String.IsNullOrEmpty(loc) || String.IsNullOrEmpty(pName)||pID==0||cID==0)
            {
                throw new ArgumentException("Arguments can't be empty");
            }
            location = loc;
            projectName = pName;
            projectID = pID;
            customerID = cID;


        }




    }
}