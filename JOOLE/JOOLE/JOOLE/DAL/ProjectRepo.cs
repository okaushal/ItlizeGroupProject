using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JOOLE.Models;
using JOOLE.Repository;


namespace JOOLE.DAL
{
    public class ProjectRepo :GenericRepo<PROJECT> , IProjectRepo
    {
        public ProjectRepo(ProjectEntities context):base(context)
        {

        }

        




    }
}