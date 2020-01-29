using JOOLE.Models;
using System.Collections.Generic;



namespace JOOLE.Repository
{
    public interface IProjectRepo:IGenericRepo<PROJECT>
    {
        JooleEntity context { get; set; }
        IEnumerable<PROJECT> getProjectsBySameCustomer(int customerID);
    }
}